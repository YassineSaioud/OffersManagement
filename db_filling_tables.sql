INSERT INTO
	product(id,name,brand,size)
VALUES 
	(1,'T-Shirt','Sarenza','S'),
    (2,'T-Shirt','Sarenza','M'),
    (3,'T-Shirt','Sarenza','L');


INSERT INTO
	price(product_id,value)
VALUES 
	(1,20.50),
	(2,40.20),
	(3,45.99);

INSERT INTO
	stock(product_id,quantity)
VALUES 
	(1,80),
	(2,100),
	(3,50);