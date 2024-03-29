﻿using Microsoft.EntityFrameworkCore;
using IDEVerseDb;

namespace IDEVerseTests
{
	public class TestDbFactory
	{
		private static string ConnectionString = "Data Source=MainContext.db;Cache=Shared";
		public static MainContext GetDbContext() {
			var dbContextOptionsBuilder = new DbContextOptionsBuilder();
			dbContextOptionsBuilder.UseSqlite(ConnectionString);
			var context =  new MainContext(dbContextOptionsBuilder.Options);
			context.Database.EnsureCreated();
			return context;
		}
	}
}
