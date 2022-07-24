﻿using Hub.Core.Buttons;
using Hub.Core.Controls;
using Hub.Core.Decorators;
using Hub.Core.Ultilities;
using System.Threading.Tasks;

namespace Hub.Retailer.Common.Pages.Ultilities.Popups
{
    public abstract class BasePopup
    {
        protected readonly IPageDecorator _page;

        public BasePopup(IPageDecorator page)
        {
            _page = page;
        }
        protected string FrameSelector => $"//iframe[@title='{Title}']";

        public abstract string Title { get; }

        protected TextBox GetTextBoxByLabel(string label)
        {
            var frame = _page.FrameLocator(FrameSelector).Locator("body");
            return ElementFinder.FindTextBoxByLabel(frame, label);
        }

        protected SelectList GetSelectListByLabel(string label)
        {
            var frame = _page.FrameLocator(FrameSelector).Locator("body");
            return ElementFinder.FindSelectListByLabel(frame, label);
        }

        protected async Task ClickNext()
        {
            var frame = _page.FrameLocator(FrameSelector).Locator("body");
            var controls = new NextButtonControl(frame);
            await controls.Execute();
        }
        
    }
}
