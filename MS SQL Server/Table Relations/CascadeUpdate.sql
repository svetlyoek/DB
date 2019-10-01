CREATE TABLE Products
(BarcodeId INT
 PRIMARY KEY, 
 Name      VARCHAR(50)
);
CREATE TABLE Stock
(Id      INT
 PRIMARY KEY, 
 Barcode INT
);
ALTER TABLE Stock
ADD CONSTRAINT FK_Stock_Products FOREIGN KEY(Barcode) REFERENCES Products(BarcodeId) ON UPDATE CASCADE;
DROP TABLE Stock;;