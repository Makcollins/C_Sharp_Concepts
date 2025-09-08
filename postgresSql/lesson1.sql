CREATE TABLE products (
product_name VARCHAR(200),
price INTEGER

);

INSERT INTO products (product_name, price)
VALUES
('Dress',100),
('Running shoes',120),
('Tshirt',20);

SELECT * FROM products;

SELECT product_name FROM products;  

SELECT * FROM products 
WHERE price > 80

UPDATE products
SET price = 120
WHERE product_name = 'Jeans';

DELETE FROM products 
WHERE price < 80 ; 

ALTER TABLE products
ADD COLUMN in_stock VARCHAR(3);

UPDATE products
SET in_stock = 'Yes'
WHERE product_name = 'Jeans' OR product_name = 'Tshirt';

UPDATE products
SET in_stock = 2 WHERE product_name = 'Jeans';

UPDATE products
SET in_stock = 4 WHERE product_name = 'Tshirt'; 

ALTER TABLE products
ALTER COLUMN in_stock TYPE INTEGER
USING in_stock::integer;

CREATE TABLE supplier (
supplier_name VARCHAR
);

INSERT INTO supplier (supplier_name)
VALUES ('Calvin Klein'), ('Nike');

SELECT * FROM supplier;

ALTER TABLE supplier 
ADD COLUMN supplier_id INTEGER;

UPDATE supplier
SET supplier_id = CASE supplier_name
WHEN 'Calvin Klein' THEN 1
WHEN 'Nike' THEN 2
END;

ALTER TABLE products
ADD COLUMN supplier_id INTEGER;

UPDATE products
SET supplier_id = CASE product_name
WHEN 'Jeans' THEN 1
WHEN 'Running shoes' THEN 2
WHEN 'Tshirt' THEN 2
END;
