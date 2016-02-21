Create Procedure NewUserLoginDetails
(
	@UserName Nvarchar(50),
	@Password Nvarchar(max),
	@DOB      datetime,
	@Email    Nvarchar(128)
)
AS 
BEGIN

INSERT INTO dbo.Users VALUES (HASHBYTES('sha1',@UserName), HASHBYTES('sha1', @Password), HASHBYTES('sha1', @Email), @DOB, GETDATE())


END
