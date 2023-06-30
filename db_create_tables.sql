DROP TYPE IF EXISTS product;
CREATE TABLE product (
  id INT PRIMARY KEY,
  name VARCHAR,
  brand VARCHAR,
  size VARCHAR
);

DROP TYPE IF EXISTS price;
CREATE TABLE  price (
  product_id INT NOT NULL,
  value numeric(10,2) NOT NULL
);

DROP TYPE IF EXISTS stock;
CREATE TABLE  stock (
  product_id INT NOT NULL,
  quantity INT NOT NULL
);

