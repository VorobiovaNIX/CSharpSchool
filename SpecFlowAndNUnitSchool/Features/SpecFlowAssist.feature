Feature: SpecFlowAssist
As a consumer of the Zippopotam.us API
I want to receive location data matching the country code and zip code I supply
So I can use this data to auto-complete forms on my web site

Scenario: Location data can be added to the database
	Given Susan wants to add the following places for de zip code 24848
	| PlaceName      | Longitude | Latitude | CountryName |
	| Alt Bennebek   | 9.4333    | 54.3833  | Germany     |
	| Klein Rheide   | 9.4833    | 54.45    | Germany     |
	| Kropp          | 9.5087    | 54.4111  | Germany     |
	| Klein Bennebek | 9.45      | 54.4     | Germany     |

	When she submits the required data
	Then she should receive a reply indicating success

Scenario: Country code de and zip code 24848 yields the expected places
	Given country code de and zip code 24848
	When I request the locations corresponding to these codes
	Then the following places are returned  
	| PlaceName      | Longitude | Latitude | 
	| Alt Bennebek   | 9.4333    | 54.3833  | 
	| Klein Rheide   | 9.4833    | 54.45    | 
	| Kropp          | 9.5087    | 54.4111  | 
	| Klein Bennebek | 9.45      | 54.4     |
