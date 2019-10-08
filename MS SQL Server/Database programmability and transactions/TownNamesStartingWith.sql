CREATE PROC usp_GetTownsStartingWith(@StartWith NVARCHAR(10))
AS
    BEGIN
        SELECT t.[Name] AS [Town]
        FROM Towns AS t
        WHERE t.[Name] LIKE @StartWith + '%';
    END;
        EXEC usp_GetTownsStartingWith 
             b;