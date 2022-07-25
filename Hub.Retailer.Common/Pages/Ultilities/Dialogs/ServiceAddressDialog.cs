using Hub.Core.Controls;
using Hub.Core.Decorators;
using Hub.Retailer.Common.Models;
using System.Threading.Tasks;

namespace Hub.Retailer.Common.Pages.Ultilities.Dialogs
{
    public class ServiceAddressDialog : DialogBase
    {
        #region
        private const string LblStreet = "Street";
        private const string LblSuburbPostCode = "Suburb/Postcode";
        private const string LblApplySelectionButton = "Apply Selection";
        private const string LblSearchButton = "Search";
        #endregion

        private TextBox StreetTextBox => GetTextBoxByLabel(LblStreet);
        private TextBox SuburbPostCodeTextBox => GetTextBoxByLabel(LblSuburbPostCode);

        public override string Title => "Edit Address";

        public ServiceAddressDialog(IPageDecorator page) : base(page)
        {
        }

        public async Task SetAddressSearch(ServiceAddress address)
        {
            await StreetTextBox.SetValue(address.StreetName);
            await SuburbPostCodeTextBox.SetValue(address.Postcode);
            var searchBtn =  GetButtonBySpan(LblSearchButton);
            await searchBtn.Click();

        }
        public async Task SetManualOverride(ServiceAddress address)
        {

        }
    }
}
