using Hub.Core.Decorators;
using System.Threading.Tasks;

namespace Hub.Retailer.Common.Pages.Ultilities.Sections
{
    public class MainMenuSection
    {
        private readonly IPageDecorator _page;
        public MainMenuSection(IPageDecorator page)
        {
            _page = page;
        }

        private string MenuButton => "id=layout-menubar-resize";
        private string ArticleSelector(string text) => $"//a[normalize-space()='{text}']";

        public async Task GoToPage(string level1, string level2 = null, string level3 = null)
        {
            await _page.ClickAsync(MenuButton);

            await _page.Locator(ArticleSelector(level1)).ClickAsync();

            if (level2 != null)
                await _page.Locator(ArticleSelector(level2)).ClickAsync();

            if (level3 != null)
                await _page.Locator(ArticleSelector(level3)).ClickAsync();
        }
    }
}

