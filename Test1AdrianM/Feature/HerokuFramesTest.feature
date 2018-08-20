Feature: HerokuFramesTest
	

Scenario: Simple Test with iFrame
	Given Move to iFrame page
	When I press add
	Then the result should be 120 on the screen
