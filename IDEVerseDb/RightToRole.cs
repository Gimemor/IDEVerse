using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace RBCAcademyDb
{
	public class RightToRole
	{
		public Guid RightId { get; set; }
		public UserRight Right { get; set; }
		public Guid RoleId { get; set; }
		public UserRole Role { get; set; }

		public class Map : IEntityTypeConfiguration<RightToRole>
		{
			public void Configure(EntityTypeBuilder<RightToRole> builder)
			{
				builder.ToTable("RightToRole", "Authorization");
				builder.HasKey(x => new { x.RightId, x.RoleId });
				builder.HasOne(x => x.Right).WithMany().HasForeignKey(x => x.RightId);
				builder.HasOne(x => x.Role).WithMany(x => x.Rights).HasForeignKey(x => x.RoleId);
			}
		}
	}
}
