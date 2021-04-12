
using IdeVerseContracts.Dto;
using RBCAcademyDb;

namespace RBCAcademyCore.Binders
{
	public class TaskBinder
	{
		public static TaskDto BindFrom(SubjectTask task, TaskDto taskDto)
		{
			taskDto.Id = task.Id;
			taskDto.Title = task.Title;
			taskDto.Deadline = task.Deadline;
			taskDto.Description = task.Description;
			taskDto.SubjectId = task.SubjectId;
			if (task.Subject != null)
			{
				taskDto.Subject = SubjectBinder.BindFrom(task.Subject, new SubjectDto());
			}
			return taskDto;
		}

		public static TaskDto BindTo(SubjectTask task, TaskDto taskDto)
		{
			task.Title = taskDto.Title;
			task.Deadline = taskDto.Deadline;
			task.Description = taskDto.Description;
			task.SubjectId = taskDto.Subject.Id;
			return taskDto;
		}
	}
}
