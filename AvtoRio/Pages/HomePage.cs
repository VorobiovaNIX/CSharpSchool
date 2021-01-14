using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvtoRio.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }


        IWebElement advancedSearchButton => _driver.FindElement(By.XPath("//*[@id='mainSearchForm']//span[text()='Розширений пошук']"));
        public FilteringPage ClickOnAdvancedSearch()
        {
            advancedSearchButton.Click();
            return new FilteringPage(_driver);
        }
    }
}
