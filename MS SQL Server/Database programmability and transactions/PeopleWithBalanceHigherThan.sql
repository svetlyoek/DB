CREATE PROC usp_GetHoldersWithBalanceHigherThan(@TotalMoney DECIMAL(15, 2))
AS
    BEGIN
        SELECT ah.FirstName, 
               ah.LastName
        FROM AccountHolders AS ah
             JOIN Accounts AS a ON ah.Id = a.AccountHolderId
        GROUP BY ah.FirstName, 
                 ah.LastName
        HAVING SUM(a.Balance) > @TotalMoney
        ORDER BY ah.FirstName, 
                 ah.LastName;
    END;
        EXEC usp_GetHoldersWithBalanceHigherThan 
             45000;