Feature: UpdateOffer

Scenario: update offer
	Given the existing offer to update
		| ProductId | ProductName | ProductBrand | ProductSize | Price | Quantity |
		| 1         | T-Shirt     | Sarenza      | XXL         | 30    | 100      |
	When update product size price and quantity
	Then the update http response status is ok
	Then the product info price info and stock info are updated
