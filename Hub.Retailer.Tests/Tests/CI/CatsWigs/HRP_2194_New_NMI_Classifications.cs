using Hub.Core.Ultilities;
using Hub.Retailer.Common.Pages.Activities;
using Hub.Retailer.Common.Pages.Login;
using Hub.Retailer.Common.Pages.Ultilities.Popups;
using Hub.Retailer.Tests.Hooks;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Hub.Retailer.Tests.Tests.CI.CatsWigs
{
    public class HRP_2194_New_NMI_Classifications : InitializeHooks
    {
        [Test]
        public async Task Verify_Login_Success()
        {

            var page = new LoginPage(Page);
            await page.LoginUserPortal();

            var page2 = new ActivityMaintenancePage(Page);
            await page2.GoToPage();
            await page2.GoToActivity("Energy Offer", "Energy Offer");

            var popup = new EnergyOfferPopup(Page);
            await popup.InputCustomerFindNew(null);


        }
    }
}
