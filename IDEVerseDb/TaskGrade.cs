using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IDEVerseDb
{
	public class TaskGrade
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public User User { get; set; }
		public Guid TaskId { get; set; }
		public SubjectTask Task { get; set; }
		public int Grade { get; set; }

		public class Map : IEntityTypeConfiguration<TaskGrade>
		{
			public void Configure(EntityTypeBuilder<TaskGrade> builder)
			{
				builder.ToTable("TaskGrades", "Study");
				builder.HasKey(x => x.Id);
				builder.HasOne(x => x.User).WithMany(x => x.Grades).HasForeignKey(x => x.UserId);
				builder.HasOne(x => x.Task).WithMany(x => x.Grades).HasForeignKey(x => x.TaskId);
			}
		}
	}
}
