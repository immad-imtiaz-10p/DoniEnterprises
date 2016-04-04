CREATE PROCEDURE [dbo].[uspProductSalesAnalyticsByDateRange] 
(
	@startDate DATETIME,
	@endDate DATETIME
)
AS
BEGIN
		SELECT 
			p.ProductId AS tr_productID,
			p.ProductName +' ( ' + p.origin + ' )' AS ProductName, 
			ISNULL(sum(t.tr_quantity),0) AS Quantity,
			ISNULL(sum(tc.tr_netCommission),0) AS NetCommission,
			CAST(ISNULL(SUM(CAST(t.tr_quantity AS BIGINT) * CAST(t.tr_price AS BIGINT)),0) AS BIGINT) AS Volume
		FROM 
		dbo.TransactionsCommission tc
		RIGHT OUTER JOIN	
		(SELECT * FROM dbo.Transactions WHERE CONVERT(date,tr_date) >= @startDate AND CONVERT(date,tr_date) <= @endDate)  t 
		ON tc.tr_transactionID = t.tr_transactionID
		RIGHT OUTER JOIN
		dbo.Products p
		ON t.tr_productID = p.ProductId
		GROUP BY p.ProductId,p.ProductName,p.origin		
		ORDER BY p.ProductId desc
END












