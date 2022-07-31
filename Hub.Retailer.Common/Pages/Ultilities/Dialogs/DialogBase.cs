using Hub.Core.Buttons;
using Hub.Core.Controls;
using Hub.Core.Decorators;
using Hub.Core.Ultilities;
using System.Threading.Tasks;

namespace Hub.Retailer.Common.Pages.Ultilities.Dialogs
{
    public abstract class DialogBase
    {
        protected readonly IPageDecorator _page;

        public DialogBase(IPageDecorator page)
        {
            _page = page;
        }
        protected string FrameSelector => $"//iframe[@title='{Title}']";

        public abstract string Title { get; }

        protected TextBox GetTextBoxByLabel(string text)
        {
            var frame = _page.FrameLocator(FrameSelector).Locator("body");
            return ElementFinder.FindTextBoxByLabel(frame, text);
        }


        protected SelectList GetSelectListByLabel(string text)
        {
            var frame = _page.FrameLocator(FrameSelector).Locator("body");
            return ElementFinder.FindSelectListByLabel(frame, text);
        }

        protected TextArea GetTextAreaByLabel(string text)
        {
            var frame = _page.FrameLocator(FrameSelector).Locator("body");
            return ElementFinder.FindAreaTextBoxByLabel(frame, text);
        }
        protected Button GetButtonBySpan(string text)
        {
            var frame = _page.FrameLocator(FrameSelector).Locator("body");
            return ElementFinder.FindButtonBySpan(frame, text);
        }

        protected Table GetTable(string divTable)
        {
            var frame = _page.FrameLocator(FrameSelector).Locator("body").Locator(divTable);
            return new Table(frame);
        }

        protected async Task ClickNext()
        {
            var frame = _page.FrameLocator(FrameSelector).Locator("body");
            var controls = new NextButtonControl(frame);
            await controls.Execute();
        }
    }
}
