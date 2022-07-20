using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Hub.Retailer.Common.Pages.Ultilities.Controls
{
    public class NextButtonControl 
    {
        private readonly ILocator _locator;
        public NextButtonControl(ILocator locator)
        {
            _locator = locator;
        }

        private string NextButton => "text=Next";

        public async Task GoNext()
        {
            await _locator.Locator(NextButton).ClickAsync();
        }
    }
}
