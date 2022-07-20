using Hub.Core.Decorators;
using Hub.Retailer.Common.Configurations;
using Hub.Retailer.Common.Pages.Ultilities.Sections;
using System.Threading.Tasks;

namespace Hub.Retailer.Common.Pages
{
    public abstract class BasePage
    {
        protected readonly IPageDecorator _page;
        protected BasePage(IPageDecorator page)
        {
            _page = page;
            MainMenuSection = new MainMenuSection(_page);
        }

        protected MainMenuSection MainMenuSection { get; }

        public async Task OpenUserPortalUrl()
        {
            await _page.GotoAsync(RetailerConfiguration.GetUserPortalUrl);
        }
        public abstract Task GoToPage();
    }
}

