using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdeVerseContracts.Dto;
using IdeVerseContracts.Services;
using Microsoft.AspNetCore.Mvc;
using IDEVerseDb;

namespace IDEVerse.Controllers.Admin
{
    [Route("api/admin/Users")]
    [ApiController]
    public class UsersAdminController : BaseApiContoller
    {
        private readonly IUserService _userService;

        public UsersAdminController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            return await CallAsync(async () => await _userService.GetUsers());
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            return await CallAsync(async () => await _userService.GetUser(id));
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, UserDto user)
        {
            return await CallAsync(async () => await _userService.PutUser(id, user));
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(UserDto user)
        {
            return await CallAsync(async () => await _userService.PostUser(user));
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(Guid id)
        {
            return await CallAsync(async () => await _userService.DeleteUser(id));
        }
    }
}
