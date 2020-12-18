using System;
using TechTalk.SpecFlow;

namespace BluePrismGuide.StepDefinitions
{
    [Binding]
    public class ReturingLocationDataBasedOnCountryAndZipCodeSteps
    {
        [Given(@"the country code us and zip code (.*)")]
        public void GivenTheCountryCodeUsAndZipCode(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I request the locations corresponding to these codes")]
        public void WhenIRequestTheLocationsCorrespondingToTheseCodes()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the response contains the place name Beverly Hills")]
        public void ThenTheResponseContainsThePlaceNameBeverlyHills()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
