using Microsoft.EntityFrameworkCore;
using IdeVerseContracts.Dto;
using IdeVerseContracts.Exceptions;
using IdeVerseContracts.Services;
using IDEVerseCore.Binders;
using IDEVerseDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDEVerseCore.Services
{
	public class UserRightService : IUserRightService
	{
		private MainContext _context { get; set; }
		public UserRightService(MainContext context)
		{
			_context = context;
		}

		// GET: api/UserRights
		public async Task<List<UserRightDto>> GetRights()
		{
			var rawList = await _context.Rights.ToListAsync().ConfigureAwait(false);
			var result = rawList.Select(x => UserRightBinder.BindFrom(x, new UserRightDto())).ToList();
			return result;

		}

		// GET: api/UserRights/5
		public async Task<UserRightDto> GetUserRight(Guid id)
		{
			var userRight = await _context.Rights.FindAsync(id);

			if (userRight == null)
			{
				throw new ApplicationException($"Сущность UserRight id {id} не найдена");
			}

			return UserRightBinder.BindFrom(userRight, new UserRightDto());
		}

		// PUT: api/UserRights/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		public async Task PutUserRight(Guid id, UserRightDto userRightDto)
		{
			if (id != userRightDto.Id)
			{
				throw new BadRequestException();
			}
			var userRight = await _context.Rights.FindAsync(id);
			if (userRight == null)
			{
				throw new EntityNotFoundException(id);
			}
			UserRightBinder.BindTo(userRight, userRightDto);
			await _context.SaveChangesAsync();
		}

		// POST: api/UserRights
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		public async Task PostUserRight(UserRightDto userRightDto)
		{
			var userRight = await _context.Rights.FindAsync(userRightDto.Id);
			if (userRight == null)
			{
				userRight = new UserRight() { Id = Guid.NewGuid() };
				_context.Add(userRight);
			}
			UserRightBinder.BindTo(userRight, userRightDto);
			await _context.SaveChangesAsync();
		}

		// DELETE: api/UserRights/5
		public async Task<UserRightDto> DeleteUserRight(Guid id)
		{
			var userRight = await _context.Rights.FindAsync(id);
			if (userRight == null)
			{
				throw new EntityNotFoundException(id, typeof(UserRight));
			}

			_context.Rights.Remove(userRight);
			await _context.SaveChangesAsync();

			return UserRightBinder.BindFrom(userRight, new UserRightDto());
		}

	}
}
