using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdeVerseContracts.Dto;

namespace IdeVerseContracts.Services
{
	public interface IUserRoleService
	{
		public Task<List<UserRoleDto>> GetRoles();
		public Task<UserRoleDto> GetUserRole(Guid id);
		public Task PutUserRole(Guid id, UserRoleDto userRoleDto);
		public Task PostUserRole(UserRoleDto userRoleDto);
		public Task<UserRoleDto> DeleteUserRole(Guid id);

	}
}
