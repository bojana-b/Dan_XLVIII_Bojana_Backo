CREATE DATABASE Pizzeria;
GO

USE Pizzeria
CREATE TABLE tblUser(
	UserID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	jmbg nvarchar(13) UNIQUE NOT NULL
);

--ALTER DATABASE Pizzeria SET COMPATIBILITY_LEVEL = 100;

USE Pizzeria
CREATE TABLE tblOrder(
	OrderID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Price int,
	OrderStatus nvarchar(15),
	OrderDate datetime,
	UserID INT FOREIGN KEY REFERENCES tblUser(UserID)
);

ALTER TABLE tblOrder
ADD Name nvarchar(50);