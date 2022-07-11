using Hub.Core.Decorators;
using System.Threading.Tasks;

namespace Hub.Retailer.Common.Pages.Activities
{
    public class ActivityMaintenancePage : BasePage
    {
        public ActivityMaintenancePage(IPageDecorator page) : base(page)
        { 
        }

        #region Menu Diaglog
        public const string Activities = "Activities";
        #endregion

        public override async Task GoToPage()
        {
            await MainMenuSection.GoToPage(Activities);
        }

        public async Task GoToActivity(string level1, string level2)
        {
            await ButtonControls.AddButtonControl.GoToActivity(level1, level2);
        }
    }
}
