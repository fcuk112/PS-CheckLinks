CREATE DATABASE Links;
GO

CREATE TABLE Links.dbo.Links
(
    ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Link text NULL,
    CheckedAt DATETIME NULL,
    Problem text NULL
)
