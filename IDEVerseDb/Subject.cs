using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace IDEVerseDb
{
	public class Subject
	{
		public Guid Id { get; set; }
		public string Title { get; set; }

		public DateTime? Deadline { get; set; }
		public ICollection<SubjectAssignment> SubjectAssignments { get; set; }
		public ICollection<ScheduleEntry> SubjectLessons { get; set; }
		public ICollection<SubjectTask> Tasks { get; set; }
		public class Map : IEntityTypeConfiguration<Subject>
		{
			public void Configure(EntityTypeBuilder<Subject> builder)
			{
				builder.ToTable("Subjects", "Study");
				builder.HasKey(x => x.Id);
				builder.HasMany(x => x.SubjectAssignments).WithOne(x => x.Subject).HasForeignKey(x => x.SubjectId);
				builder.HasMany(x => x.SubjectLessons).WithOne(x => x.Subject).HasForeignKey(x => x.SubjectId);
				builder.HasMany(x => x.Tasks).WithOne(x => x.Subject).HasForeignKey(x => x.SubjectId);
			}
		}
	}
}
