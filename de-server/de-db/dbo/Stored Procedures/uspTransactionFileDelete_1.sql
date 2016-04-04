CREATE PROCEDURE [dbo].[uspTransactionFileDelete]
(
	@tf_fileID bigint
)
AS 
BEGIN
	DELETE FROM dbo.TransactionFiles WHERE tf_fileID = @tf_fileID
END