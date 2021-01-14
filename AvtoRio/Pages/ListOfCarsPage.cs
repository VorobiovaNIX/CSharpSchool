using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvtoRio.Pages
{
    public class ListOfCarsPage
    {
        private readonly IWebDriver _driver;

        public ListOfCarsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }


        IWebElement sortingField => _driver.FindElement(By.XPath("//select[@id='leftFilterSortSelect']"));

        IWebElement searchBtn => _driver.FindElement(By.XPath("//a[text()='Уточнити пошук']"));

        IWebElement firstCarInList => _driver.FindElement(By.XPath("//div[@class='content-bar'][1]"));

    }
}
