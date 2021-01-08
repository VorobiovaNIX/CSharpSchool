using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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

            //CarDetails details = table.CreateInstance<CarDetails>();
            // driver.FindElement(By.XPath("//div[@id='autocomplete-brand-0']/input")).SendKeys(details.Brand);

            //IEnumerable<CarDetails> details = table.CreateSet<CarDetails>();
            //string[] row = { "Audi", "A5", "2012", "2018" };
            //table.AddRow(row);

            //foreach (CarDetails car in details)
            //{
            //    Console.WriteLine(car.Brand);
            //    Console.WriteLine(car.Model);
            //    Console.WriteLine(car.StartYear);
            //    Console.WriteLine(car.EndYear);
            //}

            var details = table.CreateDynamicSet();
            details.GetEnumerator();
            
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

            var carTitles = driver.FindElements(By.XPath(".//div[@class='item ticket-title']/a"));
            foreach (var car in carTitles)
            {
                Assert.That( car.FindElement(By.XPath("./span")).Text.Contains(brandCar +" "+ modelCar),
                    "The actual brand and model of the car is search result does not according to set filtering");

                string[] wordsInTitle = car.Text.Split(' ');
                int actualYearCar = int.Parse(wordsInTitle[wordsInTitle.Length-1]);
                Console.WriteLine(actualYearCar);
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

            driver.FindElement(By.XPath("//div[@class='item-two-el']/input[@id='at_price-from']"),3).SendKeys(Car.StartPrice.ToString());
            driver.FindElement(By.XPath("//div[@class='item-two-el']/input[@id='at_price-to']")).SendKeys(Car.EndPrice.ToString());

        }

        [Then(@"I see last date in data is (.* days from current date)")]
        public void ThenISeeLastDateInDataIsDaysFromCurrentDate(DateTime correctDateTime)
        {
            Console.WriteLine(correctDateTime);  
        }

        [When(@"I sorting list by '(.*)'")]
        public void WhenISortingListBy(string p0)
        {
            
        }

        [Then(@"I see sorted list by '(.*)'")]
        public void ThenISeeSortedListBy(string p0)
        {
           
        }

        [Then(@"list items are sorted correctly")]
        public void ThenListItemsAreSortedCorrectly()
        {
            
        }

        [When(@"I fill in filtering fields by Technical characteristics")]
        public void WhenIFillInFilteringFieldsByTechnicalCharacteristics(Table characteristics)
        {
            /*The CreateDynamicInstance() method will create the dynamic object which will hold
             * the Table values which are passed as an Argument to the step. It also will use the appropriate casting or conversion to 
             * turn your string into the appropriate type.*/
            dynamic characteristic = characteristics.CreateDynamicInstance(); 

            string fuel = characteristic.Fuel;
            string transmission = characteristic.Transmission;
            string driveType = characteristic.DriveType;
            double volumeFrom = characteristic.VolumeFrom;
            double volumeTo = characteristic.VolumeTo;
            int horsePowerFrom = characteristic.HorsePowerFrom;
            int horsePowerTo = characteristic.HorsePowerTo;

            /*The CreateDynamicSet() method will create the dynamic object which will hold
             * the Table values which are passed as an Argument to the step. This creates a IEnumerable<dynamic>
             * for a several rows. The headers are the property names as before.*/
            IEnumerable <dynamic> characteristicList = characteristics.CreateDynamicSet();

            var characteris = characteristicList.First();


        }



    }
}
