Feature: Check basket contents
	In order to be confident that my order will be handled correctly
	As a shopper
	I want to be able to check what is in my basket

Scenario: Empty basket is empty
	Given I have a basket
	When I check my basket
	Then I have nothing in my basket

Scenario: Things I add to my basket show up when I check my basket
	Given I have a basket
	And I add A to my basket
	When I check my basket
	Then my basket contains A