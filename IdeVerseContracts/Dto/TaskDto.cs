using System;

namespace IdeVerseContracts.Dto
{
	public class TaskDto
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime? Deadline { get; set; }
		public SubjectDto Subject { get; set; }
		public Guid SubjectId { get; set; }
	}
}
