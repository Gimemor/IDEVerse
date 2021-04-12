using System;
using System.Collections.Generic;
using System.Text;

namespace IdeVerseContracts.Dto
{
	public class SubjectDto
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public DateTime? Deadline { get; set; }
	}
}
