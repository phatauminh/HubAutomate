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
        #endregion

        private TextBox StreetTextBox => GetTextBoxByLabel(LblStreet);
        private TextBox SuburbPostCodeTextBox => GetTextBoxByLabel(LblSuburbPostCode);
        private Table AddressSearchTable  => GetTable(".ui-datatable-scrollable-body");

        public override string Title => "Edit Address";

        public ServiceAddressDialog(IPageDecorator page) : base(page)
        {
        }

        public async Task SetAddressSearch(ServiceAddress address)
        {
            await StreetTextBox.SetValue(address.StreetName);
            await SuburbPostCodeTextBox.SetValue(address.Postcode);
            var searchBtn = GetButtonBySpan(LblSearchButton);
            await searchBtn.Click();
            await SelectServiceAddress();
        }

        private async Task SelectServiceAddress()
        {
            var listAddressSearch = await AddressSearchTable.GetAllBody();

            foreach (var item in listAddressSearch)
            {
                var fullAddress = item.Split("|")[0];

                if (fullAddress.Split(",").Count(c => c == ",") > 1)
                    continue;

                var address = fullAddress.Split(",")[0].Replace(fullAddress.Split(",")[0].Split(" ").Last(), "").Trim();
                var postcode = fullAddress.ToString().Split(" ").Last();

                var serviceAddress = new ServiceAddress()
                {
                    Address = address,
                    Postcode = postcode
                };

                var isAddressLinkToCustomer = await QueryHelper.IsAddressLinkedToCustomersInSystem(serviceAddress);

                if (!isAddressLinkToCustomer)
                {
                    
                }
            }

        }
        public async Task SetManualOverride(ServiceAddress address)
        {

        }
   

    }
}
