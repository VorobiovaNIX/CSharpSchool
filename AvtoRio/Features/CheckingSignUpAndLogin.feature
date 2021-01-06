Feature: CheckingSignUpAndLogin
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers.

	@SignUp 
Scenario Outline: Register user and check if the user cannot sign Up with already existing phone number
	Given I go to the web page 'https://auto.ria.com/'
	Then the web page is opened 'Автобазар №1. Купити і продати авто легко'
	And I click the Увійти в кабінет link 
	And I click the 'Зареєструватися на AUTO.RIA' link 
	When I enter <UserFirstName>, <UserLastName> and <PhoneNumber>
	And I click on 'Продовжити' button
	Then I should see <Result> message
Examples: 
	| UserFirstName | UserLastName | PhoneNumber   | Result                                       |
	| TestQA        | Test         | +380668235015 | Номер вже зареєстрований                     |
	| NewUser       | UserQA       | +111111        | "+111111" - невірний мобільний номер телефону |

	@Login
Scenario Outline: User can login with valid credentials
	Given I go to the web page 'https://auto.ria.com/'
	Then the web page is opened 'Автобазар №1. Купити і продати авто легко'
	And I click the Увійти в кабінет link
	When I enter <PhoneOrEmail> and <Password>
	And I click on 'Продовжити' button
	Then I should see <Result> message
Examples: 
	| PhoneOrEmail         | Password | Result            |
	| vorobbyova@gmail.com | qwerty   | Особистий кабінет |
	| +380668235015        | qwerty   | Особистий кабінет |
	| vorobbyova@gmail.com | qwertyyy | Невірний логін або пароль |
