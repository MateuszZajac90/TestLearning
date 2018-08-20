Feature: HerokuFramesTest
	

Scenario: Simple Test with iFrame
	Given Move to iFrame page
	When Clear TextField
	And Put in TextField 'To jest moj testowy napis'
	Then Verify that text is presented