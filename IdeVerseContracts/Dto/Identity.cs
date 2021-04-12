
using System.Collections.Generic;

namespace IdeVerseContracts.Dto
{
	public class Identity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Login { get; set; }
		public string Token { get; set; }
		public List<string> Rights { get; set; }
	}
}
