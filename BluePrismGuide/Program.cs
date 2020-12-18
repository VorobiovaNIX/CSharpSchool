using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace BluePrismGuide
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://www.demoqa.com";

            driver.Quit();
        }
    }
}
