use StoreDB
CREATE TABLE [Products] (
	[ID] INT IDENTITY (1, 1) NOT NULL,
	[Name] NVARCHAR (MAX) NULL,
	[BrandID] INT NULL
	CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED ([ID] ASC),
	FOREIGN KEY (BrandID) REFERENCES Brands (ID)
);