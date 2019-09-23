SELECT *
FROM Employees;
SELECT FirstName
FROM Employees
WHERE FirstName LIKE 'G%';
SELECT LastName
FROM Employees
WHERE LastName LIKE '%o';
SELECT FirstName
FROM Employees
WHERE FirstName LIKE '[A-C]%'
ORDER BY FirstName DESC;
SELECT FirstName
FROM Employees
WHERE FirstName LIKE '%ch%';
SELECT FirstName
FROM Employees
WHERE FirstName LIKE '%[^chael]';
SELECT FirstName
FROM Employees
WHERE FirstName LIKE '%chael%';
SELECT Firstname
FROM Employees
WHERE Firstname LIKE '%Michael!%' ESCAPE '!';