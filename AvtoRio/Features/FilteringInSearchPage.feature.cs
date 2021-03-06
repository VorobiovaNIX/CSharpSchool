﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.4.0.0
//      SpecFlow Generator Version:3.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace AvtoRio.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("FilteringInSearchPage")]
    public partial class FilteringInSearchPageFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "FilteringInSearchPage.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "FilteringInSearchPage", "\tThis feature will test filtering and sorting list of cars. Also, it tests search" +
                    "ing functionality", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verifying that filtering by Brand, model and year works as expected")]
        [NUnit.Framework.CategoryAttribute("SmokeTest")]
        [NUnit.Framework.CategoryAttribute("Filtering")]
        public virtual void VerifyingThatFilteringByBrandModelAndYearWorksAsExpected()
        {
            string[] tagsOfScenario = new string[] {
                    "SmokeTest",
                    "Filtering"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verifying that filtering by Brand, model and year works as expected", null, tagsOfScenario, argumentsOfScenario);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
 testRunner.Given("I go to the web page \'https://auto.ria.com/\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
 testRunner.Then("the web page is opened \'Автобазар №1. Купити і продати авто легко\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 8
 testRunner.When("I click on \'Розширений пошук\' button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 9
 testRunner.Then("the web page is opened \'Пошук автомобілів в Україні.\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Brand",
                            "Model",
                            "StartYear",
                            "EndYear"});
                table2.AddRow(new string[] {
                            "BMW",
                            "M4",
                            "2013",
                            "2017"});
                table2.AddRow(new string[] {
                            "Mazda",
                            "6",
                            "2016",
                            "2019"});
                table2.AddRow(new string[] {
                            "Audi",
                            "A5",
                            "2012",
                            "2018"});
#line 10
 testRunner.When("I fill in filtering fields by Brand, model and year", ((string)(null)), table2, "When ");
#line hidden
#line 15
 testRunner.And("I click on Пошук button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Brand",
                            "Model",
                            "StartYear",
                            "EndYear"});
                table3.AddRow(new string[] {
                            "BMW",
                            "M4",
                            "2013",
                            "2017"});
                table3.AddRow(new string[] {
                            "Mazda",
                            "6",
                            "2016",
                            "2019"});
                table3.AddRow(new string[] {
                            "Audi",
                            "A5",
                            "2012",
                            "2018"});
#line 16
 testRunner.Then("I see searching result page by Brand, model and year", ((string)(null)), table3, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verifying that filtering by Type of vehicle, Body type and Producing country work" +
            "s as expected")]
        [NUnit.Framework.CategoryAttribute("Filtering")]
        public virtual void VerifyingThatFilteringByTypeOfVehicleBodyTypeAndProducingCountryWorksAsExpected()
        {
            string[] tagsOfScenario = new string[] {
                    "Filtering"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verifying that filtering by Type of vehicle, Body type and Producing country work" +
                    "s as expected", null, tagsOfScenario, argumentsOfScenario);
#line 23
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 24
 testRunner.Given("I go to the web page \'https://auto.ria.com/\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 25
 testRunner.Then("the web page is opened \'Автобазар №1. Купити і продати авто легко\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 26
 testRunner.When("I click on \'Розширений пошук\' button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 27
 testRunner.Then("the web page is opened \'Пошук автомобілів в Україні.\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "TypeOfVehicle",
                            "Body Type",
                            "ProducingCountry"});
                table4.AddRow(new string[] {
                            "Легкові",
                            "Седан",
                            "Німеччина"});
                table4.AddRow(new string[] {
                            "Мото",
                            "Гольф-кар",
                            "Японія"});
#line 28
 testRunner.When("I fill in filtering fields by Type of vehicle, Body type and Producing country", ((string)(null)), table4, "When ");
#line hidden
#line 32
 testRunner.And("I click on Пошук button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 33
 testRunner.And("I open \'1\' item in list of cars", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 34
 testRunner.Then("I should get the same value from Extended steps", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verifying sorting list of cars on the result searching web page")]
        [NUnit.Framework.CategoryAttribute("Sorting")]
        [NUnit.Framework.CategoryAttribute("Filtering")]
        public virtual void VerifyingSortingListOfCarsOnTheResultSearchingWebPage()
        {
            string[] tagsOfScenario = new string[] {
                    "Sorting",
                    "Filtering"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verifying sorting list of cars on the result searching web page", null, tagsOfScenario, argumentsOfScenario);
#line 37
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 38
 testRunner.Given("I go to the web page \'https://auto.ria.com/\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 39
 testRunner.Then("the web page is opened \'Автобазар №1. Купити і продати авто легко\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 40
 testRunner.When("I click on \'Розширений пошук\' button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 41
 testRunner.Then("the web page is opened \'Пошук автомобілів в Україні.\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "StartPrice",
                            "EndPrice"});
                table5.AddRow(new string[] {
                            "5000",
                            "7000"});
#line 42
 testRunner.When("I fill in filtering fields by price", ((string)(null)), table5, "When ");
#line hidden
#line 52
 testRunner.And("I click on Пошук button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 53
 testRunner.Then("I see last date in data is 5 days from current date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 54
 testRunner.And("I see searching result page by price", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 55
 testRunner.When("I sorting list by \'Від дешевих до дорогих\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 56
 testRunner.Then("I see sorted list by \'Від дешевих до дорогих\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 57
 testRunner.And("list items are sorted correctly", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verifying that filtering by Technical characteristics works as expected")]
        [NUnit.Framework.CategoryAttribute("Filtering")]
        public virtual void VerifyingThatFilteringByTechnicalCharacteristicsWorksAsExpected()
        {
            string[] tagsOfScenario = new string[] {
                    "Filtering"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verifying that filtering by Technical characteristics works as expected", null, tagsOfScenario, argumentsOfScenario);
#line 61
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 62
 testRunner.Given("I go to the web page \'https://auto.ria.com/\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 63
 testRunner.Then("the web page is opened \'Автобазар №1. Купити і продати авто легко\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 64
 testRunner.When("I click on \'Розширений пошук\' button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 65
 testRunner.Then("the web page is opened \'Пошук автомобілів в Україні.\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "Fuel",
                            "Transmission",
                            "VolumeFrom",
                            "VolumeTo",
                            "HorsePowerFrom",
                            "HorsePowerTo",
                            "MileageInThousandKmFrom",
                            "MileageInThousandKmTo"});
                table6.AddRow(new string[] {
                            "Бензин",
                            "Ручна / Механіка",
                            "1",
                            "3",
                            "100",
                            "200",
                            "20",
                            "80"});
                table6.AddRow(new string[] {
                            "Бензин",
                            "Автомат",
                            "2",
                            "3",
                            "80",
                            "200",
                            "20",
                            "100"});
#line 66
 testRunner.When("I fill in filtering fields by Technical characteristics", ((string)(null)), table6, "When ");
#line hidden
#line 70
 testRunner.And("I click on Пошук button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "Fuel",
                            "Transmission",
                            "VolumeFrom",
                            "VolumeTo",
                            "HorsePowerFrom",
                            "HorsePowerTo",
                            "MileageInThousandKmFrom",
                            "MileageInThousandKmTo"});
                table7.AddRow(new string[] {
                            "Бензин",
                            "Ручная / Механика",
                            "1",
                            "3",
                            "100",
                            "200",
                            "20",
                            "80"});
                table7.AddRow(new string[] {
                            "Бензин",
                            "Автомат",
                            "2",
                            "3",
                            "80",
                            "200",
                            "20",
                            "100"});
#line 71
 testRunner.Then("I see searching result page by Technical characteristics", ((string)(null)), table7, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verifying that filtering by Number of doors and Number of seats and  works as exp" +
            "ected")]
        [NUnit.Framework.CategoryAttribute("Filtering")]
        public virtual void VerifyingThatFilteringByNumberOfDoorsAndNumberOfSeatsAndWorksAsExpected()
        {
            string[] tagsOfScenario = new string[] {
                    "Filtering"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verifying that filtering by Number of doors and Number of seats and  works as exp" +
                    "ected", null, tagsOfScenario, argumentsOfScenario);
#line 77
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 78
 testRunner.Given("I go to the web page \'https://auto.ria.com/\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 79
 testRunner.Then("the web page is opened \'Автобазар №1. Купити і продати авто легко\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 80
 testRunner.When("I click on \'Розширений пошук\' button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 81
 testRunner.Then("the web page is opened \'Пошук автомобілів в Україні.\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                            "NumberOfDoorsFrom",
                            "NumberOfDoorsTo",
                            "NumberOfSeatsFrom",
                            "NumberOfSeatsTo"});
                table8.AddRow(new string[] {
                            "2",
                            "5",
                            "2",
                            "5"});
#line 82
 testRunner.When("I fill in filtering fields by Number of doors and  Number of seats", ((string)(null)), table8, "When ");
#line hidden
#line 85
 testRunner.And("I click on Пошук button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 86
 testRunner.And("I open \'1\' item in list of cars", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                            "NumberOfDoorsFrom",
                            "NumberOfDoorsTo",
                            "NumberOfSeatsFrom",
                            "NumberOfSeatsTo"});
                table9.AddRow(new string[] {
                            "2",
                            "5",
                            "2",
                            "5"});
#line 87
 testRunner.Then("I see searching result page by Number of doors and Number of seats", ((string)(null)), table9, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verifying that filtering by TypeOfVehicle and Brand from Home page  works as expe" +
            "cted")]
        [NUnit.Framework.CategoryAttribute("SearchingFromHomePage")]
        public virtual void VerifyingThatFilteringByTypeOfVehicleAndBrandFromHomePageWorksAsExpected()
        {
            string[] tagsOfScenario = new string[] {
                    "SearchingFromHomePage"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verifying that filtering by TypeOfVehicle and Brand from Home page  works as expe" +
                    "cted", null, tagsOfScenario, argumentsOfScenario);
#line 92
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 93
 testRunner.Given("I go to the web page \'https://auto.ria.com/\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 94
 testRunner.Then("the web page is opened \'Автобазар №1. Купити і продати авто легко\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                            "TypeOfVehicle",
                            "Brand"});
                table10.AddRow(new string[] {
                            "Легкові б/у",
                            "BMW"});
                table10.AddRow(new string[] {
                            "Мото",
                            "Гольф-кар"});
#line 95
 testRunner.When("I click on TypeOfVehicle and Brand from Home page", ((string)(null)), table10, "When ");
#line hidden
                TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                            "TypeOfVehicle",
                            "Brand"});
                table11.AddRow(new string[] {
                            "Бу авто",
                            "BMW"});
                table11.AddRow(new string[] {
                            "Мото",
                            "Гольф-кар"});
#line 99
 testRunner.Then("I should see certain breadcrumbs", ((string)(null)), table11, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verifying fast search from Home page")]
        [NUnit.Framework.CategoryAttribute("SearchingFromHomePage")]
        public virtual void VerifyingFastSearchFromHomePage()
        {
            string[] tagsOfScenario = new string[] {
                    "SearchingFromHomePage"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verifying fast search from Home page", null, tagsOfScenario, argumentsOfScenario);
#line 105
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 106
 testRunner.Given("I go to the web page \'https://auto.ria.com/\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 107
 testRunner.Then("the web page is opened \'Автобазар №1. Купити і продати авто легко\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                            "Brand",
                            "Model",
                            "StartYear",
                            "EndYear"});
                table12.AddRow(new string[] {
                            "BMW",
                            "M3",
                            "2013",
                            "2017"});
                table12.AddRow(new string[] {
                            "Audi",
                            "A5",
                            "2016",
                            "2019"});
#line 108
 testRunner.When("I search by Type of vehicle Brand and Model from Home page", ((string)(null)), table12, "When ");
#line hidden
#line 112
 testRunner.And("I click on Пошук button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                            "Brand",
                            "Model",
                            "StartYear",
                            "EndYear"});
                table13.AddRow(new string[] {
                            "BMW",
                            "M3",
                            "2013",
                            "2017"});
                table13.AddRow(new string[] {
                            "Audi",
                            "A5",
                            "2016",
                            "2019"});
#line 113
 testRunner.Then("I see searching result page by Brand, model and year", ((string)(null)), table13, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
