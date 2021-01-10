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
    public class ExtendedSteps:BasePage
    {

        public readonly CarDetails Car;

        public ExtendedSteps(CarDetails car)
        {
            this.Car = car;
        }

        [Then(@"I should get the same value from Extended steps")]
        public void ThenIShouldGetTheSameValueFromExtendedSteps()
        {
            Console.WriteLine(Car.TypeOfVehicle);
            Console.WriteLine(Car.BodyType);
            Console.WriteLine(Car.ProducingCountry);

            IEnumerable<IWebElement> carTitles = driver.FindElements(By.XPath(".//div[@class='item ticket-title']/a"));
            carTitles.ElementAt(0).Click();
            wait(10);

            string actualBodyType = driver.FindElement(By.XPath("//div[@class='box-panel description-car']//dd[1]")).Text;
            Assert.AreEqual(Car.BodyType, actualBodyType);

        }

        [Then(@"I see searching result page by price")]
        public void ThenISeeSearchingResultPageByPrice()
        {
            Console.WriteLine(Car.StartPrice);
            Console.WriteLine(Car.EndPrice);

            var carTitles = driver.FindElements(By.XPath(".//div[@class='content']//span[@class='bold green size22'][1]"));
            foreach (var item in carTitles)
            {
                int actualPrice = Int32.Parse(WebDriverExtensions.RemoveWhitespace(item.Text));
                Assert.GreaterOrEqual(actualPrice, Car.StartPrice,
                    "Start price that set up on search page doesn't according to price on the list of cars");
                Assert.LessOrEqual(actualPrice, Car.EndPrice,
                    "End price that set up on search page doesn't according to price on the list of cars");
            }

        }


    }
}
