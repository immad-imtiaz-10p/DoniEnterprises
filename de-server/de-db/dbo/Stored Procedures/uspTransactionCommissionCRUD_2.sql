CREATE PROC [dbo].[uspTransactionCommissionCRUD]
(
	 @crudOperation varchar(50)
	,@tr_transactionID bigint
    ,@tr_brokerInvolved bit
    ,@tr_sellerBroker bit
    ,@tr_sellerBrokerID bigint
    ,@tr_sellerBroker_comm_type nvarchar(50)
    ,@tr_sellerBroker_comm DECIMAL(24,2)
    ,@tr_buyerBroker bit
    ,@tr_buyerBrokerID bigint
    ,@tr_buyerBroker_comm_type nvarchar(50)
    ,@tr_buyerBroker_comm DECIMAL(24,2)
    ,@tr_own_Commission DECIMAL(24,2)
    ,@tr_ownCommissionType nvarchar(50)
    ,@tr_difference DECIMAL(24,2)
    ,@tr_discount DECIMAL(24,2)
    ,@tr_netCommission DECIMAL(24,2)
    ,@tr_createdBy int
    ,@tr_createdOn datetime
    ,@tr_editedBy int
    ,@tr_editedOn datetime
    	
)
AS 
BEGIN
	IF @crudOperation = 'CREATE'
	BEGIN
		INSERT INTO [dbo].[TransactionsCommission]
           ([tr_transactionID]
           ,[tr_brokerInvolved]
           ,[tr_sellerBroker]
           ,[tr_sellerBrokerID]
           ,[tr_sellerBroker_comm_type]
           ,[tr_sellerBroker_comm]
           ,[tr_buyerBroker]
           ,[tr_buyerBrokerID]
           ,[tr_buyerBroker_comm_type]
           ,[tr_buyerBroker_comm]
           ,[tr_own_Commission]
           ,[tr_ownCommissionType]
           ,[tr_difference]
           ,[tr_discount]
           ,[tr_netCommission]
           ,[tr_createdBy]
           ,[tr_createdOn]
           ,[tr_editedBy]
           ,[tr_editedOn])
     VALUES
           (@tr_transactionID
           ,@tr_brokerInvolved 
           ,@tr_sellerBroker
		   ,@tr_sellerBrokerID 
           ,@tr_sellerBroker_comm_type 
           ,@tr_sellerBroker_comm
           ,@tr_buyerBroker
           ,@tr_buyerBrokerID 
		   ,@tr_buyerBroker_comm_type 
		   ,@tr_buyerBroker_comm
           ,@tr_own_Commission
           ,@tr_ownCommissionType
           ,@tr_difference
           ,@tr_discount
           ,@tr_netCommission
           ,@tr_createdBy
		   ,GETDATE() 
           ,null 
           ,null)

	END
	ELSE IF @crudOperation = 'UPDATE'
		BEGIN
		UPDATE [dbo].[TransactionsCommission]
		SET 
		 [tr_brokerInvolved] = @tr_brokerInvolved
		,[tr_sellerBroker] = @tr_sellerBroker
		,[tr_sellerBrokerID] = @tr_sellerBrokerID
		,[tr_sellerBroker_comm_type] = @tr_sellerBroker_comm_type
		,[tr_sellerBroker_comm] = @tr_sellerBroker_comm
		,[tr_buyerBroker] = @tr_buyerBroker
		,[tr_buyerBrokerID] = @tr_buyerBrokerID
		,[tr_buyerBroker_comm_type] = @tr_buyerBroker_comm_type 
		,[tr_buyerBroker_comm] = @tr_buyerBroker_comm
		,[tr_own_Commission] = @tr_own_Commission
		,[tr_ownCommissionType] = @tr_ownCommissionType 
		,[tr_difference] = @tr_difference
		,[tr_discount] = @tr_discount
		,[tr_netCommission] = @tr_netCommission 
		,[tr_editedBy] = @tr_editedBy
		,[tr_editedOn] = GETDATE()
		WHERE [tr_transactionID] = @tr_transactionID
	END
	ELSE IF @crudOperation = 'DELETE'
	BEGIN
		DELETE FROM [dbo].[TransactionsCommission] 
		WHERE [tr_transactionID] = @tr_transactionID
    END
END