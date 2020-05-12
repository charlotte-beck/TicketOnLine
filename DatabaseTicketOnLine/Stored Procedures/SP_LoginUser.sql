CREATE PROCEDURE [TicketOnLineApp].[SP_LoginUser]
	@Email nvarchar(384),
	@Passwd nvarchar(20)
AS
Begin
	Select UserId, LastName, FirstName, Email 
	From [User]
	Where Email = @Email And Passwd = HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Passwd + dbo.GetPostSalt());
End