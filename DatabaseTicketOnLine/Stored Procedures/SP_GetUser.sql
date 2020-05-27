CREATE PROCEDURE [dbo].[SP_GetUser]
	@UserId int
AS
BEGIN
	SELECT *
	FROM [User]
	Where UserId = @UserId;
END