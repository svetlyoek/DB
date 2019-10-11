CREATE TABLE NotificationEmails
(Id        INT
 PRIMARY KEY NOT NULL IDENTITY, 
 Recipient INT, 
 [Subject] NVARCHAR(50), 
 [Body]    NVARCHAR(100)
);
CREATE TRIGGER tr_updateEmail ON Logs
FOR INSERT
AS
     BEGIN
         DECLARE @Recipient INT=
         (
             SELECT i.AccountId
             FROM inserted AS i
         );
         DECLARE @OldSum DECIMAL(15, 2)=
         (
             SELECT d.OldSum
             FROM deleted AS d
         );
         DECLARE @NewSum DECIMAL(15, 2)=
         (
             SELECT i.NewSum
             FROM inserted AS i
         );
         INSERT INTO NotificationEmails
         (Recipient, 
          [Subject], 
          [Body]
         )
         VALUES
         (@Recipient, 
          'Balance change for account: ' + CAST(@Recipient AS VARCHAR(20)), 
          'On' + CAST(GETDATE() AS VARCHAR(20)) + 'your balance was changed from' + CAST(@OldSum AS VARCHAR(50)) + 'to' + CAST(@NewSum AS VARCHAR(50)) + '.'
         );
     END;