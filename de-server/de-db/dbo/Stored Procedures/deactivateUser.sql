CREATE PROCEDURE [dbo].[deactivateUser]
(
	@userId int 
)
AS
BEGIN
     UPDATE 
	 dbo.AppUsers 
	 SET 
		isActivated = 0
	 WHERE UserID = @userId
END