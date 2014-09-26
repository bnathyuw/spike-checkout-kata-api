Feature: Bad request
	In order to develop a robust implementation
	As a developer using the API
	I want to receive useful validation messages

Scenario: Bad add item request
	Given I have a basket
	When I try to add 123 to my basket
	Then I get a Bad Request response
	And I get an invalid request error for value 123