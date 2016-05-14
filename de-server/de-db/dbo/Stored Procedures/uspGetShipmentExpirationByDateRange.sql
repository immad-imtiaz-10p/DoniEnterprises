CREATE PROCEDURE dbo.uspGetShipmentExpirationByDateRange
(
	@startDate DATETIME,
	@endDate DATETIME
)
AS 
BEGIN
	   SELECT 
			t.tr_transactionID,
			t.tr_shipment_end,
			DATEDIFF(DAY, t.tr_shipment_end, GETDATE()) as days,
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
		WHERE 
			ts.tr_transactionStatus = 'Not Shipped' 
			AND 
		    (t.tr_shipment_end <= @endDate AND t.tr_shipment_end >= @startDate ) 
END