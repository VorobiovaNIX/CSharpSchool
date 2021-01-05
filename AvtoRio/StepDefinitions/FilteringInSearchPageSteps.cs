using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AvtoRio.StepDefinitions
{
    [Binding]
    public class FilteringInSearchPageSteps: BasePage
    {
        //IWebDriver driver;
        [Given(@"I go to the web page '(.*)'")]
        public void GivenIGoToTheWebPage(string webpage)
        {
            //driver = new ChromeDriver();
            driver.Navigate().GoToUrl(webpage);
            driver.Manage().Window.Maximize();
        }

        [Then(@"the web page is opened '(.*)'")]
        public void GivenTheWebPageIsOpened(string title)
        {
            Assert.That(driver.Title.Contains( title));
        }
        
        [When(@"I click on '(.*)' button")]
        public void WhenIClickOnButton(string nameButton)
        {
            IWebElement button = driver.FindElement(By.XPath($"//*[@id='mainSearchForm']//span[text()='{nameButton}']"));
            button.Click();
        }
        
        [When(@"I fill in filtering fields")]
        public void WhenIFillInFilteringFields(Table table)
        {
            string brandCar = table.Rows[0]["Brand"];
            driver.FindElement(By.XPath("//div[@id='autocomplete-brand-0']/label"),3).Click();

            //CarDetails details = table.CreateInstance<CarDetails>();
            // driver.FindElement(By.XPath("//div[@id='autocomplete-brand-0']/input")).SendKeys(details.Brand);

            //var details = table.CreateSet<CarDetails>();
            //foreach (CarDetails car in details)
            //{
            //    Console.WriteLine(car.Brand);
            //    Console.WriteLine(car.Model);
            //    Console.WriteLine(car.StartYear);
            //    Console.WriteLine(car.EndYear);
            //}
            
            driver.FindElement(By.XPath($"(//ul[@class='unstyle scrollbar autocomplete-select']/li/a[text()='{brandCar}'])[1]")).Click();

            string modelCar = table.Rows[0]["Model"];
            driver.FindElement(By.XPath("//label[@data-text='Оберіть модель']")).Click();
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds());
            driver.FindElement(By.XPath($"//ul[contains(@class,'autocomplete-select check_list')]/li/a[text()='{modelCar}']")).Click();

            string startYearCar = table.Rows[0]["StartYear"];
            SelectElement selectStartYear = new SelectElement(driver.FindElement(By.XPath("//div/select[@id='at_year-from']"),5));
            selectStartYear.SelectByText(startYearCar);

            string endYearCar = table.Rows[0]["EndYear"];
            SelectElement selectEndYear = new SelectElement(driver.FindElement(By.XPath("//div/select[@id='at_year-to']")));
            selectEndYear.SelectByText(endYearCar);


        }

        [When(@"I click on Пошук button")]
        public void WhenIClickOnButton()
        {
            IWebElement button = driver.FindElement(By.XPath("//button[@class='button small']"));
            button.Click();
        }


        [Then(@"I see searching result page")]
        public void ThenISeeSearchingResultPage(Table table)
        {
            string brandCar = table.Rows[0]["Brand"];
            string modelCar = table.Rows[0]["Model"];
            string startYearCar = table.Rows[0]["StartYear"];
            string endYearCar = table.Rows[0]["EndYear"];

            var carTitles = driver.FindElements(By.XPath(".//div[@class='item ticket-title']/a"));
            foreach (var car in carTitles)
            {
                Assert.That( car.FindElement(By.XPath("./span")).Text.Contains(brandCar +" "+ modelCar),
                    "The actual brand and model of the car is search result does not according to set filtering");

                string[] wordsInTitle = car.Text.Split(' ');
                int actualYearCar = int.Parse(wordsInTitle[wordsInTitle.Length-1]);
                Console.WriteLine(actualYearCar);
                if (actualYearCar > int.Parse(endYearCar) || actualYearCar < int.Parse(startYearCar))
                    throw new AssertionException("The actual year of the car is search result does not according to set filtering");


            }
        }
    }
}
