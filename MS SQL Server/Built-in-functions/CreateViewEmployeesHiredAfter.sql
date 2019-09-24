CREATE VIEW V_EmployeesHiredAfter2000
AS
     SELECT FirstName, 
            LastName
     FROM Employees
     WHERE CAST(DATEPART(year, HireDate) AS INT) > 2000;
SELECT *
FROM V_EmployeesHiredAfter2000;