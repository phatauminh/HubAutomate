using Hub.Core.Models;

namespace Hub.Retailer.Common.Models
{
    public class RetailerSettings : BaseSettings
    {
        public ServerSettings ServerSettings { get; set; }
        public DatabaseSettings DatabaseSettings { get; set; }
        public Credentials Credentials { get; set; }
    }

    public class ServerSettings
    {
        public string UPUrl { get; set; }
        public string FIUrl { get; set; }
        public string WSUrl { get; set; }
        public string HPGUrl { get; set; }
        public string HCMUrl { get; set; }
        public string REUrl { get; set; }
        public string CCEUrl { get; set; }
    }

    public class Credentials
    {
        public SSOCredential SSOCredential { get; set; }
        public HubCredential HubCredential { get; set; }
    }

    public class SSOCredential
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class HubCredential
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
    }
}
