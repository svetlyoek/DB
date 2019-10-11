CREATE TABLE Logs
(LogId     INT
 PRIMARY KEY NOT NULL IDENTITY, 
 AccountId INT NOT NULL, 
 OldSum    DECIMAL(15, 2), 
 NewSum    DECIMAL(15, 2)
);
CREATE TRIGGER tr_updateBalance ON Accounts
FOR UPDATE
AS
     BEGIN
         DECLARE @AccountId INT=
         (
             SELECT i.Id
             FROM inserted AS i
         );
         DECLARE @OldSum DECIMAL(15, 2)=
         (
             SELECT d.Balance
             FROM deleted AS d
         );
         DECLARE @NewSum DECIMAL(15, 2)=
         (
             SELECT i.Balance
             FROM inserted AS i
         );
         INSERT INTO Logs
         (AccountId, 
          OldSum, 
          NewSum
         )
         VALUES
         (@AccountId, 
          @OldSum, 
          @NewSum
         );
     END;