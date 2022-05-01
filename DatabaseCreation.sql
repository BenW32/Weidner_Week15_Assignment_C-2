USE [master]
GO

CREATE DATABASE [Group2_CompRepair]
GO
USE [Group2_CompRepair]
GO
SET QUOTED_IDENTIFIER ON
GO

--Customer Table
CREATE TABLE dbo.Customers
(
	Customer_Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Customer_Firstname CHAR(50),
	Customer_Lastname CHAR(50),
	Customer_Phone CHAR(12),
	Customer_Email VARCHAR(50),
	Customer_Address CHAR(50)
)
GO

--Employees Table
CREATE TABLE dbo.Employees
(
	Employee_Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Employee_Firstname CHAR(50),
	Employee_Lastname	CHAR(50),
	Employee_Phone CHAR(12),
	Employee_Email VARCHAR(50),
	Employee_Address CHAR(50)
)
GO

--Orders Table
CREATE TABLE dbo.Orders
(
	Order_Id INT NOT NULL IDENTITY(1,1),
	Customer_Id INT NOT NULL,
	Employee_Id INT NOT NULL,
	Order_total DECIMAL(19, 2),
	Order_Date DATETIME,
	PRIMARY KEY(Order_Id),
	CONSTRAINT FK_Customer_Id FOREIGN KEY (Customer_Id) REFERENCES Customers(Customer_Id),
	CONSTRAINT FK_Employee_Id FOREIGN KEY (Employee_Id) REFERENCES Employees(Employee_Id)
)
GO

--Computer Parts Table
CREATE TABLE dbo.Computer_Parts
(
	Computer_Parts_Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Part_Name CHAR(100),
	Part_Description VARCHAR(max),
	Parts_in_Stock INT,
	Part_Type VARCHAR(50),
	Part_Price DECIMAL(19, 2),
)
GO

--Parts_Orders_Linking Table
CREATE TABLE dbo.Parts_Orders_Linking
(
	Parts_Orders_Id INT NOT NULL IDENTITY(1,1),
	Order_Id INT NOT NULL,
	Computer_Parts_Id INT NOT NULL,
	Qty_Of_Parts INT,
	PRIMARY KEY (Parts_Orders_Id),
	CONSTRAINT FK_Orders_Id FOREIGN KEY (Order_Id) REFERENCES Orders(Order_Id),
	CONSTRAINT FK_Computer_Parts_Id FOREIGN KEY (Computer_Parts_Id) REFERENCES Computer_Parts(Computer_Parts_Id)
)
GO

--Software Table
CREATE TABLE dbo.Software
(
	Software_Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Software_Name VARCHAR(50),
	Software_Description VARCHAR(max),
	Licenses_In_Stock INT,
	Software_Type VARCHAR(50),
	Software_Price DECIMAL(19, 2)
)
GO

--Software orders linking table
CREATE TABLE dbo.Software_Orders_Linking
(
	Software_Orders_Id INT IDENTITY(1,1) NOT NULL,
	Order_Id INT NOT NULL,
	Software_Id INT NOT NULL,
	PRIMARY KEY (Software_Orders_Id),
	CONSTRAINT FK_Order_Id FOREIGN KEY (Order_Id) REFERENCES Orders(Order_Id),
	ConstraINT FK_Software_Id FOREIGN KEY (Software_Id) REFERENCES Software(Software_Id)
)
GO

INSERT INTO Customers(Customer_Firstname, Customer_Lastname, Customer_Phone, Customer_Email, Customer_Address)
VALUES ('Cory', 'Kennedy', '320-266-7829', 'test01@gmail.com', '7187 Lincoln Ave S, Saint Cloud MN'),
('Breanna', 'Micheals', '320-266-7855', 'test02@gmail.com', '7188 Lincoln Ave S, Saint Cloud MN'),
('Micheal', 'Howard', '320-266-7866', 'test03@gmail.com', '7189 Lincoln Ave S, Saint Cloud MN'),
('Andrew', 'Reynolds', '320-266-7877', 'test04@gmail.com', '7190 Lincoln Ave S, Saint Cloud MN'),
('Todd', 'Howard', '320-266-7866', 'test05@gmail.com', '7191 Lincoln Ave S, Saint Cloud MN'),
('Ron', 'Weasley', '320-266-7890', 'test06@gmail.com', '7192 Lincoln Ave S, Saint Cloud MN'),
('Paul', 'Rodrigeuz', '320-266-7893', 'test07@gmail.com', '7193 Lincoln Ave S, Saint Cloud MN'),
('Sarah', 'Nickelson', '320-266-7835', 'test08@gmail.com', '7194 Lincoln Ave S, Saint Cloud MN'),
('Victoria', 'Wednz', '320-266-7844', 'test09@gmail.com', '7195 Lincoln Ave S, Saint Cloud MN'),
('Macie', 'Fins', '320-266-7233', 'test10@gmail.com', '7196 Lincoln Ave S, Saint Cloud MN')
GO

INSERT INTO Employees(Employee_Firstname, Employee_Lastname, Employee_Phone, Employee_Email, Employee_Address)
VALUES ('Dustin', 'Massey', '320-266-7829', 'test01@gmail.com', '7187 Lincoln Ave S, Saint Cloud MN'),
('Monique', 'Fox', '320-266-7855', 'test02@gmail.com', '7188 Lincoln Ave S, Saint Cloud MN'),
('Roxanne', 'Bennett', '320-266-7866', 'test03@gmail.com', '7189 Lincoln Ave S, Saint Cloud MN'),
('Samuel', 'Peterson', '320-266-7877', 'test04@gmail.com', '7190 Lincoln Ave S, Saint Cloud MN'),
('Dewey', 'Myers', '320-266-7866', 'test05@gmail.com', '7191 Lincoln Ave S, Saint Cloud MN'),
('Marguerite', 'Henderson', '320-266-7890', 'test06@gmail.com', '7192 Lincoln Ave S, Saint Cloud MN'),
('Beverly', 'Meyer', '320-266-7893', 'test07@gmail.com', '7193 Lincoln Ave S, Saint Cloud MN'),
('Deanna', 'Howard', '320-266-7835', 'test08@gmail.com', '7194 Lincoln Ave S, Saint Cloud MN'),
('Dominick ', 'Lee', '320-266-7844', 'test09@gmail.com', '7195 Lincoln Ave S, Saint Cloud MN'),
('Sophia', 'Walters', '320-266-7233', 'test10@gmail.com', '7196 Lincoln Ave S, Saint Cloud MN')
GO

INSERT INTO Computer_Parts(Part_Name, Part_Description, Parts_in_Stock, Part_Type, Part_Price)
VALUES ('Samsung 883', 'Memory', 2, 'Hard Drive', 80.00),
('Nvidia GeForce GTX 1060', 'Gaming Graphics Card', 3, 'Graphics Card', 100.00),
('Seagate Barracuda', 'Memory', 4, 'SSD', 120.00),
('Kingwin 80mm Silent Fan', 'Cooling', 10, 'Fans', 80.00),
('Linksys AC1200', 'WiFI', 5, 'WiFI Adapter', 60.00),
('Logitech K350', 'Casual Keyboard', 7, 'Keyboard', 20.00),
('Razor Deathadder Elite', 'Gaming Mouse', 3, 'Mouse', 70.00),
('AMD - Ryzen 7 5800X', 'CPU', 2, 'CPU', 300.00),
('CORSAIR VS Series VS600', 'Gaming Power Supply', 4, 'Power Supply', 34.00),
('Cooler Master MasterBox Q300L', 'Computer Case', 4, 'Computer Case', 52.00)
GO

INSERT INTO Software(Software_Name, Software_Description, Licenses_In_Stock, Software_Type, Software_Price)
VALUES ('Windows 10 Professional', 'Operating System', 10, 'Digital', 149.99),
('Windows 11 Professional', 'Operating System', 10, 'Digital', 199.99),
('Avast Ultimate', 'Security', 10, 'Digital', 239.99),
('Norton360 Deluxe', 'Security', 10, 'Digital', 74.99),
('Driver Booster', 'Driver Updater', 10, 'Digital', 22.95),
('AVG TuneUp', 'Utility', 10, 'Digital', 39.99)
GO

INSERT INTO Orders(Customer_Id,Employee_Id,Order_total,Order_Date)
VALUES (2,3,149.99,'2022-03-15 08:30:00'),
(7,1,100.00,'2022-03-21 12:30:00'),
(4,10,199.99,'2022-03-23 17:30:00'),
(6,7,300.00,'2022-03-27 13:30:00'),
(6,7,52.00,'2022-03-29 10:30:00')
GO

INSERT INTO Parts_Orders_Linking(Order_Id,Computer_Parts_Id,Qty_Of_Parts)
VALUES (2,2,1),
(4,8,1),
(5,10,1)
GO

INSERT INTO Software_Orders_Linking(Order_Id,Software_Id)
VALUES (1,1),
(3,2)
