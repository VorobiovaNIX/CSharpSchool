using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvtoRio.Pages
{
    public class FilteringPage
    {
        private readonly IWebDriver _driver;

        public FilteringPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        IWebElement brandField => _driver.FindElement(By.XPath("//div[@id='autocomplete-brand-0']/label"), 3);
        public void SelectBrandField(string brandCarName )
        {
            brandField.Click();
            _driver.FindElement(By.XPath($"(//ul[@class='unstyle scrollbar autocomplete-select']/li/a[text()='{brandCarName}'])[1]")).Click();

        }

        IWebElement modelField => _driver.FindElement(By.XPath("//label[@data-text='Оберіть модель']"), 3);
        public void SelectModelField(string modelCarName)
        {
            modelField.Click();
            _driver.FindElement(By.XPath($"//ul[contains(@class,'autocomplete-select check_list')]/li/a[text()='{modelCarName}']"), 5).Click();
        }

        public void SelectStartYear(string startYearCar)
        {
            SelectElement selectStartYear = new SelectElement(_driver.FindElement(By.XPath("//div/select[@id='at_year-from']"), 5));
            selectStartYear.SelectByText(startYearCar);
        }

        public void SelectEndYear(string endYearCar)
        {
            SelectElement selectEndYear = new SelectElement(_driver.FindElement(By.XPath("//div/select[@id='at_year-to']")));
            selectEndYear.SelectByText(endYearCar);
        }

        //Classical way of initializing Pages via POM concept - Until Selenium 3.10.0
        [FindsBy(How = How.XPath, Using = "//div[@class='item ticket-title']/a")]
        public IList<IWebElement> carTitles { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='rows']/label[text()='Кількість дверей']/..//input[1]")]
        public IWebElement numberOfDoorsFrom { get; set; }

        [FindsBy(How=How.XPath,Using = "//div[@class='rows']/label[text()='Кількість дверей']/..//input[2]")]
        public IWebElement numberOfDoorsTo { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='rows']/label[text()='Кількість місць']/..//input[1]")]
        public IWebElement numberOfSeatsFrom { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='rows']/label[text()='Кількість місць']/..//input[2]")]
        public IWebElement numberOfSeatsTo { get; set; }


        //List<IWebElement> carTitles => _driver.FindElements(By.XPath(".//div[@class='item ticket-title']/a")).ToList();

        public void SelectTypeOfVehicle(string typeOfVehicle)
        {
            SelectElement selectTypeOfVehicle = new SelectElement(_driver.FindElement(By.XPath("//select[@aria-label='Тип транспорту']")));
            selectTypeOfVehicle.SelectByText(typeOfVehicle);
        }

        public void SelectProducingCountry(string producingCountry)
        {
            SelectElement selectProducingCountry = new SelectElement(_driver.FindElement(By.XPath("//select[@id='at_country']")));
            selectProducingCountry.SelectByText(producingCountry);
        }

        public void SelectBodyType(string bodyType)
        {
            try
            {
                _driver.FindElement(By.XPath($"//div[@class='indent']//div[@class='boxed checked-list three-col']/label[text()=' {bodyType}']")).Click();
            }
            catch (NoSuchElementException)
            {
                _driver.FindElement(By.XPath("//label[text()='Інші типи кузову']"), 5).Click();
                BasePage page = new BasePage(_driver);
                page.Wait(10);
                _driver.FindElement(By.XPath($"//div[@class='indent']//div[@class='boxed checked-list']/label[text()=' {bodyType}']"), 20).Click();
            }
        }

        public void EnterStartPriceField(string startPrice)
        {
            _driver.FindElement(By.XPath("//div[@class='item-two-el']/input[@id='at_price-from']"), 3).SendKeys(startPrice);
        }
        public void EnterEndPriceField(string endPrice)
        {
            _driver.FindElement(By.XPath("//div[@class='item-two-el']/input[@id='at_price-to']")).SendKeys(endPrice);
        }

        public void SelectFuelField(string fuel)
        {
            IWebElement fuelField = _driver.FindElement(By.XPath($"//label[text()='{fuel}']"));
            BasePage page = new BasePage(_driver);
            page.ScrollToTheElement(fuelField);
            fuelField.Click();
        }

        public void SelectTransmission(string transmission)
        {
            IWebElement transmissionField = _driver.FindElement(By.XPath($"//label[text()='{transmission}']"));
            BasePage page = new BasePage(_driver);
            page.ScrollToTheElement(transmissionField);
            transmissionField.Click();
        }

        public void SelectVolume(string volumeFrom, string volumeTo)
        {
            _driver.FindElement(By.XPath($"//div[@id='volumeBlock']//input[1]")).SendKeys(volumeFrom);
            _driver.FindElement(By.XPath($"//div[@id='volumeBlock']//input[2]")).SendKeys(volumeTo);
        }

        public void SelectHorsePower(string horsePowerFrom, string horsePowerTo)
        {
            _driver.FindElement(By.XPath($"//div[@class='rows']/label[text()='Потужність']/..//input[1]")).SendKeys(horsePowerFrom);
            _driver.FindElement(By.XPath($"//div[@class='rows']/label[text()='Потужність']/..//input[2]")).SendKeys(horsePowerTo);
        }
        public void SelectMileageInThousandKm(string mileageInThousandKmFrom, string mileageInThousandKmTo)
        {
            _driver.FindElement(By.XPath($"//div[@class='rows']/label[text()='Пробіг, тис. км']/..//input[1]")).SendKeys(mileageInThousandKmFrom);
            _driver.FindElement(By.XPath($"//div[@class='rows']/label[text()='Пробіг, тис. км']/..//input[2]")).SendKeys(mileageInThousandKmTo);
        }


        IWebElement searchButton => _driver.FindElement(By.XPath("//button[@class='button small']"));
        public ListOfCarsPage ClickSearch()
        {
            searchButton.Click();
            return new ListOfCarsPage(_driver);
        }

       
    }
}
