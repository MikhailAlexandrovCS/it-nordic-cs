CREATE DATABASE [ChatBotRemindersStorage];
GO

USE [ChatBotRemindersStorage];

--DROP DATABASE [ChatBotRemindersStorage];
--GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Status]') AND type in (N'U'))
	DROP TABLE [dbo].[Status]
GO

CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] VARCHAR(50) NOT NULL,
	CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED (Id)
);
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contact]') AND type in (N'U'))
	DROP TABLE [dbo].[Contact]
GO

CREATE TABLE [dbo].[Contact](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Contact] VARCHAR(100) NOT NULL,
	CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED (Id)
);
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reminder]') AND type in (N'U'))
	DROP TABLE [dbo].[Reminder]
GO

CREATE TABLE [dbo].[Reminder](
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[ContactTelegramId] INT NOT NULL,
	[Message] NVARCHAR(200) NOT NULL,
	[Status] INT NOT NULL,
	[DateToSend] DATETIMEOFFSET NOT NULL,
	[CreationDate] DATETIMEOFFSET NOT NULL,
	CONSTRAINT [PK_Reminder] PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT [UQ_Reminder_Id] UNIQUE ([Id]),
	CONSTRAINT [FK_Reminder_Status] FOREIGN KEY ([Status]) REFERENCES [dbo].[Status],
	CONSTRAINT [FK_Reminder_Contact] FOREIGN KEY ([ContactTelegramId]) REFERENCES [dbo].[Contact]
);
GO
