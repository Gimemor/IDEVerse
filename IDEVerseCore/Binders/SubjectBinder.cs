
using IdeVerseContracts.Dto;
using IDEVerseDb;

namespace IDEVerseCore.Binders
{
	public class SubjectBinder
	{
		public static SubjectDto BindFrom(Subject subject, SubjectDto subjectDto)
		{
			subjectDto.Id = subject.Id;
			subjectDto.Title = subject.Title;
			subjectDto.Deadline = subject.Deadline;
			return subjectDto;
		}

		public static Subject BindTo(Subject subject, SubjectDto subjectDto)
		{
			subject.Title = subjectDto.Title;
			subject.Deadline = subjectDto.Deadline;
			return subject;
		}
	}
}
