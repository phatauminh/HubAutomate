using Hub.Core.Decorators;
using Hub.Retailer.Common.Models.Activities;
using Hub.Retailer.Common.Pages.Activities;
using Hub.Retailer.Common.Pages.Ultilities.Popups;
using Hub.Retailer.Data.Entities;
using Hub.Retailer.Specs.Ultilities;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Hub.Retailer.Specs.Steps
{
    [Binding]
    public class ActivityMaintenanceStepDefinitions
    {
        private ActivityMaintenancePage _pageObject;
        private ModelContext _modelContext;
        private ModelManagement _modelManagement;
        private IPageDecorator _page;

        public ActivityMaintenanceStepDefinitions(IPageDecorator page, ActivityMaintenancePage login, ModelContext modelContext, ModelManagement modelManagement)
        {
            _page = page;
            _pageObject = login;
            _modelContext = modelContext;
            _modelManagement = modelManagement;
        }

        [Given(@"I prepare energy offer data")]
        public async Task GivenIPrepareEnergyOfferData(Table table)
        {
            var energyOffer = new EnergyOffer();
            table.ToModel(energyOffer);
            _modelManagement.EnergyOffer = energyOffer;
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
            var popup = new EnergyOfferPopup(_page);
            await popup.Create(_modelManagement.EnergyOffer);
        }

    }
}
