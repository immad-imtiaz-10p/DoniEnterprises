CREATE Procedure [dbo].[addNewAppUser]
(
	@title Nvarchar(10),
	@firstName Nvarchar(50),
	@lastName Nvarchar(50),
	@Password Nvarchar(max),
	@email    Nvarchar(128),
	@guID     uniqueidentifier,
	@designation nvarchar(100),
	@isAdmin bit

)
AS 
BEGIN

INSERT INTO [dbo].[AppUsers]
           ([UserPass]
           ,[UserEmail]
           ,[CreatedOn]
           ,[UserGuid]
           ,[UserDesignation]
           ,[IsSuperUser]
           ,[initials]
           ,[firstName]
           ,[lastName]
		   ,[isActivated])
     VALUES(@Password,@email,GETDATE(),@guID,@designation,@isAdmin,@title,@firstName,@lastName,1)
        


END