CREATE PROCEDURE [dbo].[getAllUsers]
AS 
BEGIN
	SELECT 
	       u.UserID,
		   u.firstName,
		   u.lastName,
		   u.initials,
		   u.UserEmail,
		   u.UserDesignation,
		   u.CreatedOn,
		   u.IsSuperUser,
		   u.isActivated		    
    FROM dbo.AppUsers u
END