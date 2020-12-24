using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AvtoRio.StepDefinitions
{
    [Binding]
    public class FilteringInSearchPageSteps: BasePage
    {
        
        [Given(@"I go to the web page '(.*)'")]
        public void GivenIGoToTheWebPage(string webpage)
        {
            driver.Navigate().GoToUrl(webpage);
        }

        [Given(@"the web page is opened '(.*)'")]
        public void GivenTheWebPageIsOpened(string title)
        {
            Assert.That(driver.Title.Contains( title));
        }
        
        [When(@"I click on '(.*)' button")]
        public void WhenIClickOnButton(string nameButton)
        {
            //IWebElement button = driver.FindElement(By.XPath($"//*[@id='mainSearchForm']//span[text()='{nameButton}']"));
            button.Click();
        }
        
        [When(@"I fill in filtering fields")]
        public void WhenIFillInFilteringFields(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the web page is opened '(.*)'")]
        public void ThenTheWebPageIsOpened(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I see searching result page")]
        public void ThenISeeSearchingResultPage(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
