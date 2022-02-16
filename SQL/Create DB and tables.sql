CREATE DATABASE [StoreDB] 
GO
 
USE [StoreDB]
GO
CREATE TABLE Categories (
	[UuId] UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[ParentUuId] UNIQUEIDENTIFIER NULL,
	[Name] NVARCHAR (150) NOT NULL,
	[Description] NVARCHAR (1024) NULL,
	[KeyWords] NVARCHAR (200) NULL,
	[IsDeleted] Bit NOT NULL DEFAULT 0)
GO

GO
CREATE TABLE Brands (
	[UuId] UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[Name] NVARCHAR (150) NOT NULL,
	[IsDeleted] Bit NOT NULL DEFAULT 0)
GO

GO
CREATE TABLE Products (
	[UuId] UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[Name] NVARCHAR (150) NOT NULL,
	[ImageData] VARBINARY (MAX) NULL,
	[Article] NVARCHAR (100) NULL,
	[BrandUuId] UNIQUEIDENTIFIER NULL,
	[CategoryUuId] UNIQUEIDENTIFIER NULL,
	[Description] NVARCHAR (1024) NULL,
	[Price] DECIMAL NULL,
	FOREIGN KEY (BrandUuId) REFERENCES Brands (UuId),
	FOREIGN KEY (CategoryUuId) REFERENCES Categories (UuId))
GO