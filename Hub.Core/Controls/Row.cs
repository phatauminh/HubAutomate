using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Hub.Core.Controls
{
    public class Row
    {
        private readonly ILocator _locator;
        public Row(ILocator locator)
        {
            _locator = locator;
        }

        public async Task ClickOnRow()
        {
            await _locator.ClickAsync();
        }
    }
}
