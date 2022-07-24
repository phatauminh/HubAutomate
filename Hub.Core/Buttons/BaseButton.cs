using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Hub.Core.Buttons
{
    public abstract class BaseButton
    {
        protected readonly ILocator _locator;
        public BaseButton(ILocator locator)
        {
            _locator = locator;
        }
    }
}
