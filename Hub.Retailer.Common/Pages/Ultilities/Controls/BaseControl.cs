using Hub.Core.Decorators;

namespace Hub.Retailer.Common.Pages.Ultilities.Controls
{
    public class BaseControl
    {
        protected IPageDecorator _page;
        public BaseControl(IPageDecorator page)
        {
            _page = page;
        }
    }
}
