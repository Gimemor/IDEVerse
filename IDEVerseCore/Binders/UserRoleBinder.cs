using IdeVerseContracts.Dto;
using IDEVerseDb;
using System;
using System.Linq;

namespace IDEVerseCore.Binders
{
	public class UserRoleBinder
	{
		public static UserRoleDto BindFrom(UserRole userRole, UserRoleDto userRoleDto)
		{
			userRoleDto.Id = userRole.Id;
			userRoleDto.Title = userRole.Title;
			userRoleDto.Mnemo = userRole.Mnemo;
			if (userRole.Rights != null && userRole.Rights.Any()) {
				userRoleDto.Rights = userRole.Rights.Select(x => UserRightBinder.BindFrom(x.Right, new UserRightDto())).ToArray();
			}
			return userRoleDto;
		}

		public static UserRole BindTo(UserRole userRole, UserRoleDto userRoleDto)
		{
			userRole.Title = userRoleDto.Title;
			userRole.Mnemo = userRoleDto.Mnemo;
			if (userRoleDto.Rights != null && userRoleDto.Rights.Any()) {
				userRole.Rights = userRoleDto.Rights.Select(x => new RightToRole { RightId = x.Id, RoleId = userRole.Id }).ToList();
			}
			return userRole;
		}
	}
}
