CREATE PROCEDURE dbo.getAllUsers
AS 
BEGIN
	SELECT u.firstName,u.lastName,u.initials,u.UserEmail,u.UserDesignation,u.CreatedOn FROM dbo.AppUsers u
END