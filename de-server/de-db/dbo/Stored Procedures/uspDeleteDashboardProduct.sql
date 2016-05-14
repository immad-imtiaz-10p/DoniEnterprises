CREATE PROCEDURE dbo.uspDeleteDashboardProduct
(
	@userId int,
	@productId int
)
AS 
BEGIN
  DELETE FROM [dbo].[userDashboardProducts]
  WHERE [userid] = @userId AND [productId] = @productId
END