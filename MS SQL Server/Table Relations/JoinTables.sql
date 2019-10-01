SELECT *
FROM Cars c
     JOIN Drivers d ON c.CarID = d.DriverID;
SELECT c.CarID, 
       d.DriverName
FROM Cars c
     JOIN Drivers d ON c.CarID = d.DriverId;