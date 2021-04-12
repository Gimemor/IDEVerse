using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdeVerseContracts.Dto;

namespace IdeVerseContracts.Services
{
	public interface IUserService
	{
        public Task<IList<UserDto>> GetUsers();
        public Task<UserDto> GetUser(Guid id);
        public Task PutUser(Guid id, UserDto user);
        public Task PostUser(UserDto user);
        public Task<UserDto> DeleteUser(Guid id);
        public Task<UserDto> GetUserByLogin(LoginDto login);
    }
}
