CREATE FUNCTION udf_ProjectDurationInWeeks
(@StartDate DATETIME, 
 @EndDate   DATETIME
)
RETURNS INT
AS
     BEGIN
         DECLARE @ProjectWeeks INT;
         IF(@EndDate IS NULL)
             BEGIN
                 SET @EndDate = GETDATE();
         END;
         SET @ProjectWeeks = DATEDIFF(week, @StartDate, @EndDate);
         RETURN @ProjectWeeks;
     END;
SELECT ProjectID, 
       StartDate, 
       EndDate, 
       dbo.udf_ProjectDurationInWeeks(StartDate, EndDate) AS ProjectWeeks
FROM Projects;