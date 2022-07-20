using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Hub.Core.Controls
{
    public class SelectList
    {
        #region Seletors
        private readonly string DropdownCornerIconSelector = "//select//parent::div//following-sibling::div";
        private readonly string ListItemSelector = "//div[@class='ui-selectonemenu-items-wrapper']//ul/li";
        #endregion

        private readonly ILocator _selectLocator;
        private readonly ILocator _baseLocator;
        public SelectList(ILocator baseLocator, ILocator selectLocator)
        {
            _selectLocator = selectLocator;
            _baseLocator = baseLocator;
        }

        public async Task Select(string item)
        {
            await _selectLocator.Locator(DropdownCornerIconSelector).ClickAsync();
            await _baseLocator.Locator(ListItemSelector).Locator($"text = {item}").ClickAsync();
        }
    }
}
