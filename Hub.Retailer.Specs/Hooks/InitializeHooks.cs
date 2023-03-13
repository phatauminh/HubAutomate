using BoDi;
using Hub.Core.Drivers;
using Hub.Retailer.Data.Entities;
using Hub.Retailer.Specs.Managements;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Hub.Retailer.Specs.Hooks
{
    [Binding]
    public class InitializeHooks : PlaywrightDriver
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public InitializeHooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario()]
        public async Task SetUp()
        {
            await InitalizePlaywright();

            _objectContainer.RegisterInstanceAs(Page);
        }

        [AfterScenario()]
        public async Task TearDown()
        {
            await TerminatePlaywright();
        }
    }
}

