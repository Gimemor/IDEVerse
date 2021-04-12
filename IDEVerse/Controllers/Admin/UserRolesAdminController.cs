using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdeVerseContracts.Dto;
using IdeVerseContracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RBCAcademy.Controllers.Admin
{
    [Route("api/admin/UserRoles")]
    [ApiController]
    public class UserRolesAdminController : BaseApiContoller
    {
        private readonly IUserRoleService _userRoleService;
        public UserRolesAdminController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        // GET: api/UserRoles
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserRoleDto>>> GetRoles()
        {
            return await CallAsync(async () => await _userRoleService.GetRoles());
        }

        // GET: api/UserRoles/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserRoleDto>> GetUserRole(Guid id)
        {
            return await CallAsync(async () => await _userRoleService.GetUserRole(id));
        }

        // PUT: api/UserRoles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutUserRole(Guid id, UserRoleDto userRole)
        {
            return await CallAsync(async () => await _userRoleService.PutUserRole(id, userRole));
        }

        // POST: api/UserRoles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<UserRoleDto>> PostUserRole([FromBody] UserRoleDto userRole)
        {
            return await CallAsync(async () => await _userRoleService.PostUserRole(userRole));
        }

        // DELETE: api/UserRoles/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<UserRoleDto>> DeleteUserRole(Guid id)
        {
            return await CallAsync(async () => await _userRoleService.DeleteUserRole(id));
        }
    }
}
