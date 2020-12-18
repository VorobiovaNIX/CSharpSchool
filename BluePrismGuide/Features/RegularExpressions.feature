Feature: Returing location data based on country and zip code
As a consumer of the Zippopotam.us API
I want to receive location data matching the country code and zip code I supply
So I can use this data to auto-complete forms on my web site

@mytag
Scenario: Country code us and zip code 90210 yields Beverly Hills as a place name
	Given the country code us and zip code 90210
	When I request the locations corresponding to these codes
	Then the response contains the place name Beverly Hills 

Scenario: Country code us and zip code 22222 yields Arlington Hills as a place name
	Given the country code us and zip code 22222
	When I request the locations corresponding to these codes
	Then the response contains the place name Arlington 