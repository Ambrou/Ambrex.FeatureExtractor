Feature: EcritureDesScenarios
	In order to get all scenarios in files
	As a lazy developer
	I want to the scenarios written in a file

@ecriture
Scenario: Ecriture d'un scénario
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
