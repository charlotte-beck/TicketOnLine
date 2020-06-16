CREATE PROCEDURE [dbo].[SP_CreateUser]
	@FirstName nvarchar(75),
	@LastName nvarchar(75),
	@Email nvarchar(384),
	@Passwd varbinary(64),
	@IsAdmin bit,
	@IsActive bit

AS
Begin
	insert into [User] (FirstName, LastName, Email, Passwd, IsAdmin, IsActive)
	values (@FirstName, @LastName, @Email, @Passwd, @IsAdmin, @IsActive);
End