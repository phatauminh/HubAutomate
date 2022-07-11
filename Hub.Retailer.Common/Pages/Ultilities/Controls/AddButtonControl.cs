using Hub.Core.Decorators;
using System.Threading.Tasks;

namespace Hub.Retailer.Common.Pages.Ultilities.Controls
{
    public class AddButtonControl : BaseControl
    {
        public AddButtonControl(IPageDecorator page) : base(page)
        {
        }

        private string AddButton => "text='Add'";
        private string ItemSelector(string text) => $@"a:has-text('{text}')";
        public async Task GoToActivity(string level1, string level2 = null)
        {
            await _page.ClickAsync(AddButton);

            await _page.Locator($"{ItemSelector(level1)} >> nth=0").HoverAsync();

            if (level2 != null)
                await _page.Locator($"{ItemSelector(level2)} >> nth=2").ClickAsync();
        }
    }
}
