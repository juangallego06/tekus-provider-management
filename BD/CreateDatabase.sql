USE master
GO

CREATE DATABASE TekusDb
GO

USE TekusDb
GO

CREATE TABLE Providers
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nit NVARCHAR(20) NOT NULL,
    Name NVARCHAR(200) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    Website NVARCHAR(250) NULL
)
GO

CREATE TABLE Services
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    HourlyRate DECIMAL(18,2) NOT NULL,
    ProviderId INT NOT NULL,

    CONSTRAINT FK_Services_Providers
        FOREIGN KEY (ProviderId)
        REFERENCES Providers(Id)
)
GO

CREATE UNIQUE INDEX IX_Providers_Email
ON Providers(Email)
GO

CREATE INDEX IX_Services_ProviderId
ON Services(ProviderId)
GO
