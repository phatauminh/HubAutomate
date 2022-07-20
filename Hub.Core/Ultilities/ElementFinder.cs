using Hub.Core.Controls;
using Microsoft.Playwright;

namespace Hub.Core.Ultilities
{
    public static class ElementFinder
    {
        public static SelectList FindSelectListByLabel(ILocator locator, string label, bool matchWholeWord = true)
        {
            var labelDiv = FindDisplayedLabel(locator, label, matchWholeWord);
            var selectLocator = labelDiv.Locator("//following-sibling::div").Locator("div[class^='ui-selectonemenu']");
            return new SelectList(locator, selectLocator);
        }

        public static TextBox FindTextBoxByLabel(ILocator locator, string label, bool matchWholeWord = true)
        {
            var labelDiv = FindDisplayedLabel(locator, label, matchWholeWord);
            return new TextBox(labelDiv.Locator("//following-sibling::div//input[@type='text' or @type='password']"));
        }

        public static TextBox FindTextBoxById(ILocator locator, string id)
        {
            return new TextBox(locator.Locator(id));
        }

        public static ILocator FindDisplayedLabel(ILocator locator, string label, bool matchWholeWord = true)
        {
            var xpath = string.Format(matchWholeWord ? "//label[.='{0}' or .='{0} ' or text() = '{0}' or normalize-space(.)='{0} *' or normalize-space(.)='{0}']" : "//label[starts-with(normalize-space(.),'{0}') or contains(., '{0}')][./following-sibling::div[1]/div or ./following-sibling::div[1]/input]", label.Trim());
            return locator.Locator(xpath);
        }
    }
}
