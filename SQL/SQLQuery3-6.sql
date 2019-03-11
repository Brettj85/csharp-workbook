CREATE DATABASE Bretts_First_Database

CREATE TABLE Toys (
    ID int,
	Toy_Name varchar(20),
    Price float(9,2),
    Quantity int,
);
INSERT INTO Toys (ID, Toy_Name, Price, Quantity)
VALUES 
(0, 'car', 29.99, 7),
(1, 'Lego', 12.37, 4),
(2, 'Action Figure', 45.21, 8),
(3, 'Bike', 199.99, 10),
(4, 'Doll House', 52.57, 3),
(5, 'Barbie', 14.50, 17),
(6, 'Magic Booster', 4.99, 200),
(7, 'XBox', 400.00, 27),
(8, 'PlayStation', 379.99, 22),
(9, 'Switch', 200.00, 41);


DELETE FROM Toys WHERE Toy_Name='Doll House';

INSERT INTO Toys (ID, Toy_Name, Price, Quantity)
VALUES 
(4, 'Doll House', 52.57, 3);

CREATE TABLE Aisles (
    ID int,
	Aisle_Name varchar(20),
); 

INSERT INTO Aisles (ID, Toy_Name, Price, Quantity)
VALUES 
(0, 'Aisle One'),
(1, 'Aisle Two'),
(2, 'Aisle Three'),
(3, 'Aisle Four'),
(4, 'Aisle Five'),
(5, 'Aisle Six'),
(6, 'Aisle Seven'),
(7, 'Aisle Eight'),
(8, 'Aisle Nine'),
(9, 'Aisle Ten');


ALTER TABLE Toys
ADD FOREIGN KEY (Aisle_id) REFERENCES Aisles(ID);

SELECT Toy_name, Quantity, Aisle_id FROM Toys;