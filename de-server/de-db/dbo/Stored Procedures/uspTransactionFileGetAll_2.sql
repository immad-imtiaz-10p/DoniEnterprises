
CREATE PROCEDURE [dbo].[uspTransactionFileGetAll]
(
	@tf_transactionID bigint
)
AS 
BEGIN
	SELECT  
		tf.tf_fileID,
		tf.tf_fileName,
		tf.tf_fileType,
		tf.tf_createdBy,
		tf.tf_createdOn,
		tf.tf_transactionID
	FROM 
	dbo.TransactionFiles tf 
	WHERE tf_transactionID = @tf_transactionID
END