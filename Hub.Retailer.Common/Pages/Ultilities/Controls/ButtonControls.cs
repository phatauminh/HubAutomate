using Hub.Core.Decorators;

namespace Hub.Retailer.Common.Pages.Ultilities.Controls
{
    public class ButtonControls
    {
        private readonly IPageDecorator _page;

        public ButtonControls(IPageDecorator page)
        {
            _page = page;
        }
        public AddButtonControl AddButtonControl => new AddButtonControl(_page);
        public NextButtonControl NextButtonControl => new NextButtonControl(_page);
    }
}
