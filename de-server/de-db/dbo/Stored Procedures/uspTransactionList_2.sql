CREATE PROCEDURE [dbo].[uspTransactionList]
AS 
BEGIN
SELECT	
	t.tr_transactionID,
	t.tr_date AS transactionDate,
	t.tr_fileID AS fileNo,
	t.tr_bpBuyerID,	
	bp.bp_Name AS buyer,	
	t.tr_productID,
	p.ProductName AS product,
	t.tr_quantity AS quantity,
	t.tr_price AS rate,
	t.tr_bpSellerID,
	sp.bp_Name AS seller,
	t.tr_origin AS origin,
	CASE WHEN ts.tr_ship_portLoad IS NULL THEN 'Not Entered' ELSE ts.tr_ship_portLoad END AS port,
	t.tr_shipment_start  AS shipment_start,
	t.tr_shipment_end  AS shipment_end,
	CASE WHEN tc.tr_netCommission IS null THEN 'Not Entered' ELSE '$'+CAST ( tc.tr_netCommission AS NVARCHAR(50) ) END AS commission	
	 
FROM 
	dbo.Transactions t
	LEFT OUTER JOIN
	dbo.TransactionsCommission tc
	ON tc.tr_transactionID = t.tr_transactionID
	INNER JOIN
	dbo.BusinessPartner bp
	ON bp.bp_ID = t.tr_bpBuyerID
	INNER JOIN
	dbo.BusinessPartner sp
	ON sp.bp_ID = t.tr_bpSellerID
	LEFT OUTER JOIN 
	dbo.TransactionsShipment ts
	ON ts.tr_transactionID = t.tr_transactionID	
	INNER JOIN
	dbo.Products p
	ON t.tr_productID = p.ProductId
	ORDER BY t.tr_date desc
END