using Microsoft.EntityFrameworkCore;
using IdeVerseContracts.Dto;
using IdeVerseContracts.Exceptions;
using IdeVerseContracts.Services;
using IdeVerseContracts.UserManager;
using RBCAcademyCore.Binders;
using RBCAcademyDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBCAcademyCore.Services
{
	public class UserRoleService : IUserRoleService
	{
		private MainContext _context { get; set; }
		public UserRoleService(MainContext context)
		{
			_context = context;
		}

		// GET: api/UserRoles
		public async Task<List<UserRoleDto>> GetRoles()
		{
			var query = _context.Roles.Include(x => x.Rights).ThenInclude(x => x.Right);
			var rawList = await query.ToListAsync().ConfigureAwait(false);
			var result = rawList.Select(x => UserRoleBinder.BindFrom(x, new UserRoleDto())).ToList();
			return result;

		}

		// GET: api/UserRoles/5
		public async Task<UserRoleDto> GetUserRole(Guid id)
		{
			var query = _context.Roles.Include(x => x.Rights).ThenInclude(x => x.Right);
			var userRole = await query.FirstOrDefaultAsync(x => x.Id == id);

			if (userRole == null)
			{
				throw new ApplicationException($"Сущность UserRole id {id} не найдена");
			}

			return UserRoleBinder.BindFrom(userRole, new UserRoleDto());
		}

		// PUT: api/UserRoles/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		public async Task PutUserRole(Guid id, UserRoleDto userRoleDto)
		{
			if (id != userRoleDto.Id)
			{
				throw new BadRequestException();
			}
			var query = _context.Roles.Include(x => x.Rights).ThenInclude(x => x.Right);
			var userRole = await query.FirstOrDefaultAsync(x => x.Id == id);
			if (userRole == null)
			{
				throw new EntityNotFoundException(id);
			}
			UserRoleBinder.BindTo(userRole, userRoleDto);
			await _context.SaveChangesAsync();
		}

		// POST: api/UserRoles
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
		public async Task PostUserRole(UserRoleDto userRoleDto)
		{
			var query = _context.Roles.Include(x => x.Rights).ThenInclude(x => x.Right);
			var userRole = await query.FirstOrDefaultAsync(x => x.Id == userRoleDto.Id);
			if (userRole == null)
			{
				userRole = new UserRole() { Id = Guid.NewGuid() };
				_context.Add(userRole);
			}
			UserRoleBinder.BindTo(userRole, userRoleDto);
			await _context.SaveChangesAsync();
		}

		// DELETE: api/UserRoles/5
		public async Task<UserRoleDto> DeleteUserRole(Guid id)
		{
			var query = _context.Roles.Include(x => x.Rights).ThenInclude(x => x.Right);
			var userRole = await query.FirstOrDefaultAsync(x => x.Id == id);
			if (userRole == null)
			{
				throw new EntityNotFoundException(id, typeof(UserRole));
			}

			_context.Roles.Remove(userRole);
			await _context.SaveChangesAsync();

			return UserRoleBinder.BindFrom(userRole, new UserRoleDto());
		}

	}
}
