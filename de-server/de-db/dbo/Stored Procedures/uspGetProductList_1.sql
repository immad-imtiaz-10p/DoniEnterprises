

CREATE PROC [dbo].[uspGetProductList]
AS
BEGIN	
	SELECT
		P.ProductId,
		P.ProductName,
		P.quality,
		P.origin,
		max(T.tr_date) AS TransactionDate,
		max(T.tr_transactionID) AS tr_transactionID
		
    FROM
	dbo.Products P LEFT OUTER JOIN  dbo.Transactions T ON P.ProductId = T.tr_productID
	GROUP BY P.ProductId,P.ProductName,P.quality,P.origin
	
END