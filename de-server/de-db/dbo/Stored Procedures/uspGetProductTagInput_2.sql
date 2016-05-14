

CREATE Procedure [dbo].[uspGetProductTagInput]
(
	@input varchar(max)

)
AS 
BEGIN

 IF (@input = '')
	 BEGIN
		SELECT 
			p.ProductId,
			p.ProductName,
			p.origin, 
			p.quality		
		FROM dbo.Products p
	 END
 ELSE
	BEGIN
		 SELECT 
			p.ProductId,
			p.ProductName,
			p.origin, 
			p.quality		
		FROM dbo.Products p WHERE p.ProductName LIKE @input+'%'
	END
END