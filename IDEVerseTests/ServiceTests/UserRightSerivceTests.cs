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
	public class UserRightsServiceTests
	{
		public UserRightsServiceTests()
		{
		}

		public static void PrefillUserRightsForTestMethods(MainContext ctx)
		{
			var userRights = new List<UserRight>  {
				new UserRight { Id = new Guid("7628F9AC-61C3-4FB8-93A4-3B3A3C933A8E"), Mnemo = "ToRemove1", Title = "Для удаления 1", Description = "тестовый" },
				new UserRight { Id = new Guid("2CB63A0E-BFAA-42D1-A287-23182415BEDE"), Mnemo = "ToRemove2", Title = "Для удаления 2", Description = "тестовый" },
				new UserRight { Id = new Guid("982AB778-5618-40F6-A292-FF570EB6AA84"), Mnemo = "ToRemove3", Title = "Для удаления 3", Description = "тестовый" },
				new UserRight { Id = new Guid("0A42C982-E530-4746-A2B3-EEED9B18A5A6"), Mnemo = "ToRemove4", Title = "Для удаления 4", Description = "тестовый" },
			};
			var toAdd = new List<UserRight>();
			var existingRights = ctx.Rights.ToList();
			foreach (var Right in userRights)
			{
				if (existingRights.All(x => x.Id != Right.Id))
				{
					toAdd.Add(Right);
				}
			}
			ctx.Rights.AddRange(toAdd);
			ctx.SaveChanges();
		}

		[TestMethod]
		public void ShouldReturnSmth()
		{
			using (var dbCtx = TestDbFactory.GetDbContext())
			{
				PrefillUserRightsForTestMethods(dbCtx);
				var userRightService = new UserRightService(dbCtx);
				var Rights = userRightService.GetUserRight(new Guid("7628F9AC-61C3-4FB8-93A4-3B3A3C933A8E")).GetAwaiter().GetResult();
				Assert.IsNotNull(Rights);
				Assert.IsTrue(Rights.Mnemo == "ToRemove1");
			}
		}

		[TestMethod]
		public void ShouldRetrunList()
		{
			using (var dbCtx = TestDbFactory.GetDbContext())
			{
				PrefillUserRightsForTestMethods(dbCtx);
				var userRightService = new UserRightService(dbCtx);
				var rights = userRightService.GetRights().GetAwaiter().GetResult();
				Assert.IsNotNull(rights);
				Assert.IsTrue(rights.Count > 0);
			}
		}

		[TestMethod]
		public void ShouldDeleteSmth()
		{
			using (var dbCtx = TestDbFactory.GetDbContext())
			{
				PrefillUserRightsForTestMethods(dbCtx);
				var userRightService = new UserRightService(dbCtx);
				var right = userRightService.DeleteUserRight(new Guid("7628F9AC-61C3-4FB8-93A4-3B3A3C933A8E")).GetAwaiter().GetResult();
				Assert.IsNotNull(right);
				Assert.IsTrue(right.Mnemo == "ToRemove1");
				var Rights = userRightService.GetRights().GetAwaiter().GetResult();
				Assert.IsTrue(Rights.All(x => x.Mnemo != "ToRemove1"));
			}
		}

	}
}
