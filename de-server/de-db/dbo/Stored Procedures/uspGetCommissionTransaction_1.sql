CREATE PROCEDURE [dbo].[uspGetCommissionTransaction]
(
	@tr_transactionID bigint 
)
AS 
BEGIN
	    SELECT * FROM [dbo].TransactionsCommission 
		WHERE [tr_transactionID] = @tr_transactionID	
		
END