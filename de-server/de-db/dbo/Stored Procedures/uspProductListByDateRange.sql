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
		dpp.Prod_ID,
		dpp.PriceDate,
		dpp.Price,
		p.ProductName,
		p.quality,
		p.origin
	FROM 
		dailyProductPrices dpp
		LEFT OUTER JOIN 
		products p
		ON p.ProductId = dpp.Prod_ID		
		WHERE CONVERT(date,dpp.PriceDate) >= @startDate AND CONVERT(date,dpp.PriceDate) <= @endDate
		ORDER BY dpp.Prod_ID desc
END






