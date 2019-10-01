CREATE TABLE Students
(StudentID INT
 PRIMARY KEY IDENTITY NOT NULL, 
 [Name]    NVARCHAR(30) NOT NULL
);
CREATE TABLE Exams
(ExamID INT
 PRIMARY KEY NOT NULL, 
 [Name] NVARCHAR(30) NOT NULL
);
CREATE TABLE StudentsExams
(StudentID INT NOT NULL, 
 ExamID    INT NOT NULL, 
 PRIMARY KEY(StudentID, ExamID), 
 CONSTRAINT PK_StudentsExams_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID), 
 CONSTRAINT PK_StudentsExams_Exams FOREIGN KEY(ExamID) REFERENCES Exams(ExamID)
);
INSERT INTO Students([Name])
VALUES('Mila'), ('Toni'), ('Ron');
INSERT INTO Exams
(ExamID, 
 [Name]
)
VALUES
(101, 
 'SpringMVC'
),
(102, 
 'Neo4j'
),
(103, 
 'Oracle 11g'
);
INSERT INTO StudentsExams
(StudentID, 
 ExamID
)
VALUES
(1, 
 101
),
(1, 
 102
),
(2, 
 101
),
(3, 
 103
),
(2, 
 102
),
(2, 
 103
);