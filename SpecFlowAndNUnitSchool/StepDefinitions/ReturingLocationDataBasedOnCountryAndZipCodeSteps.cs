using System;
using TechTalk.SpecFlow;

namespace SpecFlowAndNUnitSchool.StepDefinitions
{
    [Binding]
    public class ReturingLocationDataBasedOnCountryAndZipCodeSteps
    {
        [Given(@"the country code (us|ca) and zip code (\d+)")]
        public void GivenTheCountryCodeUsAndZipCode(String countyCode, int zipcode)
        {
            
        }
        
        
        [When(@"I request the locations? corresponding to these codes")]
        public void WhenIRequestTheLocationsCorrespondingToTheseCodes()
        {
            
        }
        
        [Then(@"the response contains the place name (.*)")]
        public void ThenTheResponseContainsThePlaceName(string place)
        {
            
        }

        [Then(@"the response contains exactly (.*) location")]
        public void ThenTheResponseContainsExactlyLocation(int p0)
        {
           
        }

        [Given(@"Susan wants to add the following places for de zip code (.*)")]
        public void GivenSusanWantsToAddTheFollowingPlacesForDeZipCode(int p0, Table table)
        {
            
        }

        [When(@"she submits the required data")]
        public void WhenSheSubmitsTheRequiredData()
        {
            
        }

        [Then(@"s?he should receive a reply indicating (success|failure)")]
        public void ThenSheShouldReceiveAReplyIndicating(string param)
        {
            
        }

        [Given(@"country code de and zip code (.*)")]
        public void GivenCountryCodeDeAndZipCode(int p0)
        {
            
        }

        [Then(@"the following places are returned")]
        public void ThenTheFollowingPlacesAreReturned(Table expectedPlaces)
        {
            //LocationResponse locationResponse = new JsonDeserializer().Deserialize<LocationResponse>(response);

            //expectedPlaces.CompareToSet<Place>(locationResponse.Place);
        }


    }
}
