CREATE PROCEDURE [dbo].[uspProductListByDateRange] 
(
	@startDate DATETIME,
	@endDate DATETIME
)
AS
BEGIN

	SET @startDate =  CONVERT(date, @startDate )
	SET @endDate= CONVERT(date, @endDate )
	
	SELECT	
		p.ProductId,
		dpp.PriceDate,
		dpp.Price AS intPrice,
		dpp.localPrice AS localPrice
	FROM 
		products p		
		LEFT OUTER JOIN 
		dailyProductPrices dpp
		ON p.ProductId = dpp.Prod_ID 
		WHERE (CONVERT(date,dpp.PriceDate) >= @startDate AND CONVERT(date,dpp.PriceDate) <= @endDate)	
		ORDER BY dpp.Prod_ID desc
END