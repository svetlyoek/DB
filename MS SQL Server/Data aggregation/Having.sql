SELECT DepartmentID, 
       MIN(Salary) AS [MinSalary]
FROM Employees
GROUP BY DepartmentID
HAVING SUM(Salary) >= 15000
ORDER BY DepartmentID DESC;