using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AvtoRio.StepDefinitions
{
    [Binding]
    public class CheckingSignUpAndLogin 
    {
        private IWebDriver _driver;

        public CheckingSignUpAndLogin(IWebDriver driver)
        {
            _driver = driver;
        }
        //Three private fields to store the data across different Steps
        private string firstName; 
        private string lastName;

        [Then(@"I click the Увійти в кабінет link")]
        public void ThenIClickTheУвійтиВКабінетLink()
        {
            _driver.FindElement(By.XPath("//a/span[text()='Увійти в кабінет']")).Click();
        }

        [Then(@"I click the '(.*)' link")]
        public void ThenIClickTheLink(string nameLink)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            BasePage page = new BasePage(_driver);
            page.SwitchToFrameByName("login_frame");
            _driver.FindElement(By.XPath($"//div[@class='login-link']/a[@title='{nameLink}']"), 10).Click();
            _driver.SwitchTo().DefaultContent();

        }

        [When(@"I enter (.*), (.*) and (.*)")]
        [Scope(Tag = "SignUp")]
        public void WhenIEnterValues(string userFirstName, string userLastName, string phoneNumber)
        {
            BasePage page = new BasePage(_driver);
            page.SwitchToFrameByName("login_frame");
            _driver.FindElement(By.XPath("//input[@id='registrationform-name']"),10).SendKeys(userFirstName);
            _driver.FindElement(By.XPath("//input[@id='registrationform-second_name']")).SendKeys(userLastName);
            _driver.FindElement(By.XPath("//input[@id='registrationform-email']")).SendKeys(phoneNumber);
            _driver.SwitchTo().DefaultContent();
            firstName = userFirstName; // Using a Private Field via ScenarioContext Current in SpecFlow
            lastName = userLastName;
        }

        [When(@"I click on '(.*)' button")]
        [Scope(Tag = "SignUp")]
        public void WhenIClickOnButtonOnSignUpForm(string buttonName)
        {
            BasePage page = new BasePage(_driver);
            page.SwitchToFrameByXPath("//iframe[@id='login_frame']");
            _driver.FindElement(By.XPath($"//div/input[@value='{buttonName}']")).Click();
            _driver.SwitchTo().DefaultContent();
        }


        [Then(@"I should see (.*) message")]
        [Scope(Tag = "SignUp")]
        public void ThenISeeMessage(string result)
        {
            BasePage page = new BasePage(_driver);
            page.SwitchToFrameByName("login_frame");
            string errorMessage = _driver.FindElement(By.XPath("//div[@class='login-rows']/p[@class='error']"),2).Text;
                Assert.That(errorMessage.Contains(result));

            Console.WriteLine($"The first name and lat name are: {firstName} and {lastName}");
        }

        

        [When(@"I enter (.*) and (.*)")]
        [Scope(Tag = "Login")]
        public void WhenIEnterPhoneEmailAndPassword(string phoneOrEmail, string password)
        {
            BasePage page = new BasePage(_driver);
            page.SwitchToFrameByName("login_frame");
            _driver.FindElement(By.XPath("//input[@id='emailloginform-email']"), 10).SendKeys(phoneOrEmail);
            _driver.FindElement(By.XPath("//input[@id='emailloginform-password']")).SendKeys(password);
            _driver.SwitchTo().DefaultContent();

        }

        [When(@"I click on '(.*)' button")]
        [Scope(Tag = "Login")] //can be used also Scenario, Tag and Feature etc.
        public void WhenIClickOnButtonOnLoginForm(string buttonName)
        {
            BasePage page = new BasePage(_driver);
            page.SwitchToFrameByName("login_frame");
            _driver.FindElement(By.XPath("//div[@class='login-link']/button")).Click();
            _driver.SwitchTo().DefaultContent();
        }


        [Given(@"I login to the web application")]
        public void GivenILoginToTheWebApplication(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            BasePage page = new BasePage(_driver);
            page.SwitchToFrameByName("login_frame");
            _driver.FindElement(By.XPath("//input[@id='emailloginform-email']"), 10).SendKeys(data.PhoneOrEmail);
            _driver.FindElement(By.XPath("//input[@id='emailloginform-password']")).SendKeys(data.Password);
            _driver.SwitchTo().DefaultContent();
        }

        [Given(@"I login and enter user details")]
        public void GivenILoginAndEnterUserDetails()
        {
            //Create a column header 
            string[] colHeader = { "PhoneOrEmail", "Password" };
            string[] row = { "vorobbyova@gmail.com", "qwerty" };
            //Created a table with values 
            var table = new Table(colHeader);
            table.AddRow(row);

            // Given("I login to the web application", table); // current class should inherit Steps class (TechTalk.SpecFlow.Steps;)
        }

        [Then(@"I should see ID number '(.*)'")]
        public void ThenIShouldSeeIDNumber(string value)
        {
            Assert.That(_driver.FindElement(By.XPath("//span[@class='size13 grey mb-15']")).Text.Contains(value));
        }

    }
}
