CREATE PROCEDURE [dbo].[uspGetTransactionsList]
AS
BEGIN
	SELECT 
		t.tr_fileID AS FileID,
		t.tr_contractID AS ContractID,
		t.tr_date AS Transaction_Date,
		bp.bp_Name AS Buyer,
		sp.bp_Name AS Seller,
		t.tr_brokerInvolved AS Broker_Involved,
		t.tr_price AS Price,
		t.tr_quantity AS Quantity

		  
    FROM 
		dbo.Transactions t
		INNER JOIN 
		dbo.BusinessPartner bp
		ON t.tr_bpBuyerID = bp.bp_ID
		INNER JOIN dbo.BusinessPartner sp
		ON sp.bp_isSeller = t.tr_bpSellerID
	 
	Order By t.tr_date desc
END