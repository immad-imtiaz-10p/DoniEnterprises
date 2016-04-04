CREATE PROCEDURE [dbo].[uspGetTransactionContract]
(
	@tr_transactionId bigint
)
AS
BEGIN
	SELECT * FROM dbo.TransactionsContract ts WHERE ts.tr_transactionID = @tr_transactionId
END