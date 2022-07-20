using Hub.Core.Decorators;
using Hub.Retailer.Common.Configurations;
using System.Threading.Tasks;

namespace Hub.Retailer.Common.Pages.Login
{
    public partial class LoginPage : BasePage
    {
        public LoginPage(IPageDecorator page) : base(page)
        {
        }

        private const string SSO_LOGIN_TITLE = "Sign in to your account";
        public async Task FillUserName(string userName) => await _page.FillAsync(UsernameField, userName);
        public async Task FillPassword(string password) => await _page.FillAsync(PasswordField, password);
        public async Task ClickSignInButton() => await _page.ClickAsync(SignInButton);
        public async Task ClickNextButton() => await _page.ClickAsync(NextButton);
        public async Task ClickStaySignInButton(bool staySignIn) => await _page.ClickAsync(StaySignInButton(staySignIn));

        private async Task SSOLogin(string username, string password, bool staySignIn)
        {
            await FillUserName(username);
            await ClickNextButton();
            await FillPassword(password);
            await ClickSignInButton();
            await ClickStaySignInButton(staySignIn);
        }
        private async Task DefaultLogin(string username, string password)
        {
            await FillUserName(username);
            await FillPassword(password);
            await ClickSignInButton();
        }

        public async Task LoginUserPortal()
        {
            await GoToPage();
            var credentials = RetailerConfiguration.Credentials;

            if (await IsSSO())
                await SSOLogin(credentials.SSOCredential.Username, credentials.SSOCredential.Password, staySignIn: false);
            else
                await DefaultLogin(credentials.HubCredential.Username, credentials.HubCredential.Password);
        }
        public override sealed async Task GoToPage()
        {
            await OpenUserPortalUrl();
        }
    }
}

