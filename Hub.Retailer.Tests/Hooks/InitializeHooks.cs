using Hub.Core.Drivers;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Hub.Retailer.Tests.Hooks
{
    public class InitializeHooks : PlaywrightDriver
    {
        [SetUp]
        public async Task SetUp()
        {
            Page = await InitalizePlaywright();
        }

        [TearDown]
        public async Task TearDown()
        {
            await BrowserContext.CloseAsync();
        }
    }
}

