CREATE TABLE EmployeesDemo
(EmployeeID   INT
 PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
 EmployeeName VARCHAR(50)
);
CREATE TABLE ProjectsDemo
(ProjectID   INT
 PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
 ProjectName VARCHAR(30)
);
CREATE TABLE EmployeesProjectsDemo
(EmployeeID INT, 
 ProjectID  INT, 
 CONSTRAINT PK_EmployeesProjects_Demo PRIMARY KEY(EmployeeID, ProjectID), 
 CONSTRAINT FK_EmployeesProjects_Employees_Demo FOREIGN KEY(EmployeeID) REFERENCES EmployeesDemo(EmployeeID), 
 CONSTRAINT FK_EmployeesProjects_Projects_Demo FOREIGN KEY(ProjectID) REFERENCES ProjectsDemo(ProjectID)
);