using Microsoft.Extensions.Configuration;

namespace JobMatching.Infrastructure.Utilities
{
	public static class AppSettingsReader
	{
		//This class needs to be fixed.
		public static string GetValue(string key)
		{
			var basePath = "C:\\Users\\Antho\\Desktop\\Julius_projekt\\JobMatching\\JobMatching.Infrastructure";
			
			var configuration = new ConfigurationBuilder()
				.SetBasePath(basePath)
				.AddJsonFile("appsettings.json")
				.Build();

			return configuration[key] ??
				throw new KeyNotFoundException(
					"The value with the specified key could not be found.");
		}
	}
}
