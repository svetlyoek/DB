CREATE FUNCTION ufn_IsWordComprised
(@SetOfLetters NVARCHAR(MAX), 
 @Word         NVARCHAR(MAX)
)
RETURNS BIT
AS
     BEGIN
         DECLARE @Index INT= 1;
         DECLARE @CurrentChar NVARCHAR;
         DECLARE @Result BIT;
         WHILE(@Index <= LEN(@Word))
             BEGIN
                 SET @CurrentChar = SUBSTRING(@Word, @Index, 1);
                 IF(CHARINDEX(@CurrentChar, @SetOfLetters) <= 0)
                     BEGIN
                         SET @Result = 0;
                         BREAK;
                 END;
                     ELSE
                     BEGIN
                         SET @Result = 1;
                         SET @Index+=1;
                 END;
             END;
         RETURN @Result;
     END;
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia') AS [Result];
SELECT dbo.ufn_IsWordComprised('bobr', 'Rob') AS [Result];
SELECT dbo.ufn_IsWordComprised('ppp', 'Guy') AS [Result];
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves') AS [Result];