CREATE PROCEDURE [dbo].[uspGetTransactionShipment]
(
	@tr_transactionId bigint
)
AS
BEGIN
	SELECT * FROM dbo.TransactionsShipment ts WHERE ts.tr_transactionID = @tr_transactionId
END