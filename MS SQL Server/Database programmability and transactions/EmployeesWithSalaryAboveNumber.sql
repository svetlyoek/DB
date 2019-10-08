CREATE PROC usp_GetEmployeesSalaryAboveNumber(@Salary DECIMAL(18, 4))
AS
    BEGIN
        SELECT e.FirstName AS [First Name], 
               e.LastName AS [Last Name]
        FROM Employees AS e
        WHERE e.Salary >= @Salary;
    END;
        EXEC usp_GetEmployeesSalaryAboveNumber 
             48100;