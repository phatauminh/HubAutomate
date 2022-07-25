using Hub.Core.Decorators;
using Hub.Retailer.Common.Models;
using Hub.Retailer.Common.Models.Activities;
using Hub.Retailer.Common.Pages.Activities;
using Hub.Retailer.Common.Pages.Ultilities.Dialogs;
using Hub.Retailer.Data.Entities;
using Hub.Retailer.Specs.Ultilities;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void GivenIPrepareEnergyOfferData(Table table)
        {
            var serviceAddress = GenerateTASAddress();
            var energyOffer = new EnergyOffer();

            table.ToModel(energyOffer);
            _modelManagement.EnergyOffer = energyOffer;
            _modelManagement.EnergyOffer.ServiceAddress = new ServiceAddress
            {
                StreetName = serviceAddress.Item1,
                Postcode = serviceAddress.Item2
            };
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
            await popup.Create(_modelManagement.EnergyOffer);
        }

        //Work around
        private static Tuple<string, string> GenerateTASAddress()
        {
            List<Tuple<string, string>> address = new List<Tuple<string, string>>(){
                        new Tuple<string, string>("GULL", "7307"),
                        new Tuple<string, string>("HULL", "7315"),
                        new Tuple<string, string>("BORDIN", "7250"),
                        new Tuple<string, string>("WADLEY", "7248"),
                        new Tuple<string, string>("Notley", "7248"),
                        new Tuple<string, string>("Lawson", "7248"),
                        new Tuple<string, string>("Pearce", "7250"),
                        new Tuple<string, string>("Seaview", "7109"),
                        new Tuple<string, string>("GALVINATE", "7249"),
                        new Tuple<string, string>("Harrington", "7000"),
                        new Tuple<string, string>("Watchorn", "7000"),
                        new Tuple<string, string>("Malabar", "7250"),
                        new Tuple<string, string>("Main", "7300"),
                        new Tuple<string, string>("Main", "7302"),
                        new Tuple<string, string>("Clarence", "7250"),
                        new Tuple<string, string>("AUGUSTA", "7008"),
                        new Tuple<string, string>("Wignall", "7000"),
                        new Tuple<string, string>("Strahan", "7000"),
                        new Tuple<string, string>("George", "7000"),
                        new Tuple<string, string>("Wellington", "7000"),
                        new Tuple<string, string>("Park", "7015"),
                        new Tuple<string, string>("RICHARD", "7250"),
                        new Tuple<string, string>("Wallace", "7248"),
                        new Tuple<string, string>("Kingfish Beach", "7109"),
                        new Tuple<string, string>("Viewbank", "7248"),
                        new Tuple<string, string>("GALVIN", "7249"),
                        new Tuple<string, string>("Brisbane", "7000"),
                        new Tuple<string, string>("Victoria", "7000"),
                        new Tuple<string, string>("Yollar", "7250"),
                        new Tuple<string, string>("Skemp", "7250"),
                        new Tuple<string, string>("Smith", "7000"),
                        new Tuple<string, string>("Adelaide", "7250"),
                        new Tuple<string, string>("Barrack", "7000"),
                        new Tuple<string, string>("Erina", "7250"),
                        new Tuple<string, string>("Bonella", "7250"),
                        new Tuple<string, string>("Frederick", "7250"),
                        new Tuple<string, string>("David", "7250"),
                        new Tuple<string, string>("Arthur", "7250"),
                        new Tuple<string, string>("Mount Hull", "7012"),
                        new Tuple<string, string>("Smith", "7330"),
                        new Tuple<string, string>("Abbott", "7250"),
                        new Tuple<string, string>("Hill", "7000"),
                        new Tuple<string, string>("Leonard", "7009"),
                        new Tuple<string, string>("RENFERN", "7250"),
                        new Tuple<string, string>("Tasman", "7250"),
                        new Tuple<string, string>("Clare", "7008"),
                        new Tuple<string, string>("Flinstone", "7030"),
                        new Tuple<string, string>("Barnett", "7321"),
                        new Tuple<string, string>("Wallace", "7030"),
                        new Tuple<string, string>("Wallace", "7215"),
                        new Tuple<string, string>("Gull", "7321"),
                        new Tuple<string, string>("Westbury", "7310"),
                        new Tuple<string, string>("Hill", "7325"),
                        new Tuple<string, string>("Gull", "7307"),
                        new Tuple<string, string>("Hull", "7315"),
                        new Tuple<string, string>("Nell", "7315"),
                        new Tuple<string, string>("Flinstone Drive", "7030"),
                        new Tuple<string, string>("Nell", "7315"),

            };
            return address.ElementAt(new Random().Next(address.Count()));
        }
    }
}
