using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hub.Core.Controls
{
    public class Button
    {
        #region Seletors

        #endregion

        private readonly ILocator _locator;
        public Button(ILocator locator)
        {
            _locator = locator;
        }

        public async Task Click()
        {
            await _locator.ClickAsync();
        }
    }
}
