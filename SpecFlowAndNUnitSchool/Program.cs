using System;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SpecFlowAndNUnitSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://www.demoqa.com";
        }
    }

    public class Place
    {
        [JsonProperty("place name")]
        public string PlaceName { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("state abbreviation")]
        public string StateAbbreviation { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }




    }
}
