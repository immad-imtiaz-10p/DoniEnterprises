CREATE PROCEDURE dbo.uspDeleteTransaction
(
	@tr_transactionID bigint
)
AS 
BEGIN 
	DELETE FROM dbo.Transactions WHERE tr_transactionID = @tr_transactionID
	DELETE FROM dbo.TransactionNotes WHERE tr_ID = @tr_transactionID
END