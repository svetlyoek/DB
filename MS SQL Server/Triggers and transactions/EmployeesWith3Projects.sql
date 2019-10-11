CREATE PROC usp_AssignProject
(@EmloyeeId INT, 
 @ProjectID INT
)
AS
    BEGIN TRANSACTION;
        DECLARE @EmployeeProjectCount INT=
        (
            SELECT COUNT(ep.ProjectId)
            FROM Employees AS e
                 JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
            WHERE e.EmployeeID = @EmloyeeId
        );
        IF(@EmployeeProjectCount >= 3)
            BEGIN
                ROLLBACK;
                RAISERROR('The employee has too many projects!', 16, 1);
                RETURN;
        END;
        INSERT INTO EmployeesProjects
        (EmployeeID, 
         ProjectID
        )
        VALUES
        (@EmloyeeId, 
         @ProjectId
        );
        COMMIT;