
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AvtoRio.Hooks
{
    [Binding]
    public sealed class Hooks 
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks


        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void CreateWebDriver()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            ScenarioContext.Current.Add("currentDriver", _driver);
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [BeforeTestRun]
        public static void BeforeRunTest() {

        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            //TODO: implement logic that has to run before executing each scenario
            Console.WriteLine("Calling before Feature");
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
            Console.WriteLine("Calling before scenario");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            Console.WriteLine("Calling after scenario");
            var featureTitle = FeatureContext.Current.FeatureInfo.Title;
            var scenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;
            var scenarioTag = ScenarioContext.Current.ScenarioInfo.Tags;

            Console.WriteLine($"FeatureTitle: {featureTitle} and ScenarioTitle = {scenarioTitle} with scenarioTag {scenarioTag}");
            _driver = _objectContainer.Resolve<IWebDriver>();
            _driver.Close();
            _driver.Dispose();
            _driver.Quit();
        }

        [AfterStep]
        public void AfterStep()
        {
            var stepInfo = ScenarioContext.Current.StepContext.StepInfo.Text;
            Console.WriteLine($"Step: {stepInfo}");
        }
        [AfterFeature]
        public static void AfterFeature()
        {
        }

        [TearDown]
        public void CleanUp()
        {
            
            //_driver.Quit();
        }
    }
}
