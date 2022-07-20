using Hub.Core.Drivers;
using Hub.Retailer.Data.Entities;
using Hub.Retailer.Data.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Hub.Retailer.Tests.Hooks
{
    public class InitializeHooks : PlaywrightDriver
    {
        public ModelContext ModelContext;

        [SetUp]
        public async Task SetUp()
        {
            Page = await InitalizePlaywright();
            ModelContext = DatabaseService.GetModelContext();
        }

        [TearDown]
        public async Task TearDown()
        {
            await BrowserContext.CloseAsync();
        }
    }
}

