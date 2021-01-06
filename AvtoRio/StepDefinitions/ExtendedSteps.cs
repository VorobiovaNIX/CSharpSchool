﻿using NUnit.Framework;
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


    }
}