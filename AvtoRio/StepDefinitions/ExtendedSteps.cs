using AvtoRio.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AvtoRio.StepDefinitions
{
    [Binding]
    public class ExtendedSteps
    {

        public readonly CarDetails Car;

        //public ExtendedSteps(CarDetails car)
        //{
        //    this.Car = car;
        //}
        private IWebDriver _driver;
        public ExtendedSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Then(@"I should get the same value from Extended steps")]
        public void ThenIShouldGetTheSameValueFromExtendedSteps()
        {
            Console.WriteLine(Car.TypeOfVehicle);
            Console.WriteLine(Car.BodyType);
            Console.WriteLine(Car.ProducingCountry);
            

            string actualBodyType = _driver.FindElement(By.XPath("//div[@class='box-panel description-car']//dd[1]")).Text;
            Assert.AreEqual(Car.BodyType, actualBodyType);

        }

        [When(@"I open '(.*)' item in list of cars")]
        public void WhenIOpenItemInListOfCars(int indexOfCarInList)
        {
            IEnumerable<IWebElement> carTitles = _driver.FindElements(By.XPath(".//div[@class='item ticket-title']/a"));
            carTitles.ElementAt(indexOfCarInList-1).Click();
            BasePage page = new BasePage(_driver);
            page.Wait(10);
        }



    }
}
