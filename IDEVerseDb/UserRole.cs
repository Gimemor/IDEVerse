using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace RBCAcademyDb
{
	public class UserRole
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Mnemo { get; set; }
		public ICollection<RightToRole> Rights { get; set; }

		public class Map : IEntityTypeConfiguration<UserRole>
		{
			public void Configure(EntityTypeBuilder<UserRole> builder)
			{
				builder.HasKey(x => x.Id);
				builder.ToTable("UserRoles", "Authorization");
				builder.HasMany(x => x.Rights).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
			}
		}
	}
}
