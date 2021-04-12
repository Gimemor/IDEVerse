using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdeVerseContracts.Dto;
using IdeVerseContracts.Services;
using Microsoft.AspNetCore.Mvc;
using RBCAcademyDb;

namespace RBCAcademy.Controllers.Admin
{
    [Route("api/admin/userRights")]
    [ApiController]
    public class UserRightsAdminController : BaseApiContoller
    {
        private readonly IUserRightService _userRightService;
        public UserRightsAdminController(IUserRightService userRightService)
        {
            _userRightService = userRightService;
        }

        // GET: api/UserRights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRightDto>>> GetRights()
        {
            return await CallAsync(async () => await _userRightService.GetRights());
        }

        // GET: api/UserRights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRight>> GetUserRight(Guid id)
        {
            return await CallAsync(async () => await _userRightService.GetUserRight(id));
        }

        // PUT: api/UserRights/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRight(Guid id, UserRightDto userRight)
        {
            return await CallAsync(async () => await _userRightService.PutUserRight(id, userRight));
        }

        // POST: api/UserRights
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserRightDto>> PostUserRight([FromBody] UserRightDto userRight)
        {
            return await CallAsync(async () => await _userRightService.PostUserRight(userRight));
        }

        // DELETE: api/UserRights/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserRightDto>> DeleteUserRight(Guid id)
        {
            return await CallAsync(async () => await _userRightService.DeleteUserRight(id));
        }
    }
}
