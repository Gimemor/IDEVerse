
using System;

namespace IdeVerseContracts.Dto
{
	public class UserRoleDto
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Mnemo { get; set; }
		public UserRightDto[] Rights { get; set; }
	}
}
