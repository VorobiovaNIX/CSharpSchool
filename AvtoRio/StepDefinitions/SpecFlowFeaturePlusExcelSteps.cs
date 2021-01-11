using System;
using TechTalk.SpecFlow;

namespace AvtoRio.StepDefinitions
{
    [Binding]
    public class SpecFlowFeaturePlusExcelSteps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(string p0)
        {
            Console.WriteLine("Number ", p0);
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            Console.WriteLine("Adding the values");
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(string p0)
        {
            Console.WriteLine("Result ", p0);
        }
    }
}
