CREATE PROC usp_WithdrawMoney
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
        IF(@MoneyAmount < 0)
            BEGIN
                ROLLBACK;
                RAISERROR('Money must be positive!', 16, 1);
                RETURN;
        END;
        IF(@Account IS NULL
           OR @Account <= 0)
            BEGIN
                ROLLBACK;
                RAISERROR('Invalid Id!', 16, 1);
                RETURN;
        END;
        UPDATE Accounts
          SET 
              Balance-=@MoneyAmount
        WHERE Id = @AccountId;
    END;
        