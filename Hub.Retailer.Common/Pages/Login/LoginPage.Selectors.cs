using System.Threading.Tasks;

namespace Hub.Retailer.Common.Pages.Login
{
    public partial class LoginPage
    {
        private bool isSSO;

        string NextButton => "//input[@type='submit' and @value = 'Next']";
        string UsernameField => isSSO ? "css=[type='email']" : "id=j_username";
        string PasswordField => isSSO ? "[type='password']" : "id=j_password";
        string SignInButton => isSSO ? "//input[@type='submit' and @value = 'Sign in']" : "id=login";
        string StaySignInButton(bool staySignIn) => staySignIn ? "//input[@type='submit' and @value = 'Yes']" : "//input[@type='button' and @value = 'No']";

        private async Task<bool> IsSSO()
        {
            var pageTitle = await _page.TitleAsync();
            isSSO = pageTitle.Equals(SSO_LOGIN_TITLE);
            return isSSO;
        }
    }
}

