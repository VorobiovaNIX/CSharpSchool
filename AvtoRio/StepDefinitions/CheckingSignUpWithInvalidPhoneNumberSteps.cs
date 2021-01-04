using System;
using TechTalk.SpecFlow;

namespace AvtoRio.StepDefinitions
{
    [Binding]
    public class CheckingSignUpWithInvalidPhoneNumberSteps
    {
        [Then(@"I click the '(.*)' link")]
        public void ThenIClickTheLink(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I enter TestQA, Test and \+(.*)")]
        public void WhenIEnterTestQATestAnd(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I see Номер вже зареєстрований message")]
        public void ThenISeeНомерВжеЗареєстрованийMessage()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
