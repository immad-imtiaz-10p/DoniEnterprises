CREATE PROCEDURE dbo.uspGetExpextedArrivalAtPortByDateRange
(
	@startDate DATETIME,
	@endDate DATETIME
)
AS 
BEGIN
	   SELECT 
			t.tr_transactionID,
			tship.tr_expectedArrival,
			DATEDIFF(DAY, tship.tr_expectedArrival, GETDATE()) as days,
			tr_fileID,
			tr_bpBuyerID,
			tr_productID,
			tr_quantity,
			tr_price,
			tr_bpSellerID,
			ts.tr_transactionStatus 
		FROM dbo.Transactions t
		INNER JOIN
		dbo.TransactionsStatus ts
		ON t.tr_transactionID = ts.tr_transactionID
		INNER JOIN
		dbo.TransactionsShipment tship
		ON t.tr_transactionID = tship.tr_transactionID
		WHERE 
			ts.tr_transactionStatus = 'Shipped' 
			AND 
		    (tship.tr_expectedArrival <= @endDate AND tship.tr_expectedArrival >= @startDate ) 
END