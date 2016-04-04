 CREATE PROCEDURE dbo.uspDeleteAllTransactions
 AS 
 BEGIN
 
        DELETE FROM dbo.TransactionsCommission
		WHERE [tr_transactionID] IN (SELECT t.tr_transactionID FROM dbo.Transactions t)
		
		DELETE FROM dbo.TransactionsContract
		WHERE tr_transactionID IN (SELECT t.tr_transactionID FROM dbo.Transactions t)
		
		DELETE FROM dbo.TransactionsSecondary
		WHERE tr_transactionID IN (SELECT t.tr_transactionID FROM dbo.Transactions t)
		
		DELETE FROM dbo.TransactionsShipment
		WHERE tr_transactionID IN (SELECT t.tr_transactionID FROM dbo.Transactions t)
		
		DELETE FROM dbo.TransactionsStatus
		WHERE tr_transactionID IN (SELECT t.tr_transactionID FROM dbo.Transactions t)

		DELETE FROM dbo.TransactionsNotes
		WHERE tr_transactionID IN (SELECT t.tr_transactionID FROM dbo.Transactions t)

		DELETE FROM dbo.TransactionFiles 
		WHERE tf_transactionID IN (SELECT t.tr_transactionID FROM dbo.Transactions t)

		DELETE FROM [dbo].[Transactions] 
		WHERE [tr_transactionID] IN (SELECT t.tr_transactionID FROM dbo.Transactions t)

		END