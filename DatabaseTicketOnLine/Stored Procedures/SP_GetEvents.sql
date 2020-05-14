CREATE PROCEDURE [dbo].[SP_GetEvents]
	--@EventType nvarchar(128),
	--@EventName nvarchar(128),
	--@EventDate datetime2(7),
	--@EventDescription nvarchar(255),
	--@EventOrg nvarchar(128),
	--@EventLocation nvarchar(128),
	--@EventPrice float
AS
BEGIN
	SELECT *
	From [Event]
END