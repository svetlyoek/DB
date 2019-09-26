SELECT DepartmentID, 
       MIN(Salary) AS [MinSalary]
FROM Employees
GROUP BY DepartmentID
ORDER BY MinSalary, 
         DepartmentID DESC;
SELECT JobTitle, 
       COUNT(Salary) AS [JobTitle Count]
FROM Employees
GROUP BY JobTitle;
SELECT FirstName, 
       AVG(Salary) AS [AvgSalary]
FROM Employees
GROUP BY FirstName;
SELECT FirstName, 
       STRING_AGG(Salary, '; ') WITHIN GROUP(ORDER BY Salary) AS [NewSalary]
FROM Employees
GROUP BY FirstName;