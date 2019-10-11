CREATE TRIGGER tr_deletedEmployees ON Employees
FOR DELETE
AS
     BEGIN
         INSERT INTO Deleted_Employees
         (FirstName, 
          LastName, 
          MiddleName, 
          JobTitle, 
          DepartmentId, 
          Salary
         )
                SELECT d.FirstName, 
                       d.LastName, 
                       d.MiddleName, 
                       d.JobTitle, 
                       d.DepartmentId, 
                       d.Salary
                FROM deleted AS d;
     END;