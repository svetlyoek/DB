USE SoftUni;
UPDATE Employees
  SET 
      Salary*=Salary * 1.5
WHERE Salary BETWEEN 30000 AND 80000;
SELECT Salary
FROM Employees;
UPDATE Employees
  SET 
      FirstName = 'Moq FirstName'
WHERE EmployeeID = 1;
SELECT FirstName
FROM Employees;