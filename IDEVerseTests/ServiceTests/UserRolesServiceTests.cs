using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDEVerseCore.Services;
using IDEVerseDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDEVerseTests.ServiceTests
{
	/// <summary>
	/// Сервис должен правильно выполнить действия
	/// 1. Нужно правильно заинжектить сервису зависимости и базу
	/// </summary>
	[TestClass]
	public class UserRolesServiceTests 
	{
		public UserRolesServiceTests()
		{
		}

		public static void PrefillUserRolesForTestMethods(MainContext ctx)
		{
			UserRightsServiceTests.PrefillUserRightsForTestMethods(ctx);
			var userRoles = new List<UserRole>  {
				new UserRole { Id = new Guid("D5A46920-4F4D-4521-891B-E54626EFA36B"), Mnemo = "ToRemove1", Title = "Для удаления 1", Rights = new [] {
					new RightToRole { RightId =  new Guid("7628F9AC-61C3-4FB8-93A4-3B3A3C933A8E"), RoleId = new Guid("D5A46920-4F4D-4521-891B-E54626EFA36B")},
					new RightToRole { RightId =  new Guid("0A42C982-E530-4746-A2B3-EEED9B18A5A6"), RoleId = new Guid("D5A46920-4F4D-4521-891B-E54626EFA36B")},
				}},
				new UserRole { Id = new Guid("6B372C61-BD77-4636-BE4A-5A3E3B90DBAE"), Mnemo = "ToRemove2", Title = "Для удаления 2", Rights = new [] {
					new RightToRole { RightId =  new Guid("7628F9AC-61C3-4FB8-93A4-3B3A3C933A8E"), RoleId = new Guid("6B372C61-BD77-4636-BE4A-5A3E3B90DBAE")},
				} },
				new UserRole { Id = new Guid("11520A8F-027F-4CCE-9C90-9CE9B2E84969"), Mnemo = "ToRemove3", Title = "Для удаления 3" },
				new UserRole { Id = new Guid("C4A8B796-5EA3-4884-AAE0-E0313BB298BC"), Mnemo = "ToRemove4", Title = "Для удаления 4" },
			};
			var toAdd = new List<UserRole>();
			var existingRoles = ctx.Roles.ToList();
			foreach (var role in userRoles) {
				if (existingRoles.All(x => x.Id != role.Id))
				{
					toAdd.Add(role);
				}
			}
			ctx.Roles.AddRange(toAdd);
			ctx.SaveChanges();
		}
		
		[TestMethod]
		public void ShouldReturnSmth()
		{
			using ( var dbCtx = TestDbFactory.GetDbContext())
			{
				PrefillUserRolesForTestMethods(dbCtx);
				var userRoleService = new UserRoleService(dbCtx);
				var roles = userRoleService.GetUserRole(new Guid("C4A8B796-5EA3-4884-AAE0-E0313BB298BC")).GetAwaiter().GetResult();
				Assert.IsNotNull(roles);
				Assert.IsTrue(roles.Mnemo == "ToRemove4");
			}
		}

		[TestMethod]
		public void ShouldRetrunList()
		{
			using (var dbCtx = TestDbFactory.GetDbContext())
			{
				PrefillUserRolesForTestMethods(dbCtx);
				var userRoleService = new UserRoleService(dbCtx);
				var roles = userRoleService.GetRoles().GetAwaiter().GetResult();
				Assert.IsNotNull(roles);
				Assert.IsTrue(roles.Count > 0);
			}
		}

		[TestMethod]
		public void ShouldDeleteSmth()
		{
			using (var dbCtx = TestDbFactory.GetDbContext())
			{
				PrefillUserRolesForTestMethods(dbCtx);
				var userRoleService = new UserRoleService(dbCtx);
				var role = userRoleService.DeleteUserRole(new Guid("C4A8B796-5EA3-4884-AAE0-E0313BB298BC")).GetAwaiter().GetResult();
				Assert.IsNotNull(role);
				Assert.IsTrue(role.Mnemo== "ToRemove4");
				var roles = userRoleService.GetRoles().GetAwaiter().GetResult();
				Assert.IsTrue(roles.All(x => x.Mnemo != "ToRemove4"));
			}
		}


	}
}
