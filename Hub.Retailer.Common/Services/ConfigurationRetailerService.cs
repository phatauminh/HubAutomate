using Hub.Core.Exceptions;
using Hub.Core.Services;
using Hub.Retailer.Common.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Hub.Retailer.Common.Services
{
    public static class ConfigurationRetailerService
    {
        private static IConfigurationRoot Root;
        public static RetailerSettings GetRetailerSettings()
        {
            if (Root == null)
                Root = InitializeConfiguration();

            var result = Root.GetSection("RetailerSettings").Get<RetailerSettings>();

            if (result == null)
                throw new ConfigurationNotFoundException(typeof(RetailerSettings).ToString());

            return result;
        }

        private static IConfigurationRoot InitializeConfiguration()
        {
            var environment = ConfigurationService.GetBaseSettings().Environment;

            var filesInExecutionDir = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var settingsFile = filesInExecutionDir.FirstOrDefault(x => x.Contains($"appsettings.{environment}") && x.EndsWith(".json"));
            var builder = new ConfigurationBuilder();
            if (settingsFile != null)
                builder.AddJsonFile(settingsFile, optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
