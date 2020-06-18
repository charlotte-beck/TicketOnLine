CREATE PROCEDURE [dbo].[SP_GetAllComment_Event]
	@EventId INT
AS
BEGIN
	SELECT c.CommentId, c.UserId, c.EventId, c.CommentDate, c.CommentContent, u.Email AS [User], e.EventName AS [Event]
	FROM [User] u 
	RIGHT JOIN Comment c ON u.UserId = c.UserId
	LEFT JOIN [Event] e ON c.EventId = e.EventId
	WHERE c.EventId = @EventId;
END