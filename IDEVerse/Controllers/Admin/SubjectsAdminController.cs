using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdeVerseContracts.Dto;
using IdeVerseContracts.Services;
using Microsoft.AspNetCore.Mvc;
using RBCAcademyDb;

namespace RBCAcademy.Controllers.Admin
{
    [Route("api/admin/subjects")]
    [ApiController]
    public class SubjectsAdminController : BaseApiContoller
    {
        private ISubjectService _subjectService;
        public SubjectsAdminController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        // GET: api/admin/Subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetSubjects()
        {
            return await CallAsync(async () =>  await _subjectService.GetSubjects());
        }

        // GET: api/admin/Subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDto>> GetSubject(Guid id)
        {
            return await CallAsync(async () => await _subjectService.GetSubject(id));
        }

        // PUT: api/Subjects/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(Guid id, SubjectDto subject)
        {
            return await CallAsync(async () => await _subjectService.PutSubject(id, subject));
        }

        // POST: api/Subjects
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(SubjectDto subject)
        {
            return await CallAsync(async () => await _subjectService.PostSubject(subject));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Subject>> DeleteSubject(Guid id)
        {
            return await CallAsync(async () => await _subjectService.DeleteSubject(id));
        }
    }
}
