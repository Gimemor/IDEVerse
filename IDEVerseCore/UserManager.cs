using Microsoft.EntityFrameworkCore;
using IdeVerseContracts.Dto;
using IdeVerseContracts.Services;
using IdeVerseContracts.UserManager;
using IDEVerseDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDEVerseCore
{
	public class UserManager
	{
		private MainContext _context;
		private User _user;
		public Guid Id { get; }

		public UserManager(IUserIdProvider userIdProvider, MainContext context, User user)
		{
			Id = userIdProvider.Id;
			_context = context;
			_user = user;
			Role = (_user != null)?  _user.Role : null;
		}

		public static UserManager Create(IUserIdProvider userIdProvider, MainContext context) 
		{
			var user =   context.Users
				.Include(x => x.Role)
				.ThenInclude(x => x.Rights)
				.ThenInclude(x => x.Right)
				.FirstOrDefault(x => x.Id == userIdProvider.Id);
			return new UserManager(userIdProvider, context, user);
		}

		private UserRole Role { get; set; }
		public bool HasRight(string mnemo)
		{
			if (Role == null)
				return false;
			return Role.Rights.Any(x => x.Right.Mnemo == mnemo);
		}
	}
}
