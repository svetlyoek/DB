USE SoftUni;
SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
FROM Employees;
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees;
SELECT CONCAT_WS(', ', 'MyName', NULL, 'YourName', NULL) AS [New Name]
FROM Employees;