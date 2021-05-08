using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace IDEVerseDb
{
	public class User
	{
		public Guid Id { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PasswordHash { get; set; }
		public string Salt { get; set; }
		public Guid RoleId { get; set; }
		public UserRole Role { get; set; }
		public bool IsConfirmed { get; set; }
		public ICollection<SubjectAssignment> SubjectAssignments { get; set; }
		public ICollection<TaskGrade> Grades { get; set; }
		public ICollection<ScheduleAttendance>  Attendance { get; set; }
		public class Map : IEntityTypeConfiguration<User>
		{
			public void Configure(EntityTypeBuilder<User> builder)
			{
				builder.ToTable("Users", "Authorization");
				builder.HasKey(x => x.Id);
				builder.HasOne(x => x.Role).WithMany().HasForeignKey(x => x.RoleId);
				builder.HasMany(x => x.SubjectAssignments).WithOne(x => x.User);
				builder.HasMany(x => x.Grades).WithOne(x => x.User).HasForeignKey(x => x.UserId);
				builder.HasMany(x => x.Attendance).WithOne(x => x.User).HasForeignKey(x => x.UserId);
			}

		}
	}
}
