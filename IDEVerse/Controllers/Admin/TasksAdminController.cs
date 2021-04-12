﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeVerseContracts.Dto;
using IdeVerseContracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RBCAcademyDb;

namespace RBCAcademy.Controllers.Admin
{
    [Route("api/admin/tasks")]
    [ApiController]
    public class TasksAdminController : BaseApiContoller
    {
        private readonly ISubjectTaskService _subjectTaskService;

        public TasksAdminController(ISubjectTaskService subjectTaskService)
        {
            _subjectTaskService = subjectTaskService;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectTask>>> GetTasks()
        {
            return await CallAsync(async () => await _subjectTaskService.GetTasks());
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectTask>> GetSubjectTask(Guid id)
        {
            return await CallAsync(async () => await _subjectTaskService.GetTask(id));
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjectTask(Guid id, TaskDto subjectTask)
        {
            return await CallAsync(async () => await _subjectTaskService.PutTask(id, subjectTask));
        }

        // POST: api/Tasks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SubjectTask>> PostSubjectTask(TaskDto subjectTask)
        {
            return await CallAsync(async () => await _subjectTaskService.PostTask(subjectTask));
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubjectTask>> DeleteSubjectTask(Guid id)
        {
            return await CallAsync(async () => await _subjectTaskService.DeleteTask(id));
        }
    }
}
