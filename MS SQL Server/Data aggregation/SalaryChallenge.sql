SELECT TOP (10) FirstName, 
                LastName, 
                DepartmentID
FROM Employees AS e1
WHERE Salary >
(
    SELECT AVG(salary) AS [AvgSalary]
    FROM Employees AS e2
    WHERE e1.DepartmentID = e2.DepartmentID
    GROUP BY departmentID
)
ORDER BY DepartmentID;