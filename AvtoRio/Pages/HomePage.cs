using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        IWebElement searchButton => _driver.FindElement(By.XPath("//button[@class='button']"));
        public ListOfCarsPage ClickOnSearchButton()
        {
            searchButton.Click();
            return new ListOfCarsPage(_driver);
        }


        public void ClickOnUnderSection(string underSection)
        {
            _driver.FindElement(By.XPath($"//nav[@class='catalog-brands boxed']//a/span[text()='{underSection}']|//nav[@class='catalog-referrals open-mobile']/a[text()='{underSection}']")).Click();
        }
        public void ClickOnTypeOfVehicle(string typeOfVehicle)
        {
            IWebElement vehicle= _driver.FindElement(By.XPath($"//nav[@class='transport-type']/a//span[text()='{typeOfVehicle}']"), 3);
            BasePage page = new BasePage(_driver);
            page.ScrollToTheElement(vehicle);
            vehicle.Click();
        }

        public void SearchByBrand(string brandName)
        {
            _driver.FindElement(By.XPath("//div[@id='brandTooltipBrandAutocomplete-brand']")).Click();
            _driver.FindElement(By.XPath($"(//ul[@class='unstyle scrollbar autocomplete-select']/li/a[text()='{brandName}'])[1]"),3).Click();
            
        }

        public void SearchByModel(string modelName)
        {
            _driver.FindElement(By.XPath("//div[@id='brandTooltipBrandAutocomplete-model']")).Click();
            _driver.FindElement(By.XPath($"(//ul[@class='unstyle scrollbar autocomplete-select']/li/a[text()='{modelName}'])[1]"), 3).Click();
        }

        public void SearchByYear(int startYear, int endYear)
        {
            SelectElement startYearField = new SelectElement(_driver.FindElement(By.XPath("//select[@id='yearFrom']")));
            SelectElement endYearField = new SelectElement(_driver.FindElement(By.XPath("//select[@id='yearTo']")));

            startYearField.SelectByText(startYear.ToString());
            endYearField.SelectByText(endYear.ToString());
        }
    }
}
