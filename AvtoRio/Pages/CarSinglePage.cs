using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvtoRio.Pages
{
    public class CarSinglePage
    {
        private readonly IWebDriver _driver;

        public CarSinglePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }


    }
}
