
CREATE PROC [dbo].[uspDeleteProduct]
(
	@ProductId int
	
)
AS
BEGIN	
	DELETE FROM dbo.Products WHERE ProductId = @ProductId	
END