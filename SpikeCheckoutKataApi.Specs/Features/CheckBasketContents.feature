Feature: Check basket contents
	In order to be confident that my order will be handled correctly
	As a shopper
	I want to be able to check what is in my basket

Scenario: Empty basket is empty
	Given I have a basket
	When I check my basket
	Then I have nothing in my basket

Scenario Outline: Items I add to my basket show up when I check my basket
	Given I have a basket
	And I add <items> to my basket
	When I check my basket
	Then my basket contains <items>

Examples: 
	| items  |
	| A      |
	| B      |
	| AABBCD |

Scenario: Items I remove from my basket no longer appear in my basket
	Given I have a basket
	And I add A to my basket
	And I remove that item from my basket
	When I check my basket
	Then I have nothing in my basket