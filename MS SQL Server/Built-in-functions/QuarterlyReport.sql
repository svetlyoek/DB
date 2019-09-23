CREATE DATABASE NewDatabase;
USE NewDatabase;
CREATE TABLE Invoice
(InvoiceId   INT
 PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
 InvoiceData DATETIME, 
 Total       DECIMAL(15, 2)
);
INSERT INTO Invoice
(InvoiceData, 
 Total
)
VALUES
(GETDATE(), 
 1.98
),
(GETDATE(), 
 3.96
),
(GETDATE(), 
 5.94
),
(GETDATE(), 
 8.91
);
SELECT InvoiceId, 
       Total, 
       DATEPART(quarter, InvoiceData) AS [Quarter], 
       DATEPART(month, InvoiceData) AS [Month], 
       DATEPART(year, InvoiceData) AS [Year], 
       DATEPART(day, InvoiceData) AS [Day]
FROM Invoice;