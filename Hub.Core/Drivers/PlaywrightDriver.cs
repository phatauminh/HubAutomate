using Hub.Core.Decorators;
using Hub.Core.Models;
using Hub.Core.Services;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Threading.Tasks;

namespace Hub.Core.Drivers
{
    public class PlaywrightDriver : PageTest
    {
        private static readonly BaseSettings Configuration = ConfigurationService.GetBaseSettings();

        public static IPageDecorator Page { get; set; }

        public static IBrowserContext BrowserContext { get; set; }

        protected bool IsScreenshotToggleOn => Configuration.PlaywrightSettings.ScreenshotSettings.IsToggleOn;

        protected string ScreenshotDirectory => Configuration.PlaywrightSettings.ScreenshotSettings.StoredDirectory;

        public BrowserTypeLaunchOptions ChromeOptions = new BrowserTypeLaunchOptions()
        {
            Headless = Configuration.PlaywrightSettings.Headless,
            SlowMo = Configuration.PlaywrightSettings.SlowMo
        };

        public BrowserTypeLaunchOptions FirefoxOptions = new BrowserTypeLaunchOptions()
        {
            Headless = Configuration.PlaywrightSettings.Headless,
            SlowMo = Configuration.PlaywrightSettings.SlowMo
        };

        public BrowserTypeLaunchOptions SafariOptions = new BrowserTypeLaunchOptions()
        {
            Headless = Configuration.PlaywrightSettings.Headless,
            SlowMo = Configuration.PlaywrightSettings.SlowMo
        };

        public async Task<IPageDecorator> InitalizePlaywright()
        {
            var browserType = Configuration.BrowserType;

            IBrowser browser = browserType.ToLower() switch
            {
                "chrome" => await Playwright.Chromium.LaunchAsync(ChromeOptions),
                "firefox" => await Playwright.Firefox.LaunchAsync(FirefoxOptions),
                "safari" => await Playwright.Firefox.LaunchAsync(FirefoxOptions),
                _ => throw new ArgumentException($"The parameter for 'Browser' is not correct, please provide Chrome, Firefox or Safari."),
            };

            BrowserNewContextOptions options = null;

            if (Configuration.PlaywrightSettings.RecordSettings.IsToggleOn)
            {
                options = new BrowserNewContextOptions
                {
                    RecordVideoDir = Configuration.PlaywrightSettings.RecordSettings.StoredDirectory,
                };
            }

            BrowserContext = await browser.NewContextAsync(options);

            var page = await BrowserContext.NewPageAsync();

            var pageDecorator = new PageDecorator(page);

            return pageDecorator;
        }
    }

}

