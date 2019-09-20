USE SoftUni;
SELECT *
FROM Employees;
SELECT DISTINCT 
       DepartmentId
FROM Employees;
SELECT FirstName, 
       DepartmentId
FROM Employees
WHERE DepartmentId = 1;
SELECT FirstName, 
       JobTitle, 
       Salary
FROM Employees
WHERE Salary = 30000;
SELECT LastName
FROM Employees
WHERE Salary >= 30000
      AND Salary <= 80000;
SELECT FirstName, 
       LastName, 
       Salary
FROM Employees
WHERE Salary BETWEEN 30000 AND 90000;
SELECT EmployeeId, 
       Salary
FROM Employees
WHERE NOT(Salary = 12500
          OR Salary = 37500);
SELECT EmployeeId, 
       FirstName, 
       LastName, 
       JobTiTle
FROM Employees
WHERE EmployeeId IN(1, 5, 6);
SELECT FirstName, 
       LastName
FROM Employees
WHERE ManagerId IS NULL;
SELECT FirstName + ' ' + LastName AS [FirstName], 
       JobTitle
FROM Employees
WHERE ManagerId IS NOT NULL;