using Hub.Core.Controls;
using Hub.Core.Decorators;
using Hub.Retailer.Common.Models;
using Hub.Retailer.Data.Services;
using System.Linq;
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
        private const string LblSelectButton = "Select";
        #endregion

        private TextBox StreetTextBox => GetTextBoxByLabel(LblStreet);
        private TextBox SuburbPostCodeTextBox => GetTextBoxByLabel(LblSuburbPostCode);
        private Table AddressSearchTable => GetTable(".ui-datatable-scrollable-body");

        public override string Title => "Edit Address";

        public ServiceAddressDialog(IPageDecorator page) : base(page)
        {
        }

        public async Task SelectServiceAddress(ServiceAddress model)
        {
            await StreetTextBox.SetValue(model.StreetName);
            await SuburbPostCodeTextBox.SetValue(model.Postcode);

            var searchBtn = GetButtonBySpan(LblSearchButton);
            await searchBtn.Click();

            var listAddressSearch = await AddressSearchTable.GetAllBody();

            for (int i = 0; i < listAddressSearch.Count; i++)
            {
                var fullAddress = listAddressSearch[i].Split("|");

                var address = fullAddress[0];
                var postCode = fullAddress[1];

                var serviceAddress = new ServiceAddress()
                {
                    Address = address.Split(",")[0].Replace(address.Split(",")[0].Split(" ").Last(), "").Trim(),
                    Postcode = postCode
                };

                var isAddressLinkToCustomer = await QueryHelper.IsAddressLinkedToCustomersInSystem(serviceAddress);

                if (!isAddressLinkToCustomer)
                {
                    var row = AddressSearchTable.GetRowByIndex(i);
                    await row.ClickOnRow();
                    break;
                }
            }

            var applySelectionBtn = GetButtonBySpan(LblApplySelectionButton);
            await applySelectionBtn.Click();

            var selectBtn = GetButtonBySpan(LblSelectButton);
            await selectBtn.Click();
        }
        public async Task SetManualOverride(ServiceAddress address)
        {

        }


    }
}
