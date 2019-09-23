SELECT DATEPART(year, '2017/09/25');
SELECT DATEPART(month, '2017/09/25');
SELECT DATEPART(day, '2017/09/25') AS DatePartInt;
USE SoftUni;
SELECT *
FROM Employees;
SELECT EmployeeId, 
       FirstName, 
       LastName, 
       Salary, 
       DATEDIFF(year, HireDate, GETDATE()) AS [YearsWorked]
FROM Employees;
SELECT DATENAME(weekday, GETDATE());
SELECT DATEADD(year, 2, '2018/12/29');
SELECT EOMONTH(GETDATE());
