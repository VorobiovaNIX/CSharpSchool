using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SpecFlowAndNUnitSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://www.demoqa.com";
        }
    }
}
