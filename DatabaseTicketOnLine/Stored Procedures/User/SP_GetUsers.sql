CREATE PROCEDURE [dbo].[SP_GetUsers]
	--@FirstName nvarchar(75),
	--@LastName nvarchar(75),
	--@Email nvarchar(384),
	--@Passwd varbinary(64),
	--@IsAdmin bit,
	--@IsActive bit

AS
BEGIN
	SELECT *
	From [User]
END