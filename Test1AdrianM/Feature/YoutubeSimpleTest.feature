Feature: YoutubeSimpleTest

@SpecFlowTestTraining
Scenario: Find Objectivity on Youtube(variable)
	Given Youtube page is opened
	When I put in search 'Objectivity wroclaw' name
	And I click on search button
	And I choose Objectivity channel
	And I subscribe channel
	Then I can see question If I want to subsrcibe it

	Scenario: Find Something on Youtube2(CreationInstance)
	Given Youtube page is opened
	When I insert in search name on Youtube
	| SearchThing			|
	| Objectivity wroclaw	|
	And I click on search button
	And I choose Objectivity channel
	And I subscribe channel
	Then I can see question If I want to subsrcibe it

	Scenario: Find Something on Youtube3(CreationSet)
	Given Youtube page is opened
	When I insert in search name
	| SearchThing			|
	| Objectivity			|
	| Wroclaw				|
	| Poland				|
	And I click on search button
	And I choose Objectivity channel
	And I subscribe channel
	Then I can see question If I want to subsrcibe it
	
	Scenario Outline: Find Something on Youtube4(outline)
	Given Youtube page is opened
	When I insert in search name <channels>
	And I click on search button
	And I choose Objectivity channel
	And I subscribe channel
	Then I can see question If I want to subsrcibe it
	Examples: 
	| channels				|
	| Objectivity wroclaw	|
	| Dla Pieniedzy			|
	| Arlena Witt			|

	Scenario: Find first promoted movie on Youtube(ScenarioContext)
	Given Youtube page is opened
	When I found first movie on Youtube
	And I put in search Movie 
	And I click on search button
	Then I verify that this movie was opened