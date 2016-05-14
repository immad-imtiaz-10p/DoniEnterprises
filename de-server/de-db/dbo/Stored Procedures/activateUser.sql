CREATE PROCEDURE [dbo].[activateUser]
(
	@userId int 
)
AS
BEGIN
     UPDATE 
	 dbo.AppUsers 
	 SET 
		isActivated = 1
	 WHERE UserID = @userId
END