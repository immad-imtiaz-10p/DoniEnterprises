CREATE PROCEDURE dbo.uspAddDashboardProduct
(
	@userId int,
	@productId int
)
AS 
BEGIN
  INSERT INTO [dbo].[userDashboardProducts]
           ([userid]
           ,[productId])
     VALUES
           (@userId
           ,@productId)
END