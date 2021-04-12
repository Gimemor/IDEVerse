using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdeVerseContracts.Dto;

namespace IdeVerseContracts.Services
{
	public interface ISubjectTaskService
	{
		public Task<List<TaskDto>> GetTasks();
		public Task<TaskDto> GetTask(Guid id);
		public Task PutTask(Guid id, TaskDto userRoleDto);
		public Task PostTask(TaskDto userRoleDto);
		public Task<TaskDto> DeleteTask(Guid id);

	}
}
