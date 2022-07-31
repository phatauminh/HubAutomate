using BoDi;
using Hub.Core.Drivers;
using Hub.Retailer.Data.Entities;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Hub.Retailer.Specs.Hooks
{
    [Binding]
    public class InitializeHooks : PlaywrightDriver
    {
        public ModelContext ModelContext = new ModelContext();
        public ModelManagement ModelManagement = new ModelManagement();

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
            _objectContainer.RegisterInstanceAs(ModelContext);
            _objectContainer.RegisterInstanceAs(ModelManagement);
        }

        [AfterScenario()]
        public async Task TearDown()
        {
            await TerminatePlaywright();
        }
    }
}

