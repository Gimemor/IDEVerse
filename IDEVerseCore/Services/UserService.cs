
using Microsoft.EntityFrameworkCore;
using IdeVerseContracts.Dto;
using IdeVerseContracts.Exceptions;
using IdeVerseContracts.Services;
using IDEVerseCore.Binders;
using IDEVerseDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDEVerseCore.Services
{
/// <summary>
/// anguluar
/// </summary>
	public class UserService : IUserService
	{
		private MainContext _context { get; set; }
		public UserService(MainContext context)
		{
			_context = context;
		}

		public async Task<UserDto> DeleteUser(Guid id)
		{
			var user = await _context.Users.FindAsync(id);
			if (user == null)
			{
				throw new EntityNotFoundException(id, typeof(User));
			}

			_context.Users.Remove(user);
			await _context.SaveChangesAsync();

			return UserBinder.BindFrom(user, new UserDto());
		}

		public async Task<UserDto> GetUser(Guid id)
		{
			var user = await _context.Users
				.Include(x => x.Role)
				.Include(x => x.SubjectAssignments)
				.Include(x => x.Attendance)
				.SingleOrDefaultAsync(x => x.Id == id);

			if (user == null)
			{
				throw new ApplicationException($"Сущность user id {id} не найдена");
			}

			return UserBinder.BindFrom(user, new UserDto());
		}

		public async Task<IList<UserDto>> GetUsers()
		{
			await _context.Set<Subject>().LoadAsync();
			var rawList = await _context.Users
				.Include(x => x.Role)
				.Include(x => x.SubjectAssignments)
				.Include(x => x.Attendance)
				.ToListAsync().ConfigureAwait(false);
			var result = rawList.Select(x => UserBinder.BindFrom(x, new UserDto())).ToList();
			return result;
		}

		public async Task PostUser(UserDto userDto)
		{
			var user = await _context.Users
				.Include(x => x.Role)
				.Include(x => x.SubjectAssignments)
				.Include(x => x.Attendance)
				.SingleOrDefaultAsync(x => x.Id == userDto.Id);
			if (user == null)
			{
				user = new User() { Id = Guid.NewGuid() };
				_context.Add(user);
			}
			UserBinder.BindTo(user, userDto);
			await _context.SaveChangesAsync();
		}

		public async Task PutUser(Guid id, UserDto userDto)
		{
			if (id != userDto.Id)
			{
				throw new BadRequestException();
			}
			var user = await _context.Users
				.Include(x => x.Role)
				.Include(x => x.SubjectAssignments)
				.Include(x => x.Attendance)
				.SingleOrDefaultAsync(x => x.Id == id);
			if (user == null)
			{
				throw new EntityNotFoundException(id);
			}
			UserBinder.BindTo(user, userDto);
			await _context.SaveChangesAsync();
		}

		public async Task<UserDto> GetUserByLogin(LoginDto login)
		{
			var user = await _context.Users
				.Include(x => x.Attendance)
				.Include(x => x.Role).ThenInclude(x => x.Rights).ThenInclude(x => x.Right)
				.Include(x => x.SubjectAssignments).ThenInclude(x => x.Subject)
				.FirstOrDefaultAsync(x => x.Email == login.Login).ConfigureAwait(false);
			if (user == null)
				return null;
			//if (user.PasswordHash != login.Password.GetPasswordHash(user.Salt)) {
			//	return false;
			//}
			return UserBinder.BindFrom(user, new UserDto());
		}

	}
}
