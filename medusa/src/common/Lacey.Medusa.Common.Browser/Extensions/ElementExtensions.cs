using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Lacey.Medusa.Common.Browser.Extensions
{
    public static class ElementExtensions
    {
        public static IWebElement WaitUntilElementExists(
            this IWebDriver driver,
            By elementLocator, 
            int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementExists(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        //this will search for the element until a timeout is reached
        public static IWebElement WaitUntilElementVisible(
            this IWebDriver driver,
            By elementLocator, 
            int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }

        public static IWebElement WaitUntilElementClickable(
            this IWebDriver driver,
            By elementLocator, 
            int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
    }
}