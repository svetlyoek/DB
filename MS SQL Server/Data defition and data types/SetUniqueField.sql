ALTER TABLE Users
DROP  CONSTRAINT PK_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT Id_PrimaryKey PRIMARY KEY(Id)

ALTER TABLE Users
ADD  CONSTRAINT  UC_Username UNIQUE (Username)

ALTER TABLE Users
ADD CONSTRAINT CHK_Username CHECK(DATALENGTH(Username)>=3)