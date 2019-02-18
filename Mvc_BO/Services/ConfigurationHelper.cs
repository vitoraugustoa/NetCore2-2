using Microsoft.Extensions.Configuration;

namespace Mvc_BO.Services
{
    public static class ConfigurationHelper
    {
        // Read the archive appsettings.json
        public static IConfigurationRoot GetConfiguration(string path, string environmentName = null){
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json",optional:true,reloadOnChange:true);

            if(!string.IsNullOrWhiteSpace(environmentName)){
                
                builder = builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
            }

            builder = builder.AddEnvironmentVariables();

            return builder.Build();
        }
    }
}