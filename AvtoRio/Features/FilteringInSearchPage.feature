Feature: FilteringInSearchPage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Scenario: Verifying that filtering by Brand, model and year works as expected 
	Given I go to the web page 'https://auto.ria.com/'
	And the web page is opened 'Автобазар №1. Купити і продати авто легко'
	When I click on 'Розширений пошук' button
	Then  the web page is opened 'Пошук автомобілів в Україні.'
	When I fill in filtering fields 
	| Brand | Model | Start Year | End Year |
	| BMW   | M4    | 2013       | 2017     |
	| Mazda | 6     | 2016       | 2019     |
	| Audi  | A5    | 2012       | 2018     |
	And I click on 'Пошук' button
	Then I see searching result page
	| Brand | Model | Start Year | End Year |
	| BMW   | M4    | 2013       | 2017     |
	| Mazda | 6     | 2016       | 2019     |
	| Audi  | A5    | 2012       | 2018     |
