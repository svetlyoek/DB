CREATE TABLE Majors
(MajorID INT
 PRIMARY KEY IDENTITY NOT NULL, 
 [Name]  VARCHAR(50)
);
CREATE TABLE Students
(StudentID     INT
 PRIMARY KEY IDENTITY NOT NULL, 
 StudentNumber INT NOT NULL, 
 StudentName   NVARCHAR(50) NOT NULL, 
 MajorID       INT, 
 CONSTRAINT PK_Students_Majors FOREIGN KEY(MajorID) REFERENCES Majors(MajorID)
);
CREATE TABLE Payments
(PaymentID      INT
 PRIMARY KEY IDENTITY NOT NULL, 
 PaymentDate    DATE, 
 PaymentAccount NVARCHAR(50), 
 StudentID      INT, 
 CONSTRAINT PK_Payments_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID)
);
CREATE TABLE Subjects
(SubjectID   INT
 PRIMARY KEY IDENTITY NOT NULL, 
 SubjectName NVARCHAR(50)
);
CREATE TABLE Agenda
(StudentID INT, 
 SubjectID INT, 
 CONSTRAINT PK_Composite_Agenda PRIMARY KEY(StudentID, SubjectID), 
 CONSTRAINT FK_Agenda_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID), 
 CONSTRAINT FK_Agenda_Subjects FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID)
);