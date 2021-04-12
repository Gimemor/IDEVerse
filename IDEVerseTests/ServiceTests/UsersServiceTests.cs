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
	public class UsersServiceTests
	{
		public UsersServiceTests()
		{
		}

		public static void PrefillUserForTestMethods(MainContext ctx)
		{
			
			UserRolesServiceTests.PrefillUserRolesForTestMethods(ctx);
			SubjectServiceTest.PrefillSubjectsForTestMethods(ctx);
			var entities = new List<User>  {
				new User { 
					Id = new Guid("D5A46920-4F4D-4521-891B-E54626EFA36B"),
					Email = "ToRemove1@fake.org",
					FirstName = "Иван", 
					RoleId = new Guid("D5A46920-4F4D-4521-891B-E54626EFA36B"),
					SubjectAssignments = new List<SubjectAssignment>()
					{ 
						new SubjectAssignment { UserId = new Guid("D5A46920-4F4D-4521-891B-E54626EFA36B"), SubjectId = new Guid("EB47C600-5530-4BF3-952F-03AC8E8B3A66")},
						new SubjectAssignment { UserId = new Guid("D5A46920-4F4D-4521-891B-E54626EFA36B"), SubjectId = new Guid("96B47648-008E-4217-A59D-97DE78C2A699")}
					}
				},
				new User {
					Id = new Guid("E778F6CA-6A59-42C6-90BE-1C2AE3A6C19D"), 
					Email = "ToRemove2@fake.org",
					FirstName = "Виктор", 
					RoleId = new Guid("11520A8F-027F-4CCE-9C90-9CE9B2E84969"),
					SubjectAssignments = new List<SubjectAssignment>()
					{
						new SubjectAssignment { UserId = new Guid("E778F6CA-6A59-42C6-90BE-1C2AE3A6C19D"), SubjectId = new Guid("EB47C600-5530-4BF3-952F-03AC8E8B3A66")},
					}
				},
				new User { 
					Id = new Guid("0EB73A27-455F-41D7-882F-C016EDF32151"),
					Email = "ToRemove3@fake.org",
					FirstName = "Вася", 
					RoleId = new Guid("D5A46920-4F4D-4521-891B-E54626EFA36B")
				},
			};
			var toAdd = new List<User>();
			var existingEntities = ctx.Users.ToList();
			foreach (var entity in entities)
			{
				if (existingEntities.All(x => x.Id != entity.Id))
				{
					ctx.Users.AddRange(entity);
					if (entity.SubjectAssignments == null)
						continue;
					foreach (var assingnment in entity.SubjectAssignments)
					{
						if (!ctx.SubjectAssignments.Any(x => x.SubjectId == assingnment.SubjectId && x.UserId == assingnment.UserId))
						{
							ctx.SubjectAssignments.Add(assingnment);
						}
					}
				}
			}
			ctx.SaveChanges();
		}

		[TestMethod]
		public void ShouldReturnSmth()
		{
			using (var dbCtx = TestDbFactory.GetDbContext())
			{
				PrefillUserForTestMethods(dbCtx);
				var userService = new UserService(dbCtx);
				var user = userService.GetUser(new Guid("E778F6CA-6A59-42C6-90BE-1C2AE3A6C19D")).GetAwaiter().GetResult();
				Assert.IsNotNull(user);
				Assert.IsTrue(user.FirstName == "Виктор");
				Assert.IsTrue(user.Role != null && user.Role.Mnemo == "ToRemove3");
				Assert.IsTrue(user.Subjects != null && user.Subjects.Count > 0);
			}
		}

		[TestMethod]
		public void ShouldRetrunList()
		{
			using (var dbCtx = TestDbFactory.GetDbContext())
			{
				PrefillUserForTestMethods(dbCtx);
				var userService = new UserService(dbCtx);
				var users = userService.GetUsers().GetAwaiter().GetResult();
				Assert.IsNotNull(users);
				Assert.IsTrue(users.Count > 0);
			}
		}

		[TestMethod]
		public void ShouldDeleteSmth()
		{
			using (var dbCtx = TestDbFactory.GetDbContext())
			{
				PrefillUserForTestMethods(dbCtx);
				var userService = new UserService(dbCtx);
				var user = userService.DeleteUser(new Guid("E778F6CA-6A59-42C6-90BE-1C2AE3A6C19D")).GetAwaiter().GetResult();
				Assert.IsNotNull(user);
				Assert.IsTrue(user.FirstName == "Виктор");
				Assert.IsTrue(user.Role != null && user.Role.Mnemo == "ToRemove3");
				var users = userService.GetUsers().GetAwaiter().GetResult();
				Assert.IsTrue(users.All(x => x.FirstName != "Виктор"));
			}
		}
	}
}
