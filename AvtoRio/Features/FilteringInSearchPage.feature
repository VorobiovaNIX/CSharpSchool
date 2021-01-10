Feature: FilteringInSearchPage
	This feature will test filtering and sorting list of cars. Also, it tests searching functionality

@SmokeTest @Filtering 
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

	@Filtering 
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

	@Sorting
Scenario: Verifying sorting list of cars on the result searching web page
	Given I go to the web page 'https://auto.ria.com/'
	Then the web page is opened 'Автобазар №1. Купити і продати авто легко'
	When I click on 'Розширений пошук' button
	Then the web page is opened 'Пошук автомобілів в Україні.'
	When I fill in filtering fields by price
	| StartPrice | EndPrice |
	| 5000       | 7000     |
	#| Key        | Value |  Vertical Data that use for Dictionary Key-Value pair - Transform Table into Dictionary
	#| StartPrice | 5000  |
	#| EndPrice   | 7000  |

	# | Field    | Value  | Parameterizing Data in Vertical format. Only Single row of Data can be used with this -  CreateInstance in SpecFlow Table 
	# | StartPrice | 5000 |
	# | EndPrice | 7000   |
	And I click on Пошук button
	Then I see last date in data is 5 days from current date
	And I see searching result page by price
	When I sorting list by 'Від дешевих до дорогих'
	Then I see sorted list by 'Від дешевих до дорогих'
	And list items are sorted correctly 


	@Filtering 
Scenario: Verifying that filtering by Technical characteristics works as expected 
	Given I go to the web page 'https://auto.ria.com/'
	Then the web page is opened 'Автобазар №1. Купити і продати авто легко'
	When I click on 'Розширений пошук' button
	Then the web page is opened 'Пошук автомобілів в Україні.'
	When I fill in filtering fields by Technical characteristics
	| Fuel   | Transmission     | DriveType | VolumeFrom | VolumeTo | HorsePowerFrom | HorsePowerTo | MileageInThousandKmFrom | MileageInThousandKmTo |
	| Бензин | Ручна / Механіка | Передній  | 1          | 3        | 100            | 200          | 20                      | 80                    |
	| Бензин | Автомат          | Передній  | 2          | 3        | 80            | 200          | 20                      | 100                   |

	And I click on Пошук button
	Then I see searching result page by Technical characteristics