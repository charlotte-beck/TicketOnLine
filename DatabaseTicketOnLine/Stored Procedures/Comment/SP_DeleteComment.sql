CREATE PROCEDURE [dbo].[SP_DeleteComment]
	@CommentId INT
AS
BEGIN
	DELETE FROM Comment 
	WHERE CommentId = @CommentId
END