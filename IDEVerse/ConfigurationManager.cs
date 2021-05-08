using Microsoft.Extensions.Configuration;
using IdeVerseContracts;

namespace IDEVerse
{
	public class ConfigurationManager : IConfigurationManager
	{
		private IConfiguration _configuration;
		public ConfigurationManager(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string ConnecitonStringParamName => "DefaultConnection";
		public string DefaultDbConnection => _configuration.GetConnectionString(ConnecitonStringParamName);
		public string JwtIssuer => _configuration["Jwt:Issuer"];
		public string JwtKey => _configuration["Jwt:Key"];

		public string DefaultAuthPolicy => _configuration["DefaultAuthPolicy"];
	}
}
