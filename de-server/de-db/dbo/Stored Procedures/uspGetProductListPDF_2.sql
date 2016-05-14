


CREATE PROC [dbo].[uspGetProductListPDF]
AS
BEGIN	
	SELECT
		*
		FROM 
	dbo.Products P ORDER BY P.ProductName
	
END