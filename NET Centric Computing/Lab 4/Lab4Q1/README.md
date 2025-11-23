Use Console App

Install-Package System.Data.SqlClient

Query:

CREATE DATABASE ConnectedDisconnected;
GO

USE ConnectedDisconnected;
GO

CREATE TABLE People (
Id INT PRIMARY KEY,
Name NVARCHAR(50),
Age INT
);
GO

INSERT INTO People (Id, Name, Age) VALUES
(1, 'Ram', 25),
(2, 'Sita', 23),
(3, 'Shyam', 28);
GO

SELECT \* FROM People;
