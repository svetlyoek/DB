USE DataDemo;
CREATE TABLE Drivers
(DriverID   INT
 PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
 DriverName VARCHAR(50)
);
CREATE TABLE Cars
(CarID    INT
 PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
 DriverID INT, 
 CONSTRAINT FK_Cars_Drtivers FOREIGN KEY(DriverID) REFERENCES Drivers(DriverID),
);