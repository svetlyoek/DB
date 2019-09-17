CREATE TABLE Users
(
    Id BIGINT PRIMARY KEY IDENTITY,
    Username VARCHAR(30) UNIQUE NOT NULL,
    [Password] VARCHAR(26) NOT NULL,
    ProfilePicture VARBINARY(MAX),
	CHECK(DATALENGTH(ProfilePicture)<=921600),
    LastLoginTime DATE,
    IsDeleted BIT
)
  
INSERT INTO Users (Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('Dimitar', 'Pass123', NULL,NULL, 1),
('Petur', '12345', NULL, NULL, 0),
('Angel', '67890', NULL, NULL, 0),
('Dimitur', 'qwerty', NULL, NULL, 1),
('Ivan', 'asdfg', NULL, NULL, 0)

