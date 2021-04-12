
using System;
using System.Collections.Generic;

namespace IdeVerseContracts.Dto
{
	public class UserDto
	{
		public Guid Id { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PasswordHash { get; set; }
		public string Salt { get; set; }
		public Guid RoleId { get; set; }
		public UserRoleDto Role { get; set; }
		public bool IsConfirmed { get; set; }
		public List<SubjectDto> Subjects { get; set; }
		public List<ScheduleEntryDto> Attendance { get; set; }

		//public ICollection<TaskGrade> Grades { get; set; }
	}
}
