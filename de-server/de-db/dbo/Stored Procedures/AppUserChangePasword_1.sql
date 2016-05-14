CREATE PROCEDURE [dbo].[AppUserChangePasword]
(
	@UserID int,
	@Password nvarchar(max),
	@guID uniqueidentifier
)
AS 
BEGIN 
	UPDATE [dbo].[AppUsers]
    SET    [UserPass] = @Password
          ,[UserGuid] = @guID
    WHERE  [UserID] = @UserID
END