CREATE DATABASE LiveHeroTour;

USE LiveHeroTour;
GO

SELECT 'Test' + '(comment)', 3.14 * 2;

PRINT 'Test';

RAISERROR('Error message', 9, -1);

DROP TABLE dbo.Category;

CREATE TABLE dbo.Category
(
	Id UNIQUEIDENTIFIER NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	CONSTRAINT PK_Category PRIMARY KEY CLUSTERED(Id),
	CONSTRAINT UQ_Category_Name UNIQUE([Name])
);

SELECT * FROM dbo.Category;

INSERT INTO dbo.Category(Id, [Name])
	VALUES(NEWID(), 'Mobile Phones');

INSERT INTO dbo.Category(Id, [Name])
	VALUES(NEWID(), 'TV');

INSERT INTO dbo.Category(Id, [Name]) SELECT NEWID(), 'Tablets';

UPDATE dbo.Category
	SET [Name] = 'Mobile Phone' WHERE [Name] = 'Mobile Phones';

SELECT * 
FROM dbo.Category
	WHERE [Name] LIKE 'Mobile%';

SELECT TOP 1 [Name], Id
FROM dbo.Category
ORDER BY [Name] DESC;

DELETE FROM dbo.Category 
	WHERE [Name] LIKE 'Mob%';