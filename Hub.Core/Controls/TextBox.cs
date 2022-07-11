using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Hub.Core.Controls
{
    public class TextBox
    {
        private readonly ILocator _locator;
        public TextBox(ILocator locator)
        {
            _locator = locator;
        }

        public async Task SetText(string value) => await _locator.FillAsync(value);

        public async Task<string> GetText() => await _locator.InputValueAsync();
    }
}
