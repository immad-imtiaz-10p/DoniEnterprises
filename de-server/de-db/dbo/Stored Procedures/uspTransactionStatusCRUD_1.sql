/****** Object:  StoredProcedure [dbo].[uspTransactionSecondaryCRUD]    Script Date: 1/6/2016 12:46:15 PM ******/

CREATE PROC [dbo].[uspTransactionStatusCRUD]
(
	@crudOperation varchar(50),
	@tr_transactionID bigint,
    @tr_transactionStatus varchar(100),
	@tr_washoutValueAtPar int,
    @tr_createdBy int,
    @tr_editedBy int
    	
)
AS 
BEGIN
	IF @crudOperation = 'CREATE'
	BEGIN
		INSERT INTO [dbo].[TransactionsStatus]
           ([tr_transactionID]
           ,[tr_transactionStatus]
           ,[tr_washoutValueAtPar]
           ,[tr_createdBy]
           ,[tr_createdOn]
           ,[tr_editedBy]
           ,[tr_editedOn])
     VALUES
           (@tr_transactionID
           ,@tr_transactionStatus
           ,@tr_washoutValueAtPar
		   ,@tr_createdBy
           ,GETDATE()
           ,null
           ,null)
	END
	ELSE IF @crudOperation = 'UPDATE'
	BEGIN
		UPDATE [dbo].[TransactionsStatus]
		SET
		 [tr_transactionStatus] = @tr_transactionStatus
		,[tr_washoutValueAtPar] = @tr_washoutValueAtPar
		,[tr_editedBy] = @tr_editedBy
		,[tr_editedOn] = GETDATE()
		WHERE [tr_transactionID] = @tr_transactionID
	END
	ELSE IF @crudOperation = 'DELETE'
	BEGIN
		DELETE FROM [dbo].[TransactionsStatus] 
		WHERE [tr_transactionID] = @tr_transactionID
    END
END