CREATE TABLE PeopleDemo
(Id          INT
 PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
 [Name]      VARCHAR(20) NOT NULL, 
 [Birthdate] DATETIME NOT NULL
);
INSERT INTO PeopleDemo
([Name], 
 [Birthdate]
)
VALUES
('Victor', 
 '2000-12-07'
),
('Steven', 
 '1992-09-10'
),
('Stephen', 
 '1910-09-19'
),
('John', 
 '2010-01-06'
);
SELECT [Name], 
       DATEDIFF(year, [Birthdate], GETDATE()) AS [Age in Years], 
       DATEDIFF(month, [Birthdate], GETDATE()) AS [Age in Months], 
       DATEDIFF(day, [Birthdate], GETDATE()) AS [Age in Days], 
       DATEDIFF(minute, [Birthdate], GETDATE()) AS [Age in Minutes]
FROM PeopleDemo;