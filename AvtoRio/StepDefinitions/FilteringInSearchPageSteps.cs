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
using System.Data;

namespace AvtoRio.StepDefinitions
{
    [Binding]
    public class FilteringInSearchPageSteps: BasePage
    {
        //IWebDriver driver;

        public readonly CarDetails Car;

        public FilteringInSearchPageSteps(CarDetails car)
        {
            this.Car = car;
        }

        [Given(@"I go to the web page '(.*)'")]
        public void GivenIGoToTheWebPage(string webpage)
        {
            //driver = new ChromeDriver();
            driver.Navigate().GoToUrl(webpage);
            driver.Manage().Window.Maximize();
        }

        [Then(@"the web page is opened '(.*)'")]
        public void GivenTheWebPageIsOpened(string title)
        {
            Assert.That(driver.Title.Contains( title));
        }
        
        [When(@"I click on '(.*)' button")]
        public void WhenIClickOnButton(string nameButton)
        {
            IWebElement button = driver.FindElement(By.XPath($"//*[@id='mainSearchForm']//span[text()='{nameButton}']"));
            button.Click();
        }
        
        [When(@"I fill in filtering fields by Brand, model and year")]
        public void WhenIFillInFilteringFields(Table table)
        {
            string brandCar = table.Rows[0]["Brand"];
            driver.FindElement(By.XPath("//div[@id='autocomplete-brand-0']/label"),3).Click();

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

            //var details = table.CreateDynamicSet();
            //details.GetEnumerator();

            driver.FindElement(By.XPath($"(//ul[@class='unstyle scrollbar autocomplete-select']/li/a[text()='{brandCar}'])[1]")).Click();

            string modelCar = table.Rows[0]["Model"];
            driver.FindElement(By.XPath("//label[@data-text='Оберіть модель']")).Click();
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds());
            driver.FindElement(By.XPath($"//ul[contains(@class,'autocomplete-select check_list')]/li/a[text()='{modelCar}']"),5).Click();

            string startYearCar = table.Rows[0]["StartYear"];
            SelectElement selectStartYear = new SelectElement(driver.FindElement(By.XPath("//div/select[@id='at_year-from']"),5));
            selectStartYear.SelectByText(startYearCar);

            string endYearCar = table.Rows[0]["EndYear"];
            SelectElement selectEndYear = new SelectElement(driver.FindElement(By.XPath("//div/select[@id='at_year-to']")));
            selectEndYear.SelectByText(endYearCar);

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
        public void WhenIClickOnButton()
        {
            IWebElement button = driver.FindElement(By.XPath("//button[@class='button small']"));
            button.Click();
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

            var carTitles = driver.FindElements(By.XPath(".//div[@class='item ticket-title']/a"));
            foreach (var car in carTitles)
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
            foreach (var item in data)
            {
                Car.TypeOfVehicle = (string)item.TypeOfVehicle;
                Car.BodyType = (string)item.BodyType;
                Car.ProducingCountry = (string)item.ProducingCountry;
            }
            Console.WriteLine(Car.TypeOfVehicle);
            Console.WriteLine(Car.BodyType);
            Console.WriteLine(Car.ProducingCountry);

            SelectElement selectTypeOfVehicle = new SelectElement(driver.FindElement(By.XPath("//select[@aria-label='Тип транспорту']")));
            selectTypeOfVehicle.SelectByText(Car.TypeOfVehicle);

            try
            {
                driver.FindElement(By.XPath($"//div[@class='indent']//div[@class='boxed checked-list']/label[text()=' {Car.BodyType}']")).Click();
            }
            catch (NoSuchElementException)
            {
                driver.FindElement(By.XPath("//label[text()='Інші типи кузову']"),5).Click();
                wait(10);
                driver.FindElement(By.XPath($"//div[@class='indent']//div[@class='boxed checked-list']/label[text()=' {Car.BodyType}']"),20).Click(); 
            }

            SelectElement selectProducingCountry = new SelectElement(driver.FindElement(By.XPath("//select[@id='at_country']")));
            selectProducingCountry.SelectByText(Car.ProducingCountry);
        }

        [Then(@"I should see (.*) message")]
        [Scope(Tag = "Login")]
        public void ThenISeeMessage(string result)
        {
            switchToFrameByName("login_frame");
            try
            {
                Assert.That(driver.FindElement(By.XPath("//p[@class='error login-link']"), 2).Text.Contains(result));
            }
            catch (NoSuchElementException)
            {
                Assert.That(driver.FindElement(By.XPath("//main[@class='app-content']/h1")).Text.Contains(result));
            }
        }

        [When(@"I fill in filtering fields by price")]
        public void WhenIFillInFilteringFieldsByPrice(Table table)
        {
            var data = table.CreateDynamicSet();
            foreach (var item in data)
            {
                Car.StartPrice = (int)item.StartPrice;
                Car.EndPrice = (int)item.EndPrice;
            }
            Console.WriteLine(Car.StartPrice);
            Console.WriteLine(Car.EndPrice);

            //var dictionary = TableExtensions.ToDictionary(table);
            //var test = dictionary["StartPrice"];


            driver.FindElement(By.XPath("//div[@class='item-two-el']/input[@id='at_price-from']"),3).SendKeys(Car.StartPrice.ToString());
            driver.FindElement(By.XPath("//div[@class='item-two-el']/input[@id='at_price-to']")).SendKeys(Car.EndPrice.ToString());

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

            var carTitles = driver.FindElements(By.XPath(".//div[@class='content']//span[@class='bold green size22'][1]"));
            foreach (var item in carTitles)
            {
                int actualPrice = Int32.Parse(WebDriverExtensions.RemoveWhitespace(item.Text));
                Assert.GreaterOrEqual(actualPrice, Car.StartPrice,
                    "Start price that set up on search page doesn't according to price on the list of cars");
                Assert.LessOrEqual(actualPrice, Car.EndPrice,
                    "End price that set up on search page doesn't according to price on the list of cars");
            }

        }

        [When(@"I sorting list by '(.*)'")]
        public void WhenISortingListBy(string value)
        {
            driver.FindElement(By.XPath("//a[@id='sortCheckedElement']")).Click();

            driver.FindElement(By.XPath($"//a[@id='sortCheckedElement']/following-sibling::span/a[text()='{value}']"),3).Click();

            
        }

        [Then(@"I see sorted list by '(.*)'")]
        public void ThenISeeSortedListBy(string value)
        {
            Assert.AreEqual(driver.FindElement(By.XPath("//a[@id='sortCheckedElement']")).Text, value);

            SelectElement sortingField = new SelectElement(driver.FindElement(By.XPath("//select[@id='leftFilterSortSelect']")));
            string selectedValue = sortingField.AllSelectedOptions[0].Text;

            Assert.AreEqual(selectedValue, value);

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

            var fuelField = driver.FindElement(By.XPath($"//label[text()='{characteristicsFirstRow.Fuel}']"));
            scrollToTheElement(fuelField);
            fuelField.Click();
            driver.FindElement(By.XPath($"//label[text()='{characteristicsFirstRow.Transmission}']")).Click();
            //driver.FindElement(By.XPath($"//div[@id='drive']/label[text()='{characteristicsFirstRow.DriveType}']")).Click();

            driver.FindElement(By.XPath($"//div[@id='volumeBlock']//input[1]")).SendKeys(characteristicsFirstRow.VolumeFrom.ToString());
            driver.FindElement(By.XPath($"//div[@id='volumeBlock']//input[2]")).SendKeys(characteristicsFirstRow.VolumeTo.ToString());

            driver.FindElement(By.XPath($"//div[@class='rows']/label[text()='Потужність']/..//input[1]")).SendKeys(characteristicsFirstRow.HorsePowerFrom.ToString());
            driver.FindElement(By.XPath($"//div[@class='rows']/label[text()='Потужність']/..//input[2]")).SendKeys(characteristicsFirstRow.HorsePowerTo.ToString());
            driver.FindElement(By.XPath($"//div[@class='rows']/label[text()='Пробіг, тис. км']/..//input[1]")).SendKeys(characteristicsFirstRow.MileageInThousandKmFrom.ToString());
            driver.FindElement(By.XPath($"//div[@class='rows']/label[text()='Пробіг, тис. км']/..//input[2]")).SendKeys(characteristicsFirstRow.MileageInThousandKmTo.ToString());
        }


        [Then(@"I see searching result page by Technical characteristics")]
        public void ThenISeeSearchingResultPageByTechnicalCharacteristics(Table characteristicsTable)
        {
            IEnumerable<dynamic> characteristicList = characteristicsTable.CreateDynamicSet();

            var characteristicsFirstRow = characteristicList.First();

            foreach (var item in driver.FindElements(By.XPath("//li/i[@class='icon-transmission']/..")) )
            {
                Assert.That(item.Text.Contains(characteristicsFirstRow.Transmission));
            }

            foreach (var item in driver.FindElements(By.XPath("//li/i[@class='icon-mileage']/..")))
            {
                int actualMileageInThousandKm = Int32.Parse(item.Text.Split(' ').First());

                Assert.GreaterOrEqual(actualMileageInThousandKm, characteristicsFirstRow.MileageInThousandKmFrom,
                    "Mileage that set up on search page doesn't according to the Mileage in thousand km on the list of cars");
                Assert.LessOrEqual(actualMileageInThousandKm, characteristicsFirstRow.MileageInThousandKmTo,
                    "Mileage that set up on search page doesn't according to the Mileage in thousand km on the list of cars");
            }

            foreach (var item in driver.FindElements(By.XPath("//li/i[@class='icon-fuel']/..")))
            {
                string actualFuelWithChar = item.Text.Split(' ').First();
                string actualFuel = actualFuelWithChar.Remove(actualFuelWithChar.Length - 1);
                Assert.AreEqual(actualFuel,characteristicsFirstRow.Fuel);

                double actualVolume = double.Parse(item.Text.Split(' ').Skip(1).First());
                Assert.GreaterOrEqual(actualVolume, characteristicsFirstRow.VolumeFrom,
                    "Mileage that set up on search page doesn't according to the Mileage in thousand km on the list of cars");
                Assert.LessOrEqual(actualVolume, characteristicsFirstRow.VolumeTo,
                    "Mileage that set up on search page doesn't according to the Mileage in thousand km on the list of cars");
            }

        }

        [When(@"I fill in filtering fields by Number of doors and  Number of seats")]
        public void WhenIFillInFilteringFieldsByNumberOfDoorsAndNumberOfSeats(Table table)
        {

            /*The CreateDynamicInstance() method will create the dynamic object which will hold
             * the Table values which are passed as an Argument to the step. It also will use the appropriate casting or conversion to 
             * turn your string into the appropriate type.*/
            dynamic characteristics = table.CreateDynamicInstance(); 

            driver.FindElement(By.XPath("//div[@class='rows']/label[text()='Кількість дверей']/..//input[1]")).SendKeys(characteristics.NumberOfDoorsFrom.ToString());
            driver.FindElement(By.XPath("//div[@class='rows']/label[text()='Кількість дверей']/..//input[2]")).SendKeys(characteristics.NumberOfDoorsTo.ToString());

            driver.FindElement(By.XPath("//div[@class='rows']/label[text()='Кількість місць']/..//input[1]")).SendKeys(characteristics.NumberOfSeatsFrom.ToString());
            driver.FindElement(By.XPath("//div[@class='rows']/label[text()='Кількість місць']/..//input[2]")).SendKeys(characteristics.NumberOfSeatsTo.ToString());


        }

        [Then(@"I see searching result page by Number of doors and Number of seats")]
        public void ThenISeeSearchingResultPageByNumberOfDoorsAndNumberOfSeats(Table table)
        {
            dynamic characteristics = table.CreateDynamicInstance();
            var actualResult = driver.FindElement(By.XPath("//div[@class='box-panel description-car']//dd[1]")).Text.Split(' '); //Хетчбек • 5 дверей • 5 місць

            int actualNumberOfDoors = Int32.Parse(actualResult.ElementAt(2)); 
            Assert.GreaterOrEqual(actualNumberOfDoors, characteristics.NumberOfDoorsFrom,
                   "Mileage that set up on search page doesn't according to the Mileage in thousand km on the list of cars");
            Assert.LessOrEqual(actualNumberOfDoors, characteristics.NumberOfDoorsTo,
                "Mileage that set up on search page doesn't according to the Mileage in thousand km on the list of cars");

            int actualNumberOfSeats = Int32.Parse(actualResult.ElementAt(5));
            Assert.GreaterOrEqual(actualNumberOfSeats, characteristics.NumberOfSeatsFrom,
                   "Mileage that set up on search page doesn't according to the Mileage in thousand km on the list of cars");
            Assert.LessOrEqual(actualNumberOfSeats, characteristics.NumberOfSeatsTo,
                "Mileage that set up on search page doesn't according to the Mileage in thousand km on the list of cars");
        }

    }
}
