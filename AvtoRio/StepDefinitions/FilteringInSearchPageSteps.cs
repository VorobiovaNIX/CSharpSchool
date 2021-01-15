using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using AvtoRio.Utils;
using AvtoRio.Pages;
using System.Data;
using AvtoRio;

namespace AvtoRio.StepDefinitions
{
    [Binding]
    public class FilteringInSearchPageSteps
    {
        private readonly IWebDriver _driver;
        private FilteringPage filteringPage { get; }
        private HomePage homePage { get; }
        private ListOfCarsPage listOfCarsPage { get; }
        private CarSinglePage carSinglePage { get; }
        public FilteringInSearchPageSteps(IWebDriver driver)
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
            filteringPage = new FilteringPage(_driver);
            homePage = new HomePage(_driver);
            listOfCarsPage = new ListOfCarsPage(_driver);
            carSinglePage = new CarSinglePage(_driver);

        }

        public readonly CarDetails Car;

        //public FilteringInSearchPageSteps(CarDetails car)
        //{
        //    this.Car = car;
        //}

        [Given(@"I go to the web page '(.*)'")]
        public void GivenIGoToTheWebPage(string webpage)
        {
            _driver.Navigate().GoToUrl(webpage);
        }

        [Then(@"the web page is opened '(.*)'")]
        public void GivenTheWebPageIsOpened(string title)
        {
            Assert.That(_driver.Title.Contains( title));
        }
        
        [When(@"I click on 'Розширений пошук' button")]
        public void WhenIClickOnAdvancedSearchButton()
        {
            homePage.ClickOnAdvancedSearch();
        }
        
        [When(@"I fill in filtering fields by Brand, model and year")]
        public void WhenIFillInFilteringFields(Table table)
        {
            CarDetails details = table.CreateInstance<CarDetails>(); //Only Single row of Data can be used with this. 
            Console.WriteLine(details.Brand);
            Console.WriteLine(details.Model);

            //IEnumerable<CarDetails> details = table.CreateSet<CarDetails>(); - Single row of Data or Multiple rows of Data can used here.
            //CreateSet<T> is capable of handling multiple data sets.
            //string[] row = { "Audi", "A5", "2012", "2018" };
            //table.AddRow(row);

            //foreach (CarDetails car in details)
            //{
            //    Console.WriteLine(car.Brand);
            //    Console.WriteLine(car.Model);
            //    Console.WriteLine(car.StartYear);
            //    Console.WriteLine(car.EndYear);
            //}


            string brandCar = table.Rows[0]["Brand"];
            filteringPage.SelectBrandField(brandCar);
            filteringPage.SelectModelField(table.Rows[0]["Model"]);
            filteringPage.SelectStartYear(table.Rows[0]["StartYear"]);
            filteringPage.SelectEndYear(table.Rows[0]["EndYear"]);

            ScenarioContext.Current["InfoForNextStep"] = "Step 1 Passed";
            Console.WriteLine(ScenarioContext.Current["InfoForNextStep"].ToString());

            List<CarDetails> carDetails = new List<CarDetails>()
            {
                new CarDetails()
                {
                    Brand = "BMW",
                    Model ="M5",
                    StartYear =2000,
                    EndYear =2005

                },
                new CarDetails()
                {
                    Brand = "BMW",
                    Model ="435",
                    StartYear =2015,
                    EndYear =2019

                },
                new CarDetails()
                {
                    Brand = "BMW",
                    Model ="428",
                    StartYear =2015,
                    EndYear =2019

                },
                new CarDetails()
                {
                    Brand = "BMW",
                    Model ="320",
                    StartYear =1994,
                    EndYear =2005
                },
                new CarDetails()
                {
                    Brand = "Ford",
                    Model ="Focus",
                    StartYear =2015,
                    EndYear =2019
                }
            };

            //Save the value in ScenarioContext
            ScenarioContext.Current.Add("CarDetails", carDetails);

            //Get the value out from ScenarioContext
            var carList = ScenarioContext.Current.Get<IEnumerable<CarDetails>>("CarDetails");

            foreach (CarDetails car in carList)
            {
                Console.WriteLine("The car brand is " + car.Brand);
                Console.WriteLine("The car model is "+car.Model);
                Console.WriteLine("The car Start year is " + car.StartYear);
                Console.WriteLine("The car End Year is " + car.EndYear);
            }
            Console.WriteLine(ScenarioContext.Current.Count);
            Console.WriteLine(ScenarioContext.Current.CurrentScenarioBlock);
        }

        [When(@"I click on Пошук button")]
        public void WhenIClickOnSearchButton()
        {
            filteringPage.ClickSearch();
        }


        [Then(@"I see searching result page by Brand, model and year")]
        public void ThenISeeSearchingResultPage(Table table)
        {
            string brandCar = table.Rows[0]["Brand"];
            string modelCar = table.Rows[0]["Model"];
            string startYearCar = table.Rows[0]["StartYear"];
            string endYearCar = table.Rows[0]["EndYear"];

            var dataTable = TableExtensions.ToDataTable(table);
            foreach (DataRow row in dataTable.Rows)
            {
               Console.WriteLine(row.ItemArray[0].ToString());
               Console.WriteLine(row.ItemArray[1].ToString());
               Console.WriteLine(row.ItemArray[2].ToString());
               Console.WriteLine(row.ItemArray[3].ToString());

            }

            foreach (var car in filteringPage.carTitles)
            {
                Assert.That( car.FindElement(By.XPath("./span")).Text.Contains(brandCar +" "+ modelCar),
                    "The actual brand and model of the car is search result does not according to set filtering");

                string[] wordsInTitle = car.Text.Split(' ');
                int actualYearCar = int.Parse(wordsInTitle[wordsInTitle.Length-1]);
                if (actualYearCar > int.Parse(endYearCar) || actualYearCar < int.Parse(startYearCar))
                    throw new AssertionException("The actual year of the car is search result does not according to set filtering");


            }
        }

        [When(@"I fill in filtering fields by Type of vehicle, Body type and Producing country")]
        public void WhenIFillInFilteringFieldsByTypeOfVehicleBodyTypeAndProducingCountry(Table table)
        {
            var data = table.CreateDynamicSet();
            var dataFirstRow = data.First();

            filteringPage.SelectTypeOfVehicle(dataFirstRow.TypeOfVehicle);
            filteringPage.SelectBodyType(dataFirstRow.BodyType);
            filteringPage.SelectProducingCountry(dataFirstRow.ProducingCountry);
        }

        [Then(@"I should see (.*) message")]
        [Scope(Tag = "Login")]
        public void ThenISeeMessage(string result)
        {
            BasePage page = new BasePage(_driver);
            page.SwitchToFrameByName("login_frame");
            try
            {
                Assert.That(_driver.FindElement(By.XPath("//p[@class='error login-link']"), 2).Text.Contains(result));
            }
            catch (NoSuchElementException)
            {
                Assert.That(_driver.FindElement(By.XPath("//main[@class='app-content']/h1")).Text.Contains(result));
            }
        }

        [When(@"I fill in filtering fields by price")]
        public void WhenIFillInFilteringFieldsByPrice(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            foreach (var item in data)
            {
                Car.StartPrice = (int)item.StartPrice;
                Car.EndPrice = (int)item.EndPrice;
            }
            //Console.WriteLine(Car.StartPrice);
            //Console.WriteLine(Car.EndPrice);


            filteringPage.EnterStartPriceField(data.StartPrice.ToString());
            filteringPage.EnterEndPriceField(data.EndPrice.ToString());
        }

        [Then(@"I see last date in data is (.* days from current date)")]
        public void ThenISeeLastDateInDataIsDaysFromCurrentDate(DateTime correctDateTime)
        {
            Console.WriteLine(correctDateTime);  
        }

        [Then(@"I see searching result page by price")]
        public void ThenISeeSearchingResultPageByPrice()
        {
            Console.WriteLine(Car.StartPrice);
            Console.WriteLine(Car.EndPrice);

            listOfCarsPage.ShouldSeePrice(Car.StartPrice, Car.EndPrice);
        }

        [When(@"I sorting list by '(.*)'")]
        public void WhenISortingListBy(string value)
        {
            listOfCarsPage.SelectSortingListBy(value);            
        }

        [Then(@"I see sorted list by '(.*)'")]
        public void ThenISeeSortedListBy(string value)
        {
            listOfCarsPage.ShouldSeeSortedListOfCarsBy(value);
        }

        [Then(@"list items are sorted correctly")]
        public void ThenListItemsAreSortedCorrectly()
        {
            
        }

        [When(@"I fill in filtering fields by Technical characteristics")]
        public void WhenIFillInFilteringFieldsByTechnicalCharacteristics(Table characteristicsTable)
        {
            /*The CreateDynamicSet() method will create the dynamic object which will hold
             * the Table values which are passed as an Argument to the step. This creates a IEnumerable<dynamic>
             * for a several rows. The headers are the property names as before.*/
            IEnumerable <dynamic> characteristicList = characteristicsTable.CreateDynamicSet();

            var characteristicsFirstRow = characteristicList.First();
            Console.WriteLine(characteristicsFirstRow.Fuel);

            filteringPage.SelectFuelField(characteristicsFirstRow.Fuel);
            filteringPage.SelectTransmission(characteristicsFirstRow.Transmission);
            filteringPage.SelectVolume(characteristicsFirstRow.VolumeFrom.ToString(), characteristicsFirstRow.VolumeTo.ToString());
            filteringPage.SelectHorsePower(characteristicsFirstRow.HorsePowerFrom.ToString(), characteristicsFirstRow.HorsePowerTo.ToString());
            filteringPage.SelectMileageInThousandKm(characteristicsFirstRow.MileageInThousandKmFrom.ToString(), characteristicsFirstRow.MileageInThousandKmTo.ToString());
        }


        [Then(@"I see searching result page by Technical characteristics")]
        public void ThenISeeSearchingResultPageByTechnicalCharacteristics(Table characteristicsTable)
        {
            IEnumerable<dynamic> characteristicList = characteristicsTable.CreateDynamicSet();

            var characteristicsFirstRow = characteristicList.First();

            listOfCarsPage.ShouldSeeTransmission(characteristicsFirstRow.Transmission);
            listOfCarsPage.ShouldSeeMileageInThousandKm(characteristicsFirstRow.MileageInThousandKmFrom, characteristicsFirstRow.MileageInThousandKmTo);
            listOfCarsPage.ShouldSeeFuel(characteristicsFirstRow.Fuel);
            listOfCarsPage.ShouldSeeVolume(characteristicsFirstRow.VolumeFrom, characteristicsFirstRow.VolumeTo);
        }

        [When(@"I fill in filtering fields by Number of doors and  Number of seats")]
        public void WhenIFillInFilteringFieldsByNumberOfDoorsAndNumberOfSeats(Table table)
        {

            /*The CreateDynamicInstance() method will create the dynamic object which will hold
             * the Table values which are passed as an Argument to the step. It also will use the appropriate casting or conversion to 
             * turn your string into the appropriate type.*/
            dynamic characteristics = table.CreateDynamicInstance();

            filteringPage.numberOfDoorsFrom.SendKeys(characteristics.NumberOfDoorsFrom.ToString());
            filteringPage.numberOfDoorsTo.SendKeys(characteristics.NumberOfDoorsTo.ToString());

            filteringPage.numberOfSeatsFrom.SendKeys(characteristics.NumberOfSeatsFrom.ToString());
            filteringPage.numberOfSeatsTo.SendKeys(characteristics.NumberOfSeatsTo.ToString());


        }

        [Then(@"I see searching result page by Number of doors and Number of seats")]
        public void ThenISeeSearchingResultPageByNumberOfDoorsAndNumberOfSeats(Table table)
        {
            dynamic characteristics = table.CreateDynamicInstance();
            var actualResult = _driver.FindElement(By.XPath("//div[@class='box-panel description-car']//dd[1]")).Text.Split(' '); //Хетчбек • 5 дверей • 5 місць
            int actualNumberOfDoors = Int32.Parse(actualResult.ElementAt(actualResult.Length - 5));

            Assert.GreaterOrEqual(actualNumberOfDoors, characteristics.NumberOfDoorsFrom,
                   "Mileage that set up on search page doesn't according to the Mileage in thousand km on the list of cars");
            Assert.LessOrEqual(actualNumberOfDoors, characteristics.NumberOfDoorsTo,
                "Mileage that set up on search page doesn't according to the Mileage in thousand km on the list of cars");

            int actualNumberOfSeats = Int32.Parse(actualResult.ElementAt(actualResult.Length - 2));

            Assert.GreaterOrEqual(actualNumberOfSeats, characteristics.NumberOfSeatsFrom,
                   "Mileage that set up on search page doesn't according to the Mileage in thousand km on the list of cars");
            Assert.LessOrEqual(actualNumberOfSeats, characteristics.NumberOfSeatsTo,
                "Mileage that set up on search page doesn't according to the Mileage in thousand km on the list of cars");
        }

    }
}
