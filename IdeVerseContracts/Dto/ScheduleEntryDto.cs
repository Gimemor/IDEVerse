using System;
using System.Collections.Generic;

namespace IdeVerseContracts.Dto
{
	public class ScheduleEntryDto
	{
		public Guid Id { get; set; }
		public DateTime LessonDate { get; set; }
		public SubjectDto Subject { get; set; }
		public UserDto Teacher { get; set; }
		public List<UserDto> Attendance { get; set; }
	}
}
