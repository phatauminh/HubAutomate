using Hub.Retailer.Common.Models;
using Hub.Retailer.Common.Services;

namespace Hub.Retailer.Common.Configurations
{
    public static class RetailerConfiguration
    {
        private static readonly RetailerSettings Configuration = ConfigurationRetailerService.GetRetailerSettings();

        public static string GetUserPortalUrl => Configuration.ServerSettings.UPUrl;

        public static Credentials Credentials => Configuration.Credentials;
        public static DatabaseSettings DatabaseSettings => Configuration.DatabaseSettings;

    }
}
