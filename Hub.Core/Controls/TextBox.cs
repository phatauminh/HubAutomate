using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Hub.Core.Controls
{
    public class TextBox : BaseControl
    {
        private readonly ILocator _locator;
        public TextBox(ILocator locator)
        {
            _locator = locator;
        }

        public override async Task SetValue(string value)
        {
            await _locator.FillAsync(value);
        }

        public override async Task<string> GetValue()
        {
            return await _locator.InputValueAsync();
        }
    }
}
