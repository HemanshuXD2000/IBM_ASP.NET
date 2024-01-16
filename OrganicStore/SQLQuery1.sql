create table products(
id int Primary Key Identity(1,1),
p_name varchar(255),
details varchar(255),
category varchar(255),
s_price float,
o_price float,
img image);

Select * from products;

insert into products(p_name, details, s_price, o_price) values ('Onion', 'Onions of 45-55mm diameter are ideal for home cooking.',46.00,51.00);

drop table products;

INSERT INTO products(img) SELECT BulkColumn FROM Openrowset(Bulk 'C:\Users\HemanshuDharmik\Pictures\Onion.png' , Single_blob  ) as img where id equals to 1;

Drop table products;

Insert into products (p_name, details, category, s_price, o_price, img) values ('Onion', 'Onions of 45-55mm diameter are ideal for home cooking.','Veggie',46.00,51.00,(Select BulkColumn FROM OPENROWSET(BULK 'C:\Users\HemanshuDharmik\Pictures\Onion.png', SINGLE_BLOB) AS ImageData));