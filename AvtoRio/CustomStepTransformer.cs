using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace AvtoRio
{
    [Binding]
    public class CustomStepTransformer
    {
        [StepArgumentTransformation(@"(\d+) days from current date")]
        public DateTime DayAdderTransformer(int days)
        {
            return DateTime.Today.AddDays(days);
        }

    }
}
