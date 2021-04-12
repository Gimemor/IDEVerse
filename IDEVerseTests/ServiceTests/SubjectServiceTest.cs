using Microsoft.VisualStudio.TestTools.UnitTesting;
using RBCAcademyCore.Services;
using RBCAcademyDb;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RbcAcademyTests.ServiceTests
{
	[TestClass]
	public class SubjectServiceTest
	{
		public SubjectServiceTest()
		{
		}

		
		public static void PrefillSubjectsForTestMethods(MainContext ctx)
		{
			var entities = new List<Subject>  {
				new Subject { Id = new Guid("6319280F-DD1F-4409-8445-CB2065C995F1"), Deadline  = DateTime.Now + TimeSpan.FromDays(3), Title = "Для удаления 1" },
				new Subject { Id = new Guid("EB47C600-5530-4BF3-952F-03AC8E8B3A66"), Deadline  = DateTime.Now + TimeSpan.FromDays(4), Title = "Для удаления 2" },
				new Subject { Id = new Guid("6C9A24C2-B130-4DCE-885A-BBA66F27D6E1"), Deadline  = DateTime.Now + TimeSpan.FromDays(5), Title = "Для удаления 3" },
				new Subject { Id = new Guid("96B47648-008E-4217-A59D-97DE78C2A699"), Deadline  = DateTime.Now + TimeSpan.FromDays(7), Title = "Для удаления 4" },
			};
			var toAdd = new List<Subject>();
			var existingEntities = ctx.Subjects.ToList();
			foreach (var entity in entities)
			{
				if (existingEntities.All(x => x.Id != entity.Id))
				{
					toAdd.Add(entity);
				}
			}
			ctx.Subjects.AddRange(toAdd);
			ctx.SaveChanges();
		}

		[TestMethod]
		public void ShouldReturnSmth()
		{
			using (var dbCtx = TestDbFactory.GetDbContext())
			{
				PrefillSubjectsForTestMethods(dbCtx);
				var service = new SubjectService(dbCtx);
				var subject = service.GetSubject(new Guid("6C9A24C2-B130-4DCE-885A-BBA66F27D6E1")).GetAwaiter().GetResult();
				Assert.IsNotNull(subject);
				Assert.IsTrue(subject.Title == "Для удаления 3");
			}
		}

		[TestMethod]
		public void ShouldRetrunList()
		{
			using (var dbCtx = TestDbFactory.GetDbContext())
			{
				PrefillSubjectsForTestMethods(dbCtx);
				var service = new SubjectService(dbCtx);
				var subjects = service.GetSubjects().GetAwaiter().GetResult();
				Assert.IsNotNull(subjects);
				Assert.IsTrue(subjects.Count > 0);
			}
		}

		[TestMethod]
		public void ShouldDeleteSmth()
		{
			using (var dbCtx = TestDbFactory.GetDbContext())
			{
				PrefillSubjectsForTestMethods(dbCtx);
				var service = new SubjectService(dbCtx);
				var subject = service.DeleteSubject(new Guid("6C9A24C2-B130-4DCE-885A-BBA66F27D6E1")).GetAwaiter().GetResult();
				Assert.IsNotNull(subject);
				Assert.IsTrue(subject.Title == "Для удаления 3");
				var roles = service.GetSubjects().GetAwaiter().GetResult();
				Assert.IsTrue(roles.All(x => x.Title != "Для удаления 3"));
			}
		}


	}
}
