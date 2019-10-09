CREATE FUNCTION ufn_CashInUsersGames
(@GameName NVARCHAR(50)
)
RETURNS TABLE
AS
     RETURN
     SELECT SUM(t.Cash) AS [SumCash]
     FROM
     (
         SELECT ug.Cash, 
                ROW_NUMBER() OVER(PARTITION BY g.[Name]
                ORDER BY ug.Cash DESC) AS [Ranking]
         FROM Games AS g
              JOIN UsersGames AS ug ON g.Id = ug.GameId
         WHERE g.Name = @GameName
     ) AS t
     WHERE t.[Ranking] % 2 <> 0;
SELECT *
FROM dbo.ufn_CashInUsersGames('Love in a mist');