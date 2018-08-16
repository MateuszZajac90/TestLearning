Feature: HerokuSimpleTest

@SpecFlowTestTraining
Scenario: Use checkboxes
	Given Checkboxes HerokuApp page is opened
	When I sign checkbox
	Then I can see marked checkbox
	When I unsign checkbox
	Then I can see unmarked checkbox

	Scenario: Use both checkboxes
	Given Checkboxes HerokuApp page is opened
	When I sign checkbox
	Then I can see marked checkbox
	When I unsign checkbox
	And I unsign second checkbox
	Then I can see unmarked checkboxes

	Scenario: Use second value on dropdown
	Given Dropdown HerokuApp page is opened
	When I choose option number '2' on dropdown
	Then I can see choosen dropdown value
