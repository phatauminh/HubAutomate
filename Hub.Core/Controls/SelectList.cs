using Microsoft.Playwright;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hub.Core.Controls
{
    public class SelectList
    {
        private readonly ILocator _locator;
        public SelectList(ILocator locator)
        {
            _locator = locator;
        }

        public async Task Select(string item, bool matchExactly = true)
        {
            await _locator.Locator("//parent::div").Locator("//following-sibling::div").ClickAsync();

            var element = _locator.Locator("//div[@class='ui-selectonemenu-items-wrapper']");
            element = element.Locator("//ul/li");
        }

        public async Task<string> GetItem(string item, bool matchExactly = true)
        {
            //TODO
            return "";
        }

        public async Task<List<string>> GetItems(string item, bool matchExactly = true)
        {
            //TODO
            return new List<string> { };
        }
    }
}
