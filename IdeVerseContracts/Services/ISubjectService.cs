using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdeVerseContracts.Dto;

namespace IdeVerseContracts.Services
{
	public interface ISubjectService
	{
        public Task<IList<SubjectDto>> GetSubjects();

        public Task<IList<SubjectDto>> GetSubjectsByUserId(Guid userId); 

        public Task<SubjectDto> GetSubject(Guid id);
        public Task PutSubject(Guid id, SubjectDto subjectDto);
        public Task PostSubject(SubjectDto subjectDto);
        public Task<SubjectDto> DeleteSubject(Guid id);

    }
}
