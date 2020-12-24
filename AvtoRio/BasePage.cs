using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Compatibility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvtoRio
{
    public class BasePage
    {
        public static IWebDriver driver = new ChromeDriver();

        public static IWebElement button = driver.FindElement(By.XPath($"//*[@id='mainSearchForm']//span[text()='Розширений пошук']"));


    }
}
