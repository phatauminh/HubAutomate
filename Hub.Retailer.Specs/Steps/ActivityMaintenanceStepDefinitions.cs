using Hub.Core.Decorators;
using Hub.Retailer.Common.Enums;
using Hub.Retailer.Common.Extensions;
using Hub.Retailer.Common.Models;
using Hub.Retailer.Common.Models.Activities;
using Hub.Retailer.Common.Pages.Activities;
using Hub.Retailer.Common.Pages.Ultilities.Dialogs;
using Hub.Retailer.Specs.Managements;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Hub.Retailer.Specs.Steps
{
    [Binding]
    public class ActivityMaintenanceStepDefinitions
    {
        private ActivityMaintenancePage _pageObject;
        private ModelManagement _modelManagement;
        private ServiceManagement _serviceManagement;
        private IPageDecorator _page;

        public ActivityMaintenanceStepDefinitions(IPageDecorator page, ActivityMaintenancePage login, ModelManagement modelManagement, ServiceManagement serviceManagement)
        {
            _page = page;
            _pageObject = login;
            _modelManagement = modelManagement;
            _serviceManagement = serviceManagement;
        }

        [Given(@"I have address for state '(.*)'")]
        public void GivenIHaveAdressForState(string state)
        {

            var serviceAddress = _serviceManagement.EnergyOfferService.GetAvailableServiceAddress(state, _modelManagement.EnergyOffer.UtilityType);

            _modelManagement.EnergyOffer.ServiceAddress.StreetName = serviceAddress.StreetName;
            _modelManagement.EnergyOffer.ServiceAddress.Postcode = serviceAddress.Postcode;
            _modelManagement.EnergyOffer.ServiceAddress.State = serviceAddress.State;
        }

        [Given(@"I have offer code '(.*)'")]
        public void GivenIHaveOfferCode(string offerCode)
        {
            _modelManagement.EnergyOffer.OfferCode = offerCode;
        }

        [Given(@"I have function group '(.*)'")]
        public void GivenIHaveFunctionGroup(string functionGroup)
        {
            _modelManagement.EnergyOffer.FunctionGroup = functionGroup;
        }

        [Given(@"I have tariff '(.*)'")]
        public void GivenIHaveTariff(string tariff)
        {
            _modelManagement.EnergyOffer.Tariff = tariff;
        }

        [Given(@"I have utility type '(.*)'")]
        public void GivenIHaveUtilityType(string utilType)
        {
            var utilTypEnum = EnumExtensions.GetEnumValueFromDescription<UtilityTypeEnum>(utilType);
            _modelManagement.EnergyOffer.UtilityType = utilTypEnum;
        }

        [Given(@"I have customer type '(.*)'")]
        public void GivenIHaveCustomerType(string customerType)
        {
            var customerTypeEnum = EnumExtensions.GetEnumValueFromDescription<CustomerTypeEnum>(customerType);
            _modelManagement.EnergyOffer.CustomerType = customerTypeEnum;
        }

        [Given(@"I have meter type '(.*)'")]
        public void GivenIHaveMeterType(string meterType)
        {
            _modelManagement.EnergyOffer.MeterType = meterType;
        }

        [When(@"I go to activity maintenance")]
        public async Task WhenIGoToActivityMaintenance()
        {
            await _pageObject.GoToPage();
        }

        [When(@"I click Add button and go to activity '(.*)' '(.*)'")]
        public async Task WhenIClickAddButtonAndGoToActivity(string level1, string level2)
        {
            await _pageObject.GoToActivity(level1, level2);
        }

        [When(@"I create energy offer")]
        public async Task WhenICreateEnergyOffer()
        {
            var popup = new EnergyOfferDialog(_page);
            var decoratedEOWizard = DecorateEOWizardSamples(_modelManagement.EnergyOffer);

            await popup.Create(decoratedEOWizard);
        }

        private EnergyOfferWizard DecorateEOWizardSamples(EnergyOfferWizard energyOfferWizard)
        {
            return energyOfferWizard.DecorateSampleData();
        }
    }
}
