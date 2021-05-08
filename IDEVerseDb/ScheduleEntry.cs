using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace IDEVerseDb
{
	public class ScheduleEntry
	{
		public Guid Id { get; set; }
		public DateTime LessonDate { get; set; }
		public Guid SubjectId { get; set; }
		public Subject Subject { get; set; }
		public Guid TeacherId { get; set; }
		public User Teacher { get; set; }

		public ICollection<ScheduleAttendance> Attendance { get; set; }

		public class Map : IEntityTypeConfiguration<ScheduleEntry>
		{
			public void Configure(EntityTypeBuilder<ScheduleEntry> builder)
			{
				builder.ToTable("Schedule", "Study");
				builder.HasKey(x => x.Id);
				builder.HasOne(x => x.Subject).WithMany(x => x.SubjectLessons).HasForeignKey(x => x.SubjectId);
				builder.HasOne(x => x.Teacher).WithMany().HasForeignKey(x => x.TeacherId);
				builder.HasMany(x => x.Attendance).WithOne(x => x.ScheduleEntry).HasForeignKey(x => x.ScheduleEntryId);
			} 
		}
	}
}
