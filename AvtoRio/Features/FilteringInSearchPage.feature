Feature: FilteringInSearchPage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@SmokeTest
Scenario: Verifying that filtering by Brand, model and year works as expected 
	Given I go to the web page 'https://auto.ria.com/'
	Then the web page is opened 'Автобазар №1. Купити і продати авто легко'
	When I click on 'Розширений пошук' button
	Then the web page is opened 'Пошук автомобілів в Україні.'
	When I fill in filtering fields by Brand, model and year
	| Brand | Model | StartYear | EndYear |
	| BMW   | M4    | 2013       | 2017     |
	| Mazda | 6     | 2016       | 2019     |
	| Audi  | A5    | 2012       | 2018     |
	And I click on Пошук button
	Then I see searching result page by Brand, model and year
	| Brand | Model | StartYear | EndYear |
	| BMW   | M4    | 2013       | 2017     |
	| Mazda | 6     | 2016       | 2019     |
	| Audi  | A5    | 2012       | 2018     |

Scenario: Verifying that filtering by Type of vehicle, Body type and Producing country works as expected 
	Given I go to the web page 'https://auto.ria.com/'
	Then the web page is opened 'Автобазар №1. Купити і продати авто легко'
	When I click on 'Розширений пошук' button
	Then the web page is opened 'Пошук автомобілів в Україні.'
	When I fill in filtering fields by Type of vehicle, Body type and Producing country
	| TypeOfVehicle | Body Type | ProducingCountry |
	| Легкові       | Седан     | Німеччина        |
	| Мото          | Гольф-кар | Японія           |
	And I click on Пошук button
	Then I should get the same value from Extended steps
