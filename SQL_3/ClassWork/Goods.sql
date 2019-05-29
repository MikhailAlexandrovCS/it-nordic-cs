CREATE TABLE dbo.Goods
(
	Id INT NOT NULL IDENTITY(1, 1),
	CategoryId UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Goods PRIMARY KEY CLUSTERED(Id),
	CONSTRAINT UQ_Goods_Name UNIQUE ([Name])
);

ALTER TABLE dbo.Goods 
	ADD CONSTRAINT FK_Goods_CategoryId FOREIGN KEY (CategoryId)
	REFERENCES dbo.Category(Id);

----------------------------------------------------------------------------------
DECLARE @guid AS UNIQUEIDENTIFIER;

SELECT @guid = Id FROM dbo.Category
	WHERE [Name] LIKE 'Mob%';

PRINT @guid;

INSERT INTO dbo.Goods (CategoryId, [Name]) VALUES (@guid, 'iPhone X');

PRINT 'ID of iPhone X is ' + CONVERT(VARCHAR(15), SCOPE_IDENTITY())
----------------------------------------------------------------------------------

SELECT * FROM dbo.Goods;

DELETE FROM dbo.Goods
	WHERE [Name] = 'iPhone X';

DELETE FROM dbo.Goods
	WHERE [Name] = 'Xiaomi Mi9';

----------------------------------------------------------------------------------
DECLARE @guid AS UNIQUEIDENTIFIER;

SELECT @guid = Id FROM dbo.Category
	WHERE [Name] LIKE 'Mob%';

PRINT @guid;

INSERT INTO dbo.Goods (CategoryId, [Name]) VALUES (@guid, 'Xiaomi Mi9');

PRINT 'ID of Xiaomi Mi9 is ' + CAST(SCOPE_IDENTITY() AS VARCHAR(15));
----------------------------------------------------------------------------------

TRUNCATE TABLE dbo.Goods;