using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lacey.Medusa.Common.Browser.Utils
{
    public static class WebUtils
    {
        public static string GetHtml(string url)
        {
            var userProfile = @"c:\Users\Lacey\AppData\Local\Google\Chrome\User Data";
            var options = new ChromeOptions();
            options.AddArguments($"user-data-dir={userProfile}");
            IWebDriver driver = new ChromeDriver(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                options);
            driver.Navigate().GoToUrl(url);
            var pageSource = driver.PageSource;
            driver.Close();

            return pageSource;
        } 
    }
}