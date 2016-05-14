CREATE PROCEDURE [dbo].[uspGetAppUserByEmail]
(
	@userEmail nvarchar(128)
)
AS 
BEGIN
	SELECT u.UserID,u.UserEmail,u.UserDesignation,u.initials,u.firstName,u.lastName,u.IsSuperUser 
	FROM dbo.AppUsers u where u.UserEmail = @userEmail 
END