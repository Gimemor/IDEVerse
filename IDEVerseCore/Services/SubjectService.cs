using Microsoft.EntityFrameworkCore;
using IdeVerseContracts.Dto;
using IdeVerseContracts.Exceptions;
using IdeVerseContracts.Services;
using IDEVerseCore.Binders;
using IDEVerseDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEVerseCore.Services
{
	public class SubjectService : ISubjectService
	{
		private MainContext _context { get; set; }
		public SubjectService(MainContext context)
		{
			_context = context;
		}

		// GET: api/Subject
		public async Task<IList<SubjectDto>> GetSubjects()
		{
			var rawList = await _context.Subjects.ToListAsync().ConfigureAwait(false);
			var result = rawList.Select(x => SubjectBinder.BindFrom(x, new SubjectDto())).ToList();
			return result;
		}

		public async Task<IList<SubjectDto>> GetSubjectsByUserId(Guid userId)
		{
			var rawList = await _context.Subjects
				.Include(x => x.SubjectAssignments)
				.Where(x => x.SubjectAssignments.Any(x => x.UserId == userId))
				.ToListAsync().ConfigureAwait(false);
			var result = rawList.Select(x => SubjectBinder.BindFrom(x, new SubjectDto())).ToList();
			return result;
		}

		// GET: api/Subject/5
		public async Task<SubjectDto> GetSubject(Guid id)
		{
			var subject = await _context.Subjects.FindAsync(id);

			if (subject == null)
			{
				throw new ApplicationException($"Сущность subject id {id} не найдена");
			}

			return SubjectBinder.BindFrom(subject, new SubjectDto());
		}

		// PUT: api/Subject/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		public async Task PutSubject(Guid id, SubjectDto subjectDto)
		{
			if (id != subjectDto.Id)
			{
				throw new BadRequestException();
			}
			var subject = await _context.Subjects.FindAsync(id);
			if (subject == null)
			{
				throw new EntityNotFoundException(id);
			}
			SubjectBinder.BindTo(subject, subjectDto);
			await _context.SaveChangesAsync();
		}

		// POST: api/Subject
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		public async Task PostSubject(SubjectDto subjectDto)
		{
			var subject = await _context.Subjects.FindAsync(subjectDto.Id);
			if (subject == null)
			{
				subject = new Subject() { Id = Guid.NewGuid() };
				_context.Add(subject);
			}
			SubjectBinder.BindTo(subject, subjectDto);
			await _context.SaveChangesAsync();
		}

		// DELETE: api/Subject/5
		public async Task<SubjectDto> DeleteSubject(Guid id)
		{
			var subject = await _context.Subjects.FindAsync(id);
			if (subject == null)
			{
				throw new EntityNotFoundException(id, typeof(Subject));
			}

			_context.Subjects.Remove(subject);
			await _context.SaveChangesAsync();

			return SubjectBinder.BindFrom(subject, new SubjectDto());
		}

	}
}
