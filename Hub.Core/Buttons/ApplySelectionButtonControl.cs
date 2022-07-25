using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Hub.Core.Buttons
{
    public class ApplySelectionButtonControl : BaseButton
    {
        public ApplySelectionButtonControl(ILocator locator) : base(locator)
        {
        }
        private string ApplySelectionButton => "text=Apply Selection";

        public async Task Execute()
        {
            await _locator.Locator(ApplySelectionButton).ClickAsync();
        }
    }
}
