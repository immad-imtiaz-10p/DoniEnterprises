/****** Object:  StoredProcedure [dbo].[uspTransactionSecondaryCRUD]    Script Date: 1/6/2016 12:46:15 PM ******/

CREATE PROC [dbo].[uspTransactionContractCRUD]
(
	@crudOperation varchar(50),
	@tr_transactionID bigint,
    @tr_doniContract bit,
    @tr_ownContract bit,
    @tr_ContractualBuyer bigint,
    @tr_createdBy int,
    @tr_editedBy int   	
)
AS 
BEGIN
	IF @crudOperation = 'CREATE'
	BEGIN
		INSERT INTO [dbo].[TransactionsContract]
           ([tr_transactionID]
           ,[tr_doniContract]
           ,[tr_ownContract]
           ,[tr_ContractualBuyer]
           ,[tr_createdBy]
           ,[tr_createdOn]
           ,[tr_editedBy]
           ,[tr_editedOn])
     VALUES
           (@tr_transactionID
           ,@tr_doniContract
           ,@tr_ownContract
           ,@tr_ContractualBuyer
           ,@tr_createdBy
           ,GETDATE()
           ,@tr_editedBy
           ,GETDATE())
	END
	ELSE IF @crudOperation = 'UPDATE'
	BEGIN
		UPDATE [dbo].[TransactionsContract]
		SET 
		 [tr_doniContract] = @tr_doniContract
		,[tr_ownContract] = @tr_ownContract
		,[tr_ContractualBuyer] = @tr_ContractualBuyer
		,[tr_editedBy] = @tr_editedBy
		,[tr_editedOn] = GETDATE()
		WHERE tr_transactionID = @tr_transactionID
	END
	ELSE IF @crudOperation = 'DELETE'
	BEGIN
		 DELETE FROM [dbo].[TransactionsContract] WHERE tr_transactionID = @tr_transactionID
	END
END