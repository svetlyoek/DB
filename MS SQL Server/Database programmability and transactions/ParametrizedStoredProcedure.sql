CREATE PROCEDURE usp_SelectEmployeesBySeniority(@MinYearsWorked INT = 5)
AS
     SELECT e.FirstName, 
            e.Salary, 
            DATEDIFF(year, e.HireDate, GETDATE()) AS years
     FROM Employees AS e
     WHERE DATEDIFF(year, e.HireDate, GETDATE()) > @MinYearsWorked
     ORDER BY e.HireDate;
     EXEC usp_SelectEmployeesBySeniority;