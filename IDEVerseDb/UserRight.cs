using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace RBCAcademyDb
{
	public class UserRight
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Mnemo { get; set; }

		public class Map : IEntityTypeConfiguration<UserRight>
		{
			public void Configure(EntityTypeBuilder<UserRight> builder)
			{
				builder.ToTable("Rights", "Authorization");
				builder.HasKey(x => x.Id);
				builder.HasData(new[] {
					new UserRight
					{
						Id = new Guid("72F59BC4-47F8-4E7A-8FB5-7E1380CBE072"),
						Description = "Доступ к панели управления",
						Mnemo = UserRightMnemo.ControlPanelAccess,
						Title = "Доступ к панели управления"
					}
					, new UserRight
					{
						Id = new Guid("EAE48CAB-2B37-4200-AEF6-5870F6EC21C1"),
						Description = "Доступ к расписанию",
						Mnemo = UserRightMnemo.ScheduleAccess,
						Title = "Доступ к расписанию"
					}
				});
			}
		}
	}
}
