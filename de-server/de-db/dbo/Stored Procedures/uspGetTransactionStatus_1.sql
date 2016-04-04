CREATE PROCEDURE [dbo].[uspGetTransactionStatus]
(
	@tr_transactionId bigint
)
AS
BEGIN
	SELECT * FROM dbo.TransactionsStatus ts WHERE ts.tr_transactionID = @tr_transactionId
END