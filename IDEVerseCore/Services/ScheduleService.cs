using Microsoft.EntityFrameworkCore;
using IdeVerseContracts.Dto;
using IdeVerseContracts.Exceptions;
using IdeVerseContracts.Services;
using RBCAcademyCore.Binders;
using RBCAcademyDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBCAcademyCore.Services
{
	public class ScheduleService : IScheduleService
	{
		private MainContext _context { get; set; }
		public ScheduleService(MainContext context)
		{
			_context = context;
		}

		public async Task<ScheduleEntryDto> DeleteScheduleEntry(Guid id)
		{
			var scheduleEntry = await _context.ScheduleEntries.FindAsync(id);
			if (scheduleEntry == null)
			{
				throw new EntityNotFoundException(id, typeof(ScheduleEntryDto));
			}

			_context.ScheduleEntries.Remove(scheduleEntry);
			await _context.SaveChangesAsync();

			return ScheduleEntryBinder.BindFrom(scheduleEntry, new ScheduleEntryDto());
		}

		public async Task<IList<ScheduleEntryDto>> GetScheduleEntries()
		{
			var rawList = await _context.ScheduleEntries
				.Include(x => x.Subject)
				.Include(x => x.Teacher)
				.Include(x => x.Attendance)
					.ThenInclude(x => x.User)
				.ToListAsync().ConfigureAwait(false);
			var result = rawList.Select(x => ScheduleEntryBinder.BindFrom(x, new ScheduleEntryDto())).ToList();
			return result;
		}

		public async Task<ScheduleEntryDto> GetScheduleEntry(Guid id)
		{
			
			var scheduleEntry = await _context.ScheduleEntries
				.Include(x => x.Subject)
				.Include(x => x.Attendance)
					.ThenInclude(x => x.User)
				.Include(x => x.Teacher).SingleOrDefaultAsync(x => x.Id == id);

			if (scheduleEntry == null)
			{
				throw new ApplicationException($"Сущность scheduleEntry id {id} не найдена");
			}

			return ScheduleEntryBinder.BindFrom(scheduleEntry, new ScheduleEntryDto());
		}

		public async Task PostScheduleEntry(ScheduleEntryDto scheduleEntryDto)
		{
			var scheduleEntry = await _context.ScheduleEntries
				.Include(x => x.Subject)
				.Include(x => x.Attendance)
					.ThenInclude(x => x.User)
				.Include(x => x.Teacher)
				.SingleOrDefaultAsync(x => x.Id == scheduleEntryDto.Id);
			if (scheduleEntry == null)
			{
				scheduleEntry = new ScheduleEntry() { Id = Guid.NewGuid() };
				_context.Add(scheduleEntry);
			}
			ScheduleEntryBinder.BindTo(scheduleEntry, scheduleEntryDto, _context);
			await _context.SaveChangesAsync();
		}

		public async Task PutScheduleEntry(Guid id, ScheduleEntryDto scheduleEntryDto)
		{
			if (id != scheduleEntryDto.Id)
			{
				throw new BadRequestException();
			}
			var scheduleEntry = await _context.ScheduleEntries
				.Include(x => x.Subject)
				.Include(x => x.Attendance)
					.ThenInclude(x => x.User)
				.Include(x => x.Teacher)
				.SingleOrDefaultAsync(x => x.Id == id);
			if (scheduleEntry == null)
			{
				throw new EntityNotFoundException(id);
			}
			ScheduleEntryBinder.BindTo(scheduleEntry, scheduleEntryDto, _context);
			await _context.SaveChangesAsync();
		}
	}
}
