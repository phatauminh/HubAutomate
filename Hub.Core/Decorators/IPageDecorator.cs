using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Hub.Core.Decorators
{
    public interface IPageDecorator : IPage
    {
        Task ElementScreenshotAsync(string element, string imagePath);
    }
}

