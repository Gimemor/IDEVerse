using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace RBCAcademyDb
{
	public class ScheduleAttendance
	{
		public Guid ScheduleEntryId { get; set; }
		public ScheduleEntry ScheduleEntry { get; set; }

		public Guid UserId { get; set; }

		public User User { get; set; }

		public class Map : IEntityTypeConfiguration<ScheduleAttendance>
		{
			public void Configure(EntityTypeBuilder<ScheduleAttendance> builder)
			{
				builder.ToTable("ScheduleAttendance", "Study");
				builder.HasKey(x => new { x.ScheduleEntryId, x.UserId });
				builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
				builder.HasOne(x => x.ScheduleEntry).WithMany().HasForeignKey(x => x.ScheduleEntryId);
			}
		}
	}
}
