using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AvtoRio
{
    [Binding]
    public sealed class TestFixture :BasePage
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

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
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            driver.Quit();
        }

    }
}
