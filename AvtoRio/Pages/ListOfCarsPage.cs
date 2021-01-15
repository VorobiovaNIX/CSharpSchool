using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void SelectSortingListBy(string sortBy)
        {
            _driver.FindElement(By.XPath("//a[@id='sortCheckedElement']")).Click();
            _driver.FindElement(By.XPath($"//a[@id='sortCheckedElement']/following-sibling::span/a[text()='{sortBy}']"), 3).Click();
        }

        public void ShouldSeeSortedListOfCarsBy(string sortBy)
        {
            Assert.AreEqual(_driver.FindElement(By.XPath("//a[@id='sortCheckedElement']")).Text, sortBy);

            SelectElement sortingField = new SelectElement(_driver.FindElement(By.XPath("//select[@id='leftFilterSortSelect']")));
            string selectedValue = sortingField.AllSelectedOptions[0].Text;

            Assert.AreEqual(selectedValue, sortBy);
        }

        public void ShouldSeePrice(int startPrice, int endPrice)
        {
            var carPrices = _driver.FindElements(By.XPath(".//div[@class='content']//span[@class='bold green size22'][1]"));
            foreach (var item in carPrices)
            {
                int actualPrice = Int32.Parse(WebDriverExtensions.RemoveWhitespace(item.Text));
                Assert.GreaterOrEqual(actualPrice, startPrice,
                    "Start price that set up on search page doesn't according to price on the list of cars");
                Assert.LessOrEqual(actualPrice, endPrice,
                    "End price that set up on search page doesn't according to price on the list of cars");
            }
        }

        public void ShouldSeeTransmission(string transmission)
        {
            foreach (var item in _driver.FindElements(By.XPath("//li/i[@class='icon-transmission']/..")))
            {
                Assert.That(item.Text.Contains(transmission));
            }
        }

        public void ShouldSeeMileageInThousandKm(int mileageInThousandKmFrom, int mileageInThousandKmTo)
        {
            foreach (var item in _driver.FindElements(By.XPath("//li/i[@class='icon-mileage']/..")))
            {
                int actualMileageInThousandKm = Int32.Parse(item.Text.Split(' ').First());

                Assert.GreaterOrEqual(actualMileageInThousandKm, mileageInThousandKmFrom,
                    "Mileage that set up on search page doesn't according to the Mileage in thousand km on the list of cars");
                Assert.LessOrEqual(actualMileageInThousandKm, mileageInThousandKmTo,
                    "Mileage that set up on search page doesn't according to the Mileage in thousand km on the list of cars");
            }
        }

        public void ShouldSeeVolume(double VolumeFrom, double VolumeTo)
        {
            foreach (var item in _driver.FindElements(By.XPath("//li/i[@class='icon-fuel']/..")))
            {
                double actualVolume = double.Parse(item.Text.Split(' ').Skip(1).First());
                Assert.GreaterOrEqual(actualVolume, VolumeFrom,
                    "Mileage that set up on search page doesn't according to the Mileage in thousand km on the list of cars");
                Assert.LessOrEqual(actualVolume, VolumeTo,
                    "Mileage that set up on search page doesn't according to the Mileage in thousand km on the list of cars");
            }
        }

        public void ShouldSeeFuel(string fuel)
        {
            foreach (var item in _driver.FindElements(By.XPath("//li/i[@class='icon-fuel']/..")))
            {
                string actualFuelWithChar = item.Text.Split(' ').First();
                string actualFuel = actualFuelWithChar.Remove(actualFuelWithChar.Length - 1);
                Assert.AreEqual(actualFuel,fuel);

            }
        }
    }
}
