using Hub.Core.Decorators;
using System.Threading.Tasks;

namespace Hub.Retailer.Common.Pages.Ultilities.Controls
{
    public class NextButtonControl : BaseControl
    {
        public NextButtonControl(IPageDecorator page) : base(page)
        {
        }

        private string NextButton => "text=Next";

        public async Task GoNext()
        {
            await _page.ClickAsync(NextButton);
        }
    }
}
