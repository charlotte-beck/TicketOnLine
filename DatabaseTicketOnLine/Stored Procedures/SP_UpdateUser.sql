CREATE PROCEDURE [dbo].[SP_UpdateUser]
	@UserId int,
	@FirstName nvarchar(75),
	@LastName nvarchar(75),
	@Email nvarchar(384),
	@Passwd varbinary(64),
	@IsAdmin bit,
	@IsActive bit
AS
Begin
	Update [User]
	Set FirstName = @FirstName,
	LastName = @LastName,
	Email = @Email,
	Passwd = @Passwd,
	IsAdmin = @IsAdmin,
	IsActive = @IsActive	
	where UserId = @UserId;
End