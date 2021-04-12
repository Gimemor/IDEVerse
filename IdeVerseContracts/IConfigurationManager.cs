namespace IdeVerseContracts
{
	public interface IConfigurationManager
	{
		public string DefaultDbConnection { get; }
		public string JwtIssuer { get; }
		public string JwtKey { get; }
		public string DefaultAuthPolicy { get; }
	}
}
