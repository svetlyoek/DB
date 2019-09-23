SELECT LastName, 
       SUBSTRING('Brown', 1, 3) AS [New Name]
FROM Employees;
SELECT SUBSTRING('SQL Tutorial', 3, 5) AS ExtractString;
SELECT REPLACE('Svetoslav', 'Sv', 'Po');
SELECT REPLACE(0878657463, 463, '* * *') AS [Encrypted Number];
SELECT LTRIM('         Svetoslav');
SELECT RTRIM('Svetoslav     ');
SELECT TRIM('   Svetoslav   ***') AS [Trimmed Result];
SELECT LEN('Svetoslav');
SELECT DATALENGTH('Svetoslav is here');
SELECT DATALENGTH('Svetoslav');
SELECT LEFT('Svetoslav', 4);
SELECT RIGHT('Svetoslav', 2);
SELECT LOWER('SvetosLav');
SELECT LOWER('SVETOSLAV');
SELECT UPPER('SvetosLav');
SELECT REVERSE('Svetoslav');
SELECT REPLICATE('Svetoslav', 3);
SELECT CHARINDEX('Svet', 'Svetoslav');
SELECT CHARINDEX('t', 'Svetoslav');
SELECT STUFF('I learn C#', 9, 2, 'Java');
SELECT TRANSLATE('2*[2+3]/{6*2}', '[]{}', '()()');
