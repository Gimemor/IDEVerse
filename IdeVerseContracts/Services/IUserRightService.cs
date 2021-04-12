using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdeVerseContracts.Dto;

namespace IdeVerseContracts.Services
{
	public interface IUserRightService
	{
		public Task<List<UserRightDto>> GetRights();
		public Task<UserRightDto> GetUserRight(Guid id);
		public Task PutUserRight(Guid id, UserRightDto userRightDto);
		public Task PostUserRight(UserRightDto userRightDto);
		public Task<UserRightDto> DeleteUserRight(Guid id);
	}
}
