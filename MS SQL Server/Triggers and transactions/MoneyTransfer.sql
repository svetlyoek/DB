CREATE PROC usp_TransferMoney
(@SenderId   INT, 
 @ReceiverId INT, 
 @Amount     DECIMAL(15, 4)
)
AS
    BEGIN TRANSACTION;
        EXEC dbo.usp_DepositMoney 
             @ReceiverId, 
             @Amount;
        EXEC dbo.usp_WithdrawMoney 
             @SenderId, 
             @Amount;
        IF(@Amount < 0)
            BEGIN
                ROLLBACK;
                RAISERROR('Amount must be positive!', 16, 1);
                RETURN;
        END;
        COMMIT;
        EXEC dbo.usp_TransferMoney 
             5, 
             1, 
             5000;