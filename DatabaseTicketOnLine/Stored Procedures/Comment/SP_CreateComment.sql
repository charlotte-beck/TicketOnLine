CREATE PROCEDURE [dbo].[SP_CreateComment]
	@UserId INT,
	@EventId INT,
	@CommentDate DATE,
	@CommentContent NVARCHAR(max)
AS
BEGIN
	INSERT INTO Comment (UserId, EventId, CommentDate, CommentContent)
	VALUES (@UserId, @EventId, @CommentDate, @CommentContent);
END