CREATE PROCEDURE [dbo].[SP_UpdateUserActiveOrAdmin]
	@UserId int,
	@IsAdmin bit,
	@IsActive bit
AS
Begin
	Update [User]
	Set IsAdmin = @IsAdmin,
	IsActive = @IsActive	
	where UserId = @UserId;
End
