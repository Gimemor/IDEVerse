using IdeVerseContracts.Dto;
using IDEVerseDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDEVerseCore.Binders
{
	public class ScheduleEntryBinder
	{
		public static ScheduleEntryDto BindFrom(ScheduleEntry scheduleEntry, ScheduleEntryDto scheduleEntryDto)
		{
			scheduleEntryDto.Id = scheduleEntry.Id;
			scheduleEntryDto.LessonDate = scheduleEntry.LessonDate;
			if (scheduleEntry.Subject != null)
				scheduleEntryDto.Subject = SubjectBinder.BindFrom(scheduleEntry.Subject, new SubjectDto());
			if (scheduleEntry.Teacher != null)
				scheduleEntryDto.Teacher = UserBinder.BindFrom(scheduleEntry.Teacher, new UserDto());
			if (scheduleEntry.Attendance != null)
				scheduleEntryDto.Attendance = scheduleEntry.Attendance.Select(x => UserBinder.BindFrom(x.User, new UserDto())).ToList();
			return scheduleEntryDto;
		}

		public static ScheduleEntry BindTo(ScheduleEntry scheduleEntry, ScheduleEntryDto scheduleEntryDto, MainContext context)
		{
			scheduleEntry.LessonDate = scheduleEntryDto.LessonDate;
			if(scheduleEntryDto.Subject != null)
				scheduleEntry.SubjectId = scheduleEntryDto.Subject.Id;
			if (scheduleEntryDto.Teacher != null)
				scheduleEntry.TeacherId = scheduleEntryDto.Teacher.Id;
			if (scheduleEntryDto.Attendance != null)
			{
				context.Set<ScheduleAttendance>().RemoveRange(scheduleEntry.Attendance);
				scheduleEntry.Attendance = scheduleEntryDto.Attendance.Select(x => new ScheduleAttendance { UserId = x.Id, ScheduleEntryId = scheduleEntry.Id }).ToList();
			}
			return scheduleEntry;
		}
	}
}
