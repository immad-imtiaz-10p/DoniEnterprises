CREATE PROCEDURE [dbo].[uspGetSecondaryTransaction]
(
	@tr_transactionID bigint 
)
AS 
BEGIN
	    SELECT * FROM [dbo].TransactionsSecondary 
		WHERE [tr_transactionID] = @tr_transactionID	
		
END