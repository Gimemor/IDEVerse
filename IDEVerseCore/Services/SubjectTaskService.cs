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
	public class SubjectTaskService : ISubjectTaskService
	{
		private MainContext _context;
		public SubjectTaskService(MainContext context)
		{
			_context = context;
		}

		public async Task<TaskDto> DeleteTask(Guid id)
		{
			var task = await _context.Tasks.FindAsync(id);
			if (task == null)
			{
				throw new EntityNotFoundException(id, typeof(SubjectTask));
			}

			_context.Tasks.Remove(task);
			await _context.SaveChangesAsync();

			return TaskBinder.BindFrom(task, new TaskDto());
		}

		public async Task<TaskDto> GetTask(Guid id)
		{
			var task = await _context.Tasks.FindAsync(id);

			if (task == null)
			{
				throw new ApplicationException($"Сущность subject task id {id} не найдена");
			}

			return TaskBinder.BindFrom(task, new TaskDto());
		}

		public async Task<List<TaskDto>> GetTasks()
		{
			var rawList = await _context.Tasks
				.Include(x => x.Subject)
				.ToListAsync()
				.ConfigureAwait(false);
			var result = rawList.Select(x => TaskBinder.BindFrom(x, new TaskDto())).ToList();
			return result;
		}

		public async Task PostTask(TaskDto taskDto)
		{
			var task = await _context.Tasks.FindAsync(taskDto.Id);
			if (task == null)
			{
				task = new SubjectTask() { Id = Guid.NewGuid() };
				_context.Add(task);
			}
			TaskBinder.BindTo(task, taskDto);
			await _context.SaveChangesAsync();
		}

		public async Task PutTask(Guid id, TaskDto taskDto)
		{
			if (id != taskDto.Id)
			{
				throw new BadRequestException();
			}
			var task = await _context.Tasks.FindAsync(id);
			if (task == null)
			{
				throw new EntityNotFoundException(id);
			}
			TaskBinder.BindTo(task, taskDto);
			await _context.SaveChangesAsync();
		}
	}
}
