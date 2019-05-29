USE [LiveHeroTour]
GO

/****** Object:  UserDefinedFunction [dbo].[GetCategoryId]    Script Date: 29.05.2019 20:16:51 ******/
DROP FUNCTION IF EXISTS [dbo].[GetCategoryId]
GO

CREATE FUNCTION dbo.GetCategoryId
(
	@categoryName AS VARCHAR(50)
)
RETURNS UNIQUEIDENTIFIER
AS
BEGIN
	DECLARE @guid AS UNIQUEIDENTIFIER

	SELECT @guid = Id FROM dbo.Category WHERE [Name] = @categoryName
	
	IF (@guid IS NULL)
	BEGIN
		SELECT TOP 1 @guid = Id FROM dbo.Category WHERE [Name] LIKE @categoryName + '%'
	END

	RETURN(@guid)
END
GO

SELECT dbo.GetCategoryId('Mob'); 

SELECT dbo.GetCategoryId('Mobile Phone');

SELECT dbo.GetCategoryId('');

SELECT dbo.GetCategoryId('gghgm');