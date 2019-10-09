CREATE PROC usp_GetHoldersFullName
AS
    BEGIN
        SELECT concat(ah.FirstName, ' ', ah.LastName) AS [Full Name]
        FROM AccountHolders AS ah;
    END;
        EXEC usp_GetHoldersFullName;