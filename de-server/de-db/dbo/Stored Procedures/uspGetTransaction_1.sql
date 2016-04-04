CREATE PROCEDURE [dbo].[uspGetTransaction]
(
	@tr_transactionID bigint 
)
AS 
BEGIN
	    SELECT * FROM [dbo].[Transactions] 
		WHERE [tr_transactionID] = @tr_transactionID	
		
END