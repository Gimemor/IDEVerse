﻿using System;
using System.Linq;
using System.Threading.Tasks;
using IdeVerseContracts.UserManager;

namespace IDEVerse
{
	public class UserIdProvider : IUserIdProvider
	{
		public UserIdProvider(Guid userId) {
			Id = userId;
		}
		public Guid Id { get; }

	}
}
