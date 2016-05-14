CREATE PROCEDURE [dbo].[uspTransactionFileAdd]
(
			@tf_transactionID bigint,
			@tf_file varbinary(max),
			@tf_fileType varchar(50),
			@tf_fileName varchar(50),
			@tf_createdBy int
)
AS 
BEGIN

		INSERT INTO [dbo].[TransactionFiles]
		([tf_transactionID]
		,[tf_file]
		,[tf_fileType]
		,[tf_fileName]
		,[tf_createdBy]
		,[tf_createdOn]
		,[tf_editedBy]
		,[tf_editedOn])
		VALUES
		(
			@tf_transactionID, 
			@tf_file,
			@tf_fileType, 
			@tf_fileName, 
			@tf_createdBy,
			GETDATE(),
			null, 
			null
		)

		SELECT TOP 1 tf_fileID FROM dbo.TransactionFiles order by tf_fileID desc
END