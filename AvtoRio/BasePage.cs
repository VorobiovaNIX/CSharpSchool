using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Compatibility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;

namespace AvtoRio
{
    public class BasePage
    {

        public static IWebDriver driver = new ChromeDriver();

        //public static string searchButton = "//*[@id='mainSearchForm']//span[text()='Розширений пошук']";

       public WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

        public static void switchToFrameByXPath(string xpath)
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath(xpath)));
        }

        public static void switchToFrameByName(string frameName)
        {
            driver.SwitchTo().Frame(frameName);
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
    }
}
