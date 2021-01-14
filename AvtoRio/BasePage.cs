using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Compatibility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace AvtoRio
{
    public class BasePage
    {
        private IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

       // public IJavaScriptExecutor js = _driver as IJavaScriptExecutor;


        public void SwitchToFrameByXPath(string xpath)
        {
            _driver.SwitchTo().Frame(_driver.FindElement(By.XPath(xpath)));
        }

        public void SwitchToFrameByName(string frameName)
        {
            _driver.SwitchTo().Frame(frameName);
        }

        public void ScrollToTheElement(IWebElement webElement)
        {
            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
        }

        public void Wait(int seconds)
        {
            //public WebDriverWait i = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);

        }

    }

    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
