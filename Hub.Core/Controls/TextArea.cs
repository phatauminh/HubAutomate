using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Hub.Core.Controls
{
    public class TextArea : BaseControl
    {
        #region Seletors
        private readonly string PencilIconSelector = "//ancestor::div//button[contains(@id,'_dlgBtn_')]";
        #endregion

        private readonly ILocator _locator;
        public TextArea(ILocator locator)
        {
            _locator = locator;
        }

        public override async Task<string> GetValue()
        {
            return await _locator.InputValueAsync();
        }

        public override async Task SetValue(string value)
        {
            await _locator.FillAsync(value);
        }

        public async Task LaunchEditDialog()
        {
            await _locator.Locator(PencilIconSelector).ClickAsync();
        }
    }
}
