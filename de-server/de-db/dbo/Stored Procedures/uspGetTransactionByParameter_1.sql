CREATE PROCEDURE dbo.uspGetTransactionByParameter
(
	@parameter nvarchar(100),
	@textInput nvarchar(500),
	@dateInput datetime
)
AS 
BEGIN 

   IF @parameter = 'tr_fileID'
   BEGIN
		SELECT t.tr_fileID,t.tr_transactionID,t.tr_date FROM dbo.Transactions t WHERE t.tr_fileID = @textInput
   END
   ELSE IF @parameter = 'tr_contractID'
   BEGIN
		SELECT t.tr_fileID,t.tr_transactionID,t.tr_date FROM dbo.Transactions t WHERE t.tr_contractID = @textInput
   END
   ELSE IF @parameter = 'tr_date'
   BEGIN
		SELECT t.tr_fileID,t.tr_transactionID,t.tr_date FROM dbo.Transactions t WHERE t.tr_date = @dateInput 
   END



END