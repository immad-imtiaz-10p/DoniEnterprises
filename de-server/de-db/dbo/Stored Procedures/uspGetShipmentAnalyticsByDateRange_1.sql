CREATE PROCEDURE [dbo].[uspGetShipmentAnalyticsByDateRange] 
(
	@startDate DATETIME,
	@endDate DATETIME,
	@reportType NVARCHAR(10)
)
AS 
BEGIN
	IF @reportType = 'arrived'
		BEGIN
			SELECT 
				ts.tr_dateArrived AS req_date,
				DATEDIFF(DAY, ts.tr_dateArrived, GETDATE()) AS dayDifferance,
				t.tr_fileID,
				t.tr_bpBuyerID,
				t.tr_productID,	
				t.tr_price,
				t.tr_quantity,
				t.tr_bpSellerID 
			FROM 
			dbo.TransactionsShipment ts
			INNER JOIN 
			dbo.Transactions t
			ON ts.tr_transactionID = t.tr_transactionID
			INNER JOIN 
			dbo.Products p
			ON t.tr_productID = p.ProductId 
			WHERE (ts.tr_ship_arrivedAtPort = 1) AND (ts.tr_actualArrived <= @endDate AND ts.tr_expectedArrival >= @startDate ) 
		END
	ELSE IF @reportType = 'expectedArrival'
		BEGIN
			SELECT 
				ts.tr_dateArrived AS req_date,
				DATEDIFF(DAY, ts.tr_dateArrived, GETDATE()) AS dayDifferance,
				t.tr_fileID,
				t.tr_bpBuyerID,
				t.tr_productID,	
				t.tr_price,
				t.tr_quantity,
				t.tr_bpSellerID 
			FROM 
			dbo.TransactionsShipment ts
			INNER JOIN 
			dbo.Transactions t
			ON ts.tr_transactionID = t.tr_transactionID
			INNER JOIN 
			dbo.Products p
			ON t.tr_productID = p.ProductId 
			WHERE (ts.tr_expectedArrival <= @endDate AND ts.tr_expectedArrival >= @startDate )
		END
	ELSE IF @reportType = 'expired'
		BEGIN
			SELECT 
				ts.tr_dateArrived AS req_date,
				DATEDIFF(DAY, ts.tr_dateArrived, GETDATE()) AS dayDifferance,
				t.tr_fileID,
				t.tr_bpBuyerID,
				t.tr_productID,	
				t.tr_price,
				t.tr_quantity,
				t.tr_bpSellerID 
			FROM 
			dbo.TransactionsShipment ts
			INNER JOIN 
			dbo.Transactions t
			ON ts.tr_transactionID = t.tr_transactionID
			INNER JOIN 
			dbo.Products p
			ON t.tr_productID = p.ProductId 
			WHERE (ts.tr_expectedArrival <= @endDate AND ts.tr_expectedArrival >= @startDate )
		END	
END