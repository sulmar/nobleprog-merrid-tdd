CREATE DATABASE TestDb;
GO

USE TestDb;
GO

CREATE TABLE dbo.Customers
(
    CustomerId int IDENTITY(1,1) PRIMARY KEY,
    FirstName nvarchar(100) NOT NULL,
    LastName nvarchar(100) NOT NULL
);
GO
