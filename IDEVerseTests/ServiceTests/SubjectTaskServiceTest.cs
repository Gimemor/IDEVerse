using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDEVerseCore.Services;
using IDEVerseDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDEVerseTests.ServiceTests
{
	[TestClass]
	public class SubjectTaskServiceTest
	{
		public SubjectTaskServiceTest()
		{
		}

		public static void PrefillSubjectTasksForTestMethods(MainContext ctx)
		{
			SubjectServiceTest.PrefillSubjectsForTestMethods(ctx);
			var entities = new List<SubjectTask>  {
				new SubjectTask { Id = new Guid("11E77799-2E77-44E6-9D4B-237765BE9D10"), Deadline = DateTime.Now + TimeSpan.FromDays(3), Title = "Для удаления", Description = "Тестовая", SubjectId = new Guid("6319280F-DD1F-4409-8445-CB2065C995F1") },
				new SubjectTask { Id = new Guid("F1808A79-B97C-44D7-B556-CCDED9F7D322"), Deadline = DateTime.Now + TimeSpan.FromDays(5), Title = "Для удаления", Description = "Тестовая 2", SubjectId = new Guid("6319280F-DD1F-4409-8445-CB2065C995F1") },
				new SubjectTask { Id = new Guid("BB9182AA-504E-4EB9-9B40-92AFA43A6D74"), Deadline = DateTime.Now + TimeSpan.FromDays(2), Title = "Для удаления", Description = "Тестовая", SubjectId = new Guid("96B47648-008E-4217-A59D-97DE78C2A699") },
			};
			var toAdd = new List<SubjectTask>();
			var existingEntities = ctx.Tasks.ToList();
			foreach (var entity in entities)
			{
				if (existingEntities.All(x => x.Id != entity.Id))
				{
					toAdd.Add(entity);
				}
			}
			ctx.Tasks.AddRange(toAdd);
			ctx.SaveChanges();
		}

		[TestMethod]
		public void ShouldReturnSmth()
		{
			using (var dbCtx = TestDbFactory.GetDbContext())
			{
				PrefillSubjectTasksForTestMethods(dbCtx);
				var service = new SubjectTaskService(dbCtx);
				var task = service.GetTask(new Guid("BB9182AA-504E-4EB9-9B40-92AFA43A6D74")).GetAwaiter().GetResult();
				Assert.IsNotNull(task);
				Assert.IsTrue(task.Title == "Для удаления");
			}
		}

		[TestMethod]
		public void ShouldRetrunList()
		{
			using (var dbCtx = TestDbFactory.GetDbContext())
			{
				PrefillSubjectTasksForTestMethods(dbCtx);
				var service = new SubjectTaskService(dbCtx);
				var tasks = service.GetTasks().GetAwaiter().GetResult();
				Assert.IsNotNull(tasks);
				Assert.IsTrue(tasks.Count > 0);
			}
		}

		[TestMethod]
		public void ShouldDeleteSmth()
		{
			using (var dbCtx = TestDbFactory.GetDbContext())
			{
				PrefillSubjectTasksForTestMethods(dbCtx);
				var service = new SubjectTaskService(dbCtx);
				var task = service.DeleteTask(new Guid("BB9182AA-504E-4EB9-9B40-92AFA43A6D74")).GetAwaiter().GetResult();
				Assert.IsNotNull(task);
				Assert.IsTrue(task.Title == "Для удаления");
				var tasks = service.GetTasks().GetAwaiter().GetResult();
				Assert.IsTrue(tasks.All(x => x.Id != new Guid("BB9182AA-504E-4EB9-9B40-92AFA43A6D74")));
			}
		}

	}
}
