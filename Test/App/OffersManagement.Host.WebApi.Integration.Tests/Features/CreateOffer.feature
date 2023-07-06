Feature: CreateOffer

@CleanInsertedOffer
Scenario: create Offer
	Given the offer to create
		| ProductId | ProductName | ProductBrand | ProductSize | Price | Quantity |
		| 100       | T-Shirt     | Sarenza      | M           | 20    | 100      |
	When add offer into offers data base
	Then the add http response status is ok 
	Then the product info price info and stock info are persisted 
