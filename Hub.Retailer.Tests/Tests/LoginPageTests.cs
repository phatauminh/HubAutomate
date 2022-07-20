using Hub.Retailer.Common.Pages.Login;
using Hub.Retailer.Tests.Hooks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Retailer.Tests.Tests
{
    public class LoginPageTests : InitializeHooks
    {
        [Test]
        public async Task Verify_Login_Success()
        {
            var page = new LoginPage(Page);
            await page.LoginUserPortal();
        }
    }
}

