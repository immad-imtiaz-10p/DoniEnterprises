CREATE PROC [dbo].[uspGetProductPriceByDateForDashBoard]
(
	@date Datetime,
	@userId int 
)
AS 
BEGIN
	SELECT 
		p.ProductId,
		pp.Price,
		pp.localPrice,
		CASE WHEN pp.tr_editedBy is null THEN pp.tr_createdBy else tr_editedBy END  AS tr_editedBy
	FROM dbo.userDashboardProducts p 
	LEFT OUTER JOIN
	(SELECT * FROM dailyProductPrices WHERE PriceDate = @date) pp 
	ON p.ProductId = pp.Prod_ID	
	WHERE p.userid = @userId
END