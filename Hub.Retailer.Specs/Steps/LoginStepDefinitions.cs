using Hub.Retailer.Common.Pages.Login;
using Hub.Retailer.Data.Entities;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Hub.Retailer.Specs.Steps
{
    [Binding]
    public class LoginStepDefinitions
    {
        private LoginPage _pageObject;
        private ModelContext _modelContext;

        public LoginStepDefinitions(LoginPage login, ModelContext modelContext)
        {
            _pageObject = login;
            _modelContext = modelContext;
        }

        [Given(@"I login to user portal")]
        public async Task WhenILoginToUserPortal()
        {
            await _pageObject.OpenUserPortalUrl();
            await _pageObject.LoginUserPortal();
        }
    }
}
