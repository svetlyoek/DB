CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
    BEGIN
        SELECT e.FirstName AS [First Name], 
               e.LastName AS [Last Name]
        FROM Employees AS e
        WHERE e.Salary > 35000;
    END;
        EXEC usp_GetEmployeesSalaryAbove35000;