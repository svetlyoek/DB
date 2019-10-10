CREATE TRIGGER tr_townsUpdate ON Towns
FOR UPDATE
AS
     IF(EXISTS
     (
         SELECT *
         FROM inserted
         WHERE Name IS NULL
               OR LEN(Name) = 0
     ))
         BEGIN
             RAISERROR('Town name cannot be null!', 16, 1);
             ROLLBACK;
             RETURN;
     END;
     UPDATE Towns
       SET 
           [Name] = ''
     WHERE TownID = 1;