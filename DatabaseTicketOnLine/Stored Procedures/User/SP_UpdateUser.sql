CREATE PROCEDURE [dbo].[SP_UpdateUser]
	@UserId int,
	@FirstName nvarchar(75),
	@LastName nvarchar(75),
	@Email nvarchar(384),
	@Passwd nvarchar(20),
	@IsAdmin bit,
	@IsActive bit
AS
Begin
	Update [User]
	Set FirstName = @FirstName,
	LastName = @LastName,
	Email = @Email,
	Passwd = HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Passwd + dbo.GetPostSalt()),
	IsAdmin = @IsAdmin,
	IsActive = @IsActive	
	where UserId = @UserId;
End