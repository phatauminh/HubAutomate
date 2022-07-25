using Hub.Core.Controls;
using Microsoft.Playwright;

namespace Hub.Core.Ultilities
{
    public static class ElementFinder
    {
        public static SelectList FindSelectListByLabel(ILocator locator, string text, bool matchWholeWord = true)
        {
            var labelDiv = FindDisplayedLabel(locator, text, matchWholeWord);
            var selectLocator = labelDiv.Locator("//following-sibling::div").Locator("div[class^='ui-selectonemenu']");
            return new SelectList(locator, selectLocator);
        }

        public static TextBox FindTextBoxByLabel(ILocator locator, string text, bool matchWholeWord = true)
        {
            var labelDiv = FindDisplayedLabel(locator, text, matchWholeWord);
            return new TextBox(labelDiv.Locator("//following-sibling::div//input[@type='text' or @type='password']"));
        }

        public static TextArea FindAreaTextBoxByLabel(ILocator locator, string text, bool matchWholeWord = true)
        {
            var labelDiv = FindDisplayedLabel(locator, text, matchWholeWord);
            return new TextArea(labelDiv.Locator("//following-sibling::div//textarea[@role='textbox']"));
        }

        public static Button FindButtonBySpan(ILocator locator, string text, bool matchWholeWord = true)
        {
            var btnSpan = FindButtonDisplayedSpan(locator, text, matchWholeWord);

            return new Button(btnSpan.Locator("//parent::button"));
        }

        private static ILocator FindDisplayedLabel(ILocator locator, string text, bool matchWholeWord = true)
        {
            var xpath = string.Format(matchWholeWord ? "//label[.='{0}' or .='{0} ' or text() = '{0}' or normalize-space(.)='{0} *' or normalize-space(.)='{0}']" : "//label[starts-with(normalize-space(.),'{0}') or contains(., '{0}')][./following-sibling::div[1]/div or ./following-sibling::div[1]/input]", text.Trim());
            return locator.Locator(xpath);
        }

        private static ILocator FindButtonDisplayedSpan(ILocator locator, string text, bool matchWholeWord = true)
        {
            var xpath = string.Format(matchWholeWord ? "//span[@class='ui-button-text ui-c' and normalize-space(.)='{0}']" : "//span[@class='ui-button-text ui-c' and starts-with(.,'{0}')]", text);
            return locator.Locator(xpath);
        }
    }
}
