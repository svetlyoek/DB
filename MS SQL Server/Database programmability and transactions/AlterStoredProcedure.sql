ALTER PROCEDURE usp_SelectEmployeesBySeniority
AS
     SELECT e.FirstName, 
            e.Salary
     FROM Employees AS e
     WHERE e.Salary > 40000
     ORDER BY e.FirstName DESC;