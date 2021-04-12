using System;

namespace IdeVerseContracts.UserManager
{
	public interface IUserIdProvider
	{
		public Guid Id { get; }
	}
}
