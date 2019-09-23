USE Demo;
CREATE VIEW v_Payments
AS
     SELECT CustomerID, 
            FirstName, 
            LastName, 
            LEFT(PaymentNumber, 10) + '******' AS [EncryptedPayment]
     FROM Customers;
SELECT *
FROM v_Payments;