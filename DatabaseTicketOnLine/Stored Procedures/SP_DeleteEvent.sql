CREATE PROCEDURE [dbo].[SP_DeleteEvent]
	@EventId int

AS
Begin
	Delete From [Event]
	Where EventId = @EventId;
End
