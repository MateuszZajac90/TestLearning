Feature: HerokuPasswordTest
	

@myTest
Scenario: Log in to application
	Given Password page is opened
	When I enter login 'tomsmith'
	And I enter super secret password: 'SuperSecretPassword!'
	And I click on log on button
	Then I checked that I am log in to app
