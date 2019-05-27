CREATE DATABASE Correspodence;

USE Correspodence;

DROP TABLE dbo.PostallItem;

CREATE TABLE dbo.PostallItem
(
	Id INT NOT NULL,
	[Name] VARCHAR(250) NOT NULL,
	NumberOfPages INT NOT NULL
);
GO

ALTER TABLE dbo.PostallItem
ADD CONSTRAINT PK_PostallItem 
	PRIMARY KEY CLUSTERED (Id);
GO

DROP TABLE dbo.Contractor;

CREATE TABLE dbo.Contractor
(
	Id INT NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	PositionId INT NOT NULL
);
GO

ALTER TABLE dbo.Contractor
ADD CONSTRAINT PK_Contractor 
	PRIMARY KEY CLUSTERED (Id);
GO

DROP TABLE dbo.Position

CREATE TABLE dbo.Position
(
	Id INT NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	CONSTRAINT PK_Position PRIMARY KEY CLUSTERED (Id)
);
GO

DROP TABLE dbo.[Address];

CREATE TABLE dbo.[Address]
(
	Id INT NOT NULL,
	CityId INT NOT NULL,
	[Address] VARCHAR(200) NOT NULL,
	CONSTRAINT PK_Address PRIMARY KEY CLUSTERED (Id)
);
GO

DROP TABLE dbo.City;

CREATE TABLE dbo.City
(
	Id INT NOT NULL,
	[Name] VARCHAR(200) NOT NULL,
	CONSTRAINT PK_City PRIMARY KEY CLUSTERED (Id)
);
GO

DROP TABLE dbo.[Status];

CREATE TABLE dbo.[Status]
(
	Id INT NOT NULL,
	[Name] VARCHAR(10) NOT NULL,
	CONSTRAINT PK_Status PRIMARY KEY CLUSTERED (Id)
);
GO

DROP TABLE dbo.SendingStatus;

CREATE TABLE dbo.SendingStatus
(
	PostallItemId INT NOT NULL,
	StatusId INT NOT NULL,
	UpdateStatusDateTime DATETIMEOFFSET NOT NULL,
	SenderId INT NOT NULL,
	SenderAddress INT NOT NULL,
	ReceiverId INT NOT NULL,
	ReceiverAddress INT NOT NULL,
	CONSTRAINT PK_SendingStatus PRIMARY KEY CLUSTERED (
		PostallItemId,
		StatusId,
		UpdateStatusDateTime,
		SenderId,
		SenderAddress,
		ReceiverId,
		ReceiverAddress
		)
);
GO

ALTER TABLE dbo.[Address]
ADD CONSTRAINT FK_Address_CityId FOREIGN KEY (CityId)
	REFERENCES dbo.City(Id);

ALTER TABLE dbo.City
ADD CONSTRAINT UQ_City_Name UNIQUE ([Name]);
