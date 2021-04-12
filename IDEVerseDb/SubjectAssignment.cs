
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace RBCAcademyDb
{
	public class SubjectAssignment
	{
		public Guid SubjectId { get; set; }
		public Subject Subject { get; set; }

		public Guid UserId { get; set; }

		public User User { get; set; }
		public bool IsCompleted { get; set; }

		public class Map : IEntityTypeConfiguration<SubjectAssignment>
		{
			public void Configure(EntityTypeBuilder<SubjectAssignment> builder) 
			{
				builder.ToTable("SubjectAssignments", "Study");
				builder.HasKey(x => new { x.SubjectId, x.UserId });
				builder.HasOne(x => x.User).WithMany(x => x.SubjectAssignments).HasForeignKey(x => x.UserId);
				builder.HasOne(x => x.Subject).WithMany(x => x.SubjectAssignments).HasForeignKey(x => x.SubjectId);
			}
		}
	}
}
