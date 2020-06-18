CREATE PROCEDURE [dbo].[SP_UpdateComment]
	@CommentId INT,
	@CommentDate DATE,
	@CommentContent NVARCHAR
AS
BEGIN
	UPDATE Comment 
	SET CommentDate = @CommentDate, CommentContent = @CommentContent 
	WHERE CommentId = @CommentId;
END