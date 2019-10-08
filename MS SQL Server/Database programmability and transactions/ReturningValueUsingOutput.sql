CREATE PROCEDURE usp_AddNumbers
(@FirstNumber  INT, 
 @SecondNumber INT, 
 @Result       INT OUTPUT
)
AS
     SET @Result = @FirstNumber + @SecondNumber;
     DECLARE @Answer INT;
     EXEC usp_AddNumbers 
          5, 
          6, 
          @Answer OUTPUT;
     SELECT 'The result is: ', 
            @Answer;