﻿CREATE PROCEDURE [dbo].[SP_RegisterUser]
	@LastName nvarchar(75),
	@FirstName nvarchar(75),
	@Email nvarchar(384),
	@Passwd nvarchar(20)
AS
Begin
	Insert into [User] (LastName, FirstName, Email, Passwd)
	values (@LastName, @FirstName, @Email, HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Passwd + dbo.GetPostSalt()));
End