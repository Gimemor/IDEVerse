
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace IDEVerseDb
{
	public class SubjectTask
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public Guid SubjectId { get; set; }
		public Subject Subject { get; set; }
		public DateTime? Deadline { get; set; }
		public ICollection<TaskGrade> Grades { get; set; }
		public class Map : IEntityTypeConfiguration<SubjectTask> {
			public void Configure(EntityTypeBuilder<SubjectTask> builder) {
				builder.ToTable("Tasks", "Study");
				builder.HasKey(x => x.Id);
				builder.HasOne(x => x.Subject).WithMany(x => x.Tasks).HasForeignKey(x => x.SubjectId);
				builder.HasMany(x => x.Grades).WithOne(x => x.Task).HasForeignKey(x => x.TaskId);
			}
		}

	}
}
