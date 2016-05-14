CREATE PROC [dbo].[uspGetProductPriceByDate]
(
	@date Datetime 
)
AS 
BEGIN
	SELECT 
		p.ProductId,
		pp.Price,
		pp.localPrice,
		CASE WHEN pp.tr_editedBy is null THEN pp.tr_createdBy else tr_editedBy END  AS tr_editedBy
	FROM dbo.Products p 
	LEFT OUTER JOIN
	(SELECT * FROM dailyProductPrices WHERE PriceDate = @date) pp 
	ON p.ProductId = pp.Prod_ID	
END