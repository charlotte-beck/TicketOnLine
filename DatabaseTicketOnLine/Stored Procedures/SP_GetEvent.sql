CREATE PROCEDURE [dbo].[SP_GetEvent]
	@EventId int
AS
BEGIN
	SELECT *
	FROM [Event]
	Where EventId = @EventId;
END