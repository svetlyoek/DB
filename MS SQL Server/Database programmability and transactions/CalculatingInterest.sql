CREATE PROC usp_CalculateFutureValueForAccount
(@AccountId    INT, 
 @InterestRate FLOAT
)
AS
    BEGIN
        SELECT a.Id AS [Account Id], 
               ah.FirstName AS [First Name], 
               ah.Lastname AS [Last Name], 
               a.Balance AS [Current Balance], 
               dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) AS [Balance in 5 years]
        FROM Accounts AS a
             JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
        WHERE a.Id = @AccountId;
    END;
        EXEC dbo.usp_CalculateFutureValueForAccount 
             1, 
             0.1;