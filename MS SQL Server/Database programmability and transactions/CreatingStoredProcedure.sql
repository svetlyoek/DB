CREATE PROCEDURE usp_SelectEmployeesBySeniority
AS
     SELECT *
     FROM Employees
     WHERE DATEDIFF(year, HireDate, GETDATE()) > 18;
     EXEC usp_SelectEmployeesBySeniority;