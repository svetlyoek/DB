USE SoftUni;
SELECT e.FirstName, 
       e.LastName, 
       e.HireDate, 
       d.[Name] AS [DeptName]
FROM employees AS e
     JOIN Departments AS d ON(d.DepartmentID = e.DepartmentID
                              AND e.HireDate > '1/1/1999')
WHERE d.Name IN('Sales', 'Finance')
ORDER BY e.HireDate;