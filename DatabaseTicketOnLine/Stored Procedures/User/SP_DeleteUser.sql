CREATE PROCEDURE [dbo].[SP_DeleteUser]
	@UserId int
AS
Begin
	Update [User]
	Set IsActive = 0
	where UserId = @UserId;
End