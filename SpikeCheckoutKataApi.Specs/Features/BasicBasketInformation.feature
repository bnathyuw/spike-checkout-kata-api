Feature: Basic basket information
	In order to be confident that my order will be handled correctly
	As a shopper
	I want to know that the shopping basket belongs to me

Scenario: Name is attached to basket
	Given I create a basket with the name Scroggins
	When I check my basket
	Then my basket is assigned to the name Scroggins
