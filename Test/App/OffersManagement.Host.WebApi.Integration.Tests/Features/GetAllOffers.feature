Feature: GetAllOffers

@tag1
Scenario: GetAllOffers
	Given offer controller		
	When try to get all affers
	Then the http response status is ok
	Then all offers are geted
