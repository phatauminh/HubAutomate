using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Hub.Core.Buttons
{
    public class NextButtonControl : BaseButton
    {
        public NextButtonControl(ILocator locator) : base(locator)
        {
        }

        private string NextButton => "text=Next";

        public async Task Execute()
        {
            await _locator.Locator(NextButton).ClickAsync();
        }
    }
}
