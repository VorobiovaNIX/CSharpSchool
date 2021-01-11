using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AvtoRio.StepDefinitions
{
    [Binding]
    public class CheckingSignUpAndLogin : BasePage
    {
        //Three private fields to store the data across different Steps
        private string firstName; 
        private string lastName;

        [Then(@"I click the Увійти в кабінет link")]
        public void ThenIClickTheУвійтиВКабінетLink()
        {
            driver.FindElement(By.XPath("//a/span[text()='Увійти в кабінет']")).Click();
        }

        [Then(@"I click the '(.*)' link")]
        public void ThenIClickTheLink(string nameLink)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            switchToFrameByName("login_frame");
            driver.FindElement(By.XPath($"//div[@class='login-link']/a[@title='{nameLink}']"), 10).Click();
            driver.SwitchTo().DefaultContent();

        }

        [When(@"I enter (.*), (.*) and (.*)")]
        [Scope(Tag = "SignUp")]
        public void WhenIEnterValues(string userFirstName, string userLastName, string phoneNumber)
        {
            switchToFrameByName("login_frame");
            driver.FindElement(By.XPath("//input[@id='registrationform-name']"),10).SendKeys(userFirstName);
            driver.FindElement(By.XPath("//input[@id='registrationform-second_name']")).SendKeys(userLastName);
            driver.FindElement(By.XPath("//input[@id='registrationform-email']")).SendKeys(phoneNumber);
            driver.SwitchTo().DefaultContent();
            firstName = userFirstName; // Using a Private Field via ScenarioContext Current in SpecFlow
            lastName = userLastName;
        }

        [When(@"I click on '(.*)' button")]
        [Scope(Tag = "SignUp")]
        public void WhenIClickOnButtonOnSignUpForm(string buttonName)
        {
            switchToFrameByXPath("//iframe[@id='login_frame']");
            driver.FindElement(By.XPath($"//div/input[@value='{buttonName}']")).Click();
            driver.SwitchTo().DefaultContent();
        }


        [Then(@"I should see (.*) message")]
        [Scope(Tag = "SignUp")]
        public void ThenISeeMessage(string result)
        {
            switchToFrameByName("login_frame");
            string errorMessage = driver.FindElement(By.XPath("//div[@class='login-rows']/p[@class='error']"),2).Text;
                Assert.That(errorMessage.Contains(result));

            Console.WriteLine($"The first name and lat name are: {firstName} and {lastName}");
        }

        

        [When(@"I enter (.*) and (.*)")]
        [Scope(Tag = "Login")]
        public void WhenIEnterPhoneEmailAndPassword(string phoneOrEmail, string password)
        {
            switchToFrameByName("login_frame");
            driver.FindElement(By.XPath("//input[@id='emailloginform-email']"), 10).SendKeys(phoneOrEmail);
            driver.FindElement(By.XPath("//input[@id='emailloginform-password']")).SendKeys(password);
            driver.SwitchTo().DefaultContent();

        }

        [When(@"I click on '(.*)' button")]
        [Scope(Tag = "Login")] //can be used also Scenario, Tag and Feature etc.
        public void WhenIClickOnButtonOnLoginForm(string buttonName)
        {
            switchToFrameByName("login_frame");
            driver.FindElement(By.XPath("//div[@class='login-link']/button")).Click();
            driver.SwitchTo().DefaultContent();
        }


    }
}
