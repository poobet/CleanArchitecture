using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configuration
{
    public static class ConfigurationManagerHelper
    {
        public static string getConfig(string key) => new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection(key).Value;
        public static string getConnectionString(string key) => new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString(key);
    }
}
