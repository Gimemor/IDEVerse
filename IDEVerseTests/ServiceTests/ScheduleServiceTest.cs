using Microsoft.VisualStudio.TestTools.UnitTesting;
using RBCAcademyCore.Services;
using RBCAcademyDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RbcAcademyTests.ServiceTests
{
	[TestClass]
	public class ScheduleServiceTest
	{

		public static void PrefillScheduleForTestMethods(MainContext ctx)
		{
			SubjectServiceTest.PrefillSubjectsForTestMethods(ctx);
			UsersServiceTests.PrefillUserForTestMethods(ctx);
			var entities = new List<ScheduleEntry>  {
				new ScheduleEntry () {
					Id = new Guid("2FAA66FB-631C-478F-B52C-8480B601D0E2"),
					LessonDate  = DateTime.Now + TimeSpan.FromDays(3),
					SubjectId = new Guid("6319280F-DD1F-4409-8445-CB2065C995F1"),
					TeacherId = new Guid("D5A46920-4F4D-4521-891B-E54626EFA36B"),
					Attendance = new List<ScheduleAttendance>() {
						new ScheduleAttendance { UserId = new Guid("E778F6CA-6A59-42C6-90BE-1C2AE3A6C19D"), ScheduleEntryId = new Guid("2FAA66FB-631C-478F-B52C-8480B601D0E2")},
						new ScheduleAttendance { UserId = new Guid("D5A46920-4F4D-4521-891B-E54626EFA36B"), ScheduleEntryId = new Guid("2FAA66FB-631C-478F-B52C-8480B601D0E2")},
					}
				},
				new ScheduleEntry { Id = new Guid("166B1AF1-655E-4D22-97EE-1E1192E509D5"), LessonDate = DateTime.Now + TimeSpan.FromDays(4), SubjectId = new Guid("6C9A24C2-B130-4DCE-885A-BBA66F27D6E1"), TeacherId = new Guid("E778F6CA-6A59-42C6-90BE-1C2AE3A6C19D") },
				new ScheduleEntry { Id = new Guid("9CF2C067-E74E-4DAA-B778-0FD1405CAFCF"), LessonDate = DateTime.Now + TimeSpan.FromDays(5), SubjectId = new Guid("6319280F-DD1F-4409-8445-CB2065C995F1"), TeacherId = new Guid("E778F6CA-6A59-42C6-90BE-1C2AE3A6C19D") },
				new ScheduleEntry { Id = new Guid("3E66F24B-8644-4886-8244-53D8054E3CC1"), LessonDate = DateTime.Now + TimeSpan.FromDays(7), SubjectId = new Guid("96B47648-008E-4217-A59D-97DE78C2A699"), TeacherId = new Guid("D5A46920-4F4D-4521-891B-E54626EFA36B") },
			};
			var toAdd = new List<ScheduleEntry>();
			var existingEntities = ctx.ScheduleEntries.ToList();
			foreach (var entity in entities)
			{
				if (existingEntities.All(x => x.Id != entity.Id))
				{
					toAdd.Add(entity);
				}
			}
			ctx.ScheduleEntries.AddRange(toAdd);
			ctx.SaveChanges();
		}

		[TestMethod]
		public void ShouldReturnSmth()
		{
			using (var dbCtx = TestDbFactory.GetDbContext())
			{
				PrefillScheduleForTestMethods(dbCtx);
				var service = new ScheduleService(dbCtx);
				var scheduleEntry = service.GetScheduleEntry(new Guid("166B1AF1-655E-4D22-97EE-1E1192E509D5")).GetAwaiter().GetResult();
				Assert.IsNotNull(scheduleEntry);
			}
		}

		[TestMethod]
		public void ShouldRetrunList()
		{
			using (var dbCtx = TestDbFactory.GetDbContext())
			{
				PrefillScheduleForTestMethods(dbCtx);
				var service = new ScheduleService(dbCtx);
				var scheduleList = service.GetScheduleEntries().GetAwaiter().GetResult();
				Assert.IsNotNull(scheduleList);
				Assert.IsTrue(scheduleList.Count > 0);
			}
		}

		[TestMethod]
		public void ShouldDeleteSmth()
		{
			using (var dbCtx = TestDbFactory.GetDbContext())
			{
				PrefillScheduleForTestMethods(dbCtx);
				var service = new ScheduleService(dbCtx);
				var scheduleDeleted = service.DeleteScheduleEntry(new Guid("166B1AF1-655E-4D22-97EE-1E1192E509D5")).GetAwaiter().GetResult();
				Assert.IsNotNull(scheduleDeleted);
				var scheduleList = service.GetScheduleEntries().GetAwaiter().GetResult();
				Assert.IsNotNull(scheduleList);
				Assert.IsTrue(scheduleList.Count > 0);
			}
		}


	}
}
