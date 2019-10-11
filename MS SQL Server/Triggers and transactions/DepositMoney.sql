CREATE PROC usp_DepositMoney
(@AccountId   INT, 
 @MoneyAmount DECIMAL(15, 4)
)
AS
    BEGIN
        DECLARE @Account INT=
        (
            SELECT a.Id
            FROM Accounts AS a
            WHERE a.Id = @AccountId
        );
        IF(@Account <= 0)
            BEGIN
                ROLLBACK;
                RAISERROR('Invalid account Id!', 16, 1);
                RETURN;
        END;
        IF(@MoneyAmount < 0
           OR @MoneyAmount IS NULL)
            BEGIN
                ROLLBACK;
                RAISERROR('Money must be positive!', 16, 1);
                RETURN;
        END;
        UPDATE Accounts
          SET 
              Balance+=@MoneyAmount
        WHERE Id = @AccountId;
    END;
        EXEC dbo.usp_DepositMoney 
             1, 
             10;