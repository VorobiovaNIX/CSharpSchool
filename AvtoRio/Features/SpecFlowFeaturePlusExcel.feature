Feature: SpecFlowFeaturePlusExcel
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Add two numbers
	Given I have entered <number1> into the calculator
	And I have entered <number2> into the calculator
	When I press add
	Then the result should be <result> on the screen

@source:data.xlsx
Examples: 
|number1|number2|result|
|50|70|120|