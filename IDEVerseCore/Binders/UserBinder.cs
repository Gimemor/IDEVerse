using IdeVerseContracts.Dto;
using IDEVerseDb;
using System.Collections.Generic;
using System.Linq;

namespace IDEVerseCore.Binders
{
	public class UserBinder
	{
		public static UserDto BindFrom(User user, UserDto userDto)
		{
			userDto.Id = user.Id;
			userDto.Phone = user.Phone;
			userDto.Email = user.Email;
			userDto.FirstName = user.FirstName;
			userDto.LastName = user.LastName;
			userDto.RoleId = user.RoleId;
			if (user.Role != null)
			{
				userDto.Role = UserRoleBinder.BindFrom(user.Role, new UserRoleDto());
			}
			userDto.IsConfirmed = user.IsConfirmed;
			if (user.SubjectAssignments != null)
			{
				userDto.Subjects = user.SubjectAssignments.Select(x => SubjectBinder.BindFrom(x.Subject, new SubjectDto())).ToList();
			}
			if (user.Attendance != null)
			{
				userDto.Attendance = user.Attendance.Select(x => ScheduleEntryBinder.BindFrom(x.ScheduleEntry, new ScheduleEntryDto())).ToList();
			}
			return userDto;
		}

		public static User BindTo(User user, UserDto userDto)
		{
			user.Phone = userDto.Phone;
			user.Email = userDto.Email;
			user.FirstName = userDto.FirstName;
			user.LastName = userDto.LastName;
			user.RoleId = userDto.RoleId;
			if (userDto.Subjects != null)
			{
				user.SubjectAssignments = userDto.Subjects.Select(x =>  new SubjectAssignment { UserId = user.Id, SubjectId = x.Id} ).ToList();
			}
			if (userDto.Attendance != null)
			{
				user.Attendance = user.Attendance.Select(x => new ScheduleAttendance { UserId = user.Id, ScheduleEntryId = x.ScheduleEntryId }).ToList();
			}
			user.IsConfirmed = user.IsConfirmed;
			return user;
		}
	}
}
