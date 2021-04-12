using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdeVerseContracts.Dto;
using IdeVerseContracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RBCAcademy.Controllers.Admin
{
    [Route("api/admin/schedule")]
    [ApiController]
    public class ScheduleAdminController : BaseApiContoller
    {
        private IScheduleService _scheduleService;
        public ScheduleAdminController(IScheduleService scheduleSerivce)
        {
            _scheduleService = scheduleSerivce;
        }

        // GET: api/Schedule
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ScheduleEntryDto>>> GetScheduleEntries()
        {
            return await CallAsync(async () => await _scheduleService.GetScheduleEntries());
        }

        // GET: api/Schedule/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleEntryDto>> GetScheduleEntry(Guid id)
        {
            return await CallAsync(async () => await _scheduleService.GetScheduleEntry(id));
        }

        // PUT: api/Schedule/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScheduleEntry(Guid id, ScheduleEntryDto scheduleEntry)
        {
            return await CallAsync(async () => await _scheduleService.PutScheduleEntry(id, scheduleEntry));
        }

        // POST: api/Schedule
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ScheduleEntryDto>> PostScheduleEntry(ScheduleEntryDto scheduleEntry)
        {
            return await CallAsync(async () => await _scheduleService.PostScheduleEntry(scheduleEntry));
        }

        // DELETE: api/Schedule/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ScheduleEntryDto>> DeleteScheduleEntry(Guid id)
        {
            return await CallAsync(async () => await _scheduleService.DeleteScheduleEntry(id));
        }
    }
}
