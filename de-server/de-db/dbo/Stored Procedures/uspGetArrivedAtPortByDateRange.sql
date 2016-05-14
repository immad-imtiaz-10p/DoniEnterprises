CREATE PROCEDURE dbo.uspGetArrivedAtPortByDateRange
(
	@startDate DATETIME,
	@endDate DATETIME
)
AS 
BEGIN
	   SELECT 
			t.tr_transactionID,
			tship.tr_dateArrived,
			DATEDIFF(DAY, tship.tr_dateArrived, GETDATE()) as days,
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
			ts.tr_transactionStatus = 'Arrived' 
			AND 
		    (tship.tr_dateArrived <= @endDate AND tship.tr_dateArrived >= @startDate ) 
END