using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lacey.Medusa.Common.Browser.Browsers
{
    public sealed class ChromeBrowser : IDisposable
    {
        private readonly IWebDriver driver;

        public ChromeBrowser()
        {
            var userProfile = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) +
                              @"Users\" + 
                              Environment.UserName +
                              @"\AppData\Local\Google\Chrome\User Data";
            var options = new ChromeOptions();
            options.AddArguments("headless");
            options.AddArguments("no-sandbox");
            options.AddArguments("disable-dev-shm-usage");
            options.AddArguments($"user-data-dir={userProfile}");
            this.driver = new ChromeDriver(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                options);
        }


        public string GetPageSource(string url)
        {
            this.driver.Navigate().GoToUrl(url);
            return this.driver.PageSource;
        }

        public void Dispose()
        {
            this.driver.Quit();
            this.driver.Dispose();
        }
    }
}