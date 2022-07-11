using Hub.Core.Exceptions;
using Hub.Core.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Hub.Core.Services
{
    public static class ConfigurationService
    {
        private static IConfigurationRoot Root;
        public static BaseSettings GetBaseSettings()
        {
            if (Root == null)
                Root = InitializeConfiguration();

            var result = Root.GetSection("BaseSettings").Get<BaseSettings>();

            if (result == null)
                throw new ConfigurationNotFoundException(typeof(BaseSettings).ToString());

            return result;
        }


        private static IConfigurationRoot InitializeConfiguration()
        {
            var filesInExecutionDir = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var settingsFile = filesInExecutionDir.FirstOrDefault(x => x.Contains("appsettings.json"));
            var builder = new ConfigurationBuilder();
            if (settingsFile != null)
                builder.AddJsonFile(settingsFile, optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
