using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Hub.Core.Controls
{
    public class SelectList : BaseControl
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

        public override async Task<string> GetValue()
        {
            //TODO get current value in dropdown
            return string.Empty;
        }


        public override async Task SetValue(string value)
        {
            await _selectLocator.Locator(DropdownCornerIconSelector).ClickAsync();
            await _baseLocator.Locator(ListItemSelector).Locator($"text = {value}").ClickAsync();
        }
    }
}
