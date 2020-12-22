using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowAndNUnitSchool.StepDefinitions
{
    [Binding]
    public class GoogleSearchFeatureSteps
    {
        IWebDriver driver;
        [Given(@"I navigate to the page (.*)")]
        public void GivenINavigateToThePage(string page)
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(page);
        }
        
        [Given(@"I see the page is loaded")]
        public void GivenISeeThePageIsLoaded()
        {
            Assert.AreEqual("Google", driver.Title);
        }
        
        [When(@"I enter Search Keyword in the Search Text box")]
        public void WhenIEnterSearchKeywordInTheSearchTextBox(Table table)
        {
            string searchText = table.Rows[0]["Keyword"].ToString();
            driver.FindElement(By.Name("q")).SendKeys(searchText);
        }
        
        [When(@"I click on Search Button")]
        public void WhenIClickOnSearchButton()
        {
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(45));
            webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector("li.sbct:nth-child(1)"))); 
            driver.FindElement(By.Name("btnK")).Click();
        }
        
        [Then(@"Search items shows the items related to (.*)")]
        public void ThenSearchItemsShowsTheItemsRelatedToSubject(string subject)
        {
            IWebElement result = driver.FindElement(By.XPath("//div[@class='rc']//a[@href='https://specflow.org/']"));
           // Assert.IsTrue(subject.Contains(result.Text));
            Assert.That(result.Text.Contains(subject));
        }
    }
}
