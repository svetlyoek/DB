CREATE PROC usp_withdraw
(@WithdrawAmount DECIMAL(15, 2), 
 @UserId         INT
)
AS
    BEGIN TRANSACTION;
        UPDATE Accounts
          SET 
              Balance-=@WithdrawAmount
        WHERE Id = @UserId;
        IF(Id <> 1)
            BEGIN
                ROLLBACK;
                RAISERROR('Invalid account!', 16, 1);
                RETURN;
        END;
        COMMIT;