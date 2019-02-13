using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lacey.Medusa.Common.Browser.Browsers
{
    public sealed class ChromeBrowser : IDisposable
    {
        public ChromeBrowser()
        {
            var userProfile = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) +
                              @"Users\" + 
                              Environment.UserName +
                              @"\AppData\Local\Google\Chrome\User Data";
            var options = new ChromeOptions();
//            options.AddArgument("headless");
            options.AddArgument("no-sandbox");
            options.AddArgument("disable-dev-shm-usage");
            options.AddArgument("start-maximized");

            options.AddArguments($"user-data-dir={userProfile}");
            this.Driver = new ChromeDriver(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                options);
        }

        public IWebDriver Driver { get; }

        public string GetPageSource(string url)
        {
            this.Driver.Navigate().GoToUrl(url);
            return this.Driver.PageSource;
        }

        public void Dispose()
        {
            this.Driver.Quit();
            this.Driver.Dispose();
        }
    }
}