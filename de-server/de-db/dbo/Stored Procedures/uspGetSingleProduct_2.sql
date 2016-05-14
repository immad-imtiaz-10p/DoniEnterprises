

CREATE PROC [dbo].[uspGetSingleProduct]
(
	@productId int
)
AS
BEGIN	
		SELECT 
		P.*
		FROM dbo.Products P
		WHERE P.ProductId = @productId

END