CREATE PROCEDURE [dbo].[uspProductListByDateRangeForDashboard] 
(
	@startDate DATETIME,
	@endDate DATETIME,
	@userId int
)
AS
BEGIN

	SET @startDate =  CONVERT(date, @startDate )
	SET @endDate= CONVERT(date, @endDate )
	
	SELECT	
		p.ProductId,
		prod.ProductName,
		dpp.PriceDate,
		dpp.Price AS intPrice,
		dpp.localPrice AS localPrice
	FROM 
		userDashboardProducts p
		INNER JOIN
		dbo.Products prod
		ON prod.ProductId = p.ProductId	
		LEFT OUTER JOIN 
		dailyProductPrices dpp
		ON p.ProductId = dpp.Prod_ID 
		WHERE (CONVERT(date,dpp.PriceDate) >= @startDate AND CONVERT(date,dpp.PriceDate) <= @endDate) AND p.userid = @userId
		ORDER BY dpp.Prod_ID desc
END