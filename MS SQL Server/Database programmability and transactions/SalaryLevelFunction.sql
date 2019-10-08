CREATE FUNCTION ufn_GetSalaryLevel
(@Salary DECIMAL
)
RETURNS VARCHAR(10)
AS
     BEGIN
         DECLARE @SalaryLevel VARCHAR(10);
         IF(@Salary < 30000)
             BEGIN
                 SET @SalaryLevel = 'Low';
         END;
             ELSE
             IF(@Salary BETWEEN 30000 AND 50000)
                 BEGIN
                     SET @SalaryLevel = 'Average';
             END;
                 ELSE
                 BEGIN
                     SET @SalaryLevel = 'High';
             END;
         RETURN @SalaryLevel;
     END;
SELECT e.FirstName, 
       e.LastName, 
       e.Salary, 
       dbo.ufn_GetSalaryLevel(e.Salary) AS [SalaryLevel]
FROM Employees AS e;