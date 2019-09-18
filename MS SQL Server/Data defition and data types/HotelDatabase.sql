CREATE DATABASE Hotel;

USE Hotel;

CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
FirstName VARCHAR(20) NOT NULL,
LastName VARCHAR(20) NOT NULL,
Title VARCHAR(20),
Notes NVARCHAR(100)
);

INSERT INTO Employees (FirstName,LastName) VALUES
('Ivan', 'Ivanov'),
('Dido', 'Ivanov'),
('Pencho', 'Dimitrov');


CREATE TABLE Customers (
AccountNumber INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
FirstName VARCHAR(20) NOT NULL,
LastName VARCHAR(20) NOT NULL,
PhoneNumber INT NOT NULL,
EmergencyName VARCHAR(20),
EmergencyNumber INT NOT NULL,
Notes NVARCHAR(MAX)
);

INSERT INTO Customers (Firstname,LastName,PhoneNumber, EmergencyNumber) VALUES
('Ivan', 'Ivanov',487575,21),
('Dido', 'Ivanov',293475,12),
('Pencho', 'Dimitrov',28465634,63456);


CREATE TABLE RoomStatus (
RoomStatus VARCHAR(10) PRIMARY KEY NOT NULL CHECK(RoomStatus = 'Free' OR RoomStatus = 'Occupied' OR RoomStatus = 'Half'),
Notes VARCHAR(MAX)
);

INSERT INTO RoomStatus (RoomStatus) VALUES
('Free'),
('Occupied'),
('Half');

CREATE TABLE RoomTypes (
RoomType VARCHAR(20) PRIMARY KEY NOT NULL CHECK(RoomType = 'Apartment' OR RoomType = 'Single' OR RoomType = 'Double'),
Notes NVARCHAR(MAX)
);


INSERT INTO RoomTypes (RoomType) VALUES
('Single'),
('Double'),
('Apartment');


CREATE TABLE BedTypes (
BedType VARCHAR(20) PRIMARY KEY NOT NULL CHECK(BedType = 'Single' OR BedType = 'Double' OR BedType = 'Triple'),
Notes NVARCHAR(MAX)
);

INSERT INTO BedTypes (BedType) VALUES
('Single'),
('Double'),
('Triple');

CREATE TABLE Rooms (
RoomNumber INT PRIMARY KEY  NOT NULL,
RoomType VARCHAR(20) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
BedType VARCHAR(20) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
Rate INT,
RoomStatus VARCHAR(10) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
Notes NVARCHAR(MAX)
);

INSERT INTO Rooms (RoomNumber,RoomType,BedType,RoomStatus) VALUES
(1,'Double','Single','Free'),
(21,'Apartment','Triple','Free'),
(12,'Single','Single','Half');


CREATE TABLE Payments (
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
PaymentDate DATETIME,
AccountNumber INT,
FirstDateOccupied DATETIME,
LastDateOccupied DATETIME,
TotalDays INT,
AmountCharged DECIMAL(15,2),
TaxRate INT,
TaxAmount DECIMAL (15,2),
PaymentTotal DECIMAL (15,2),
Notes NVARCHAR(MAX)
);

INSERT INTO Payments (EmployeeId) VALUES
(1),
(2),
(3);


CREATE TABLE Occupancies (
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
DateOccupied DATETIME,
AccountNumber INT NOT NULL,
[RoomNumber] INT, 
[RateApplied] INT, 
[PhoneCharge] INT, 
[Notes] VARCHAR(MAX)
);

INSERT INTO Occupancies (EmployeeId,AccountNumber) VALUES
(1,23),
(2,45),
(3,56);

