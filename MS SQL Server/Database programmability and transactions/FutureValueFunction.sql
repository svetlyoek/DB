CREATE FUNCTION ufn_CalculateFutureValue
(@Sum                DECIMAL(15, 4), 
 @YearlyInterestRate FLOAT, 
 @NumberOfYears      INT
)
RETURNS DECIMAL(15, 4)
AS
     BEGIN
         DECLARE @FutureValueSum DECIMAL(15, 4);
         SET @FutureValueSum = @Sum * (POWER(1 + @YearlyInterestRate, @NumberOfYears));
         RETURN @FutureValueSum;
     END;
SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5) AS [Output];