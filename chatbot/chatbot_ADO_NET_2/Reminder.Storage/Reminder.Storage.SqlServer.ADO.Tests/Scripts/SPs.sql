DROP PROCEDURE IF EXISTS [dbo].[AddReminderItem]
GO
CREATE PROCEDURE [dbo].[AddReminderItem] (
	@contactId AS VARCHAR(50),
	@targetDate AS DATETIMEOFFSET,
	@message AS NVARCHAR(200),
	@statusId AS TINYINT,
	@reminderId AS UNIQUEIDENTIFIER OUTPUT
)
AS BEGIN
	SET NOCOUNT ON

	DECLARE
		@now AS DATETIMEOFFSET,
		@tempReminderId AS UNIQUEIDENTIFIER
	
	SELECT 
		@now = SYSDATETIMEOFFSET(),
		@tempReminderId = NEWID(); 

	INSERT INTO [dbo].[ReminderItem](
		[Id],
		[ContactId],
		[TargetDate],
		[Message],
		[StatusId],
		[CreatedDate],
		[UpdatedDate])
	VALUES (
		@tempReminderId,
		@contactId,
		@targetDate,
		@message,
		@statusId,
		@now,
		@now)
	
	SET @reminderId = @tempReminderId
END
GO

DROP PROCEDURE IF EXISTS [dbo].[GetReminderItemById];
GO
CREATE PROCEDURE [dbo].[GetReminderItemById](
	@reminderId AS UNIQUEIDENTIFIER)
AS
BEGIN
	SELECT
		[Id],
		[ContactId],
		[TargetDate],
		[Message],
		[StatusId]
	FROM [dbo].[ReminderItem]
	WHERE
		[Id] = @reminderId

END
GO

DROP PROCEDURE IF EXISTS [dbo].[GetListReminderItemByStatus]
GO
CREATE PROCEDURE [dbo].[GetListReminderItemByStatus](
	@reminderItemStatus AS TINYINT)
AS
BEGIN
	SELECT
		[Id],
		[ContactId],
		[TargetDate],
		[Message],
		[StatusId]
	FROM [dbo].[ReminderItem]
	WHERE
		[StatusId] LIKE @reminderItemStatus
END
GO

DROP PROCEDURE IF EXISTS [dbo].[UpdateStatusByGuid]
GO
CREATE PROCEDURE [dbo].[UpdateStatusByGuid](
	@guid AS UNIQUEIDENTIFIER,
	@status AS TINYINT)
AS
BEGIN
	UPDATE [dbo].[ReminderItem]
	SET [StatusId] = @status, [UpdatedDate] = SYSDATETIMEOFFSET()
	WHERE [Id] LIKE @guid
		
END
GO