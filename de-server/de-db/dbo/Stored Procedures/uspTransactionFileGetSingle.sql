
CREATE PROCEDURE [dbo].[uspTransactionFileGetSingle]
(
	@tf_fileID bigint
)
AS 
BEGIN
	SELECT * FROM dbo.TransactionFiles WHERE tf_fileID = @tf_fileID
END
