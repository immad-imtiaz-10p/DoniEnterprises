CREATE PROC [dbo].[uspTransactionSecondaryCRUD]
(
	@crudOperation varchar(50),
	@tr_transactionID bigint,
    @tr_sec_bpBuyerID bigint,
    @tr_sec_bpSellerID bigint,
    @tr_sec_date datetime,
    @tr_sec_buyerPrice DECIMAL(24,2),
    @tr_sec_sellerPrice DECIMAL(24,2),
	@tr_sec_quantity DECIMAL(24,2),
    @tr_sec_otherInfo varchar(4000),
    @tr_createdBy int,    
    @tr_editedBy int,    
	@tr_sec_tranID bigint	
)
AS 
BEGIN
	IF @crudOperation = 'CREATE'
	BEGIN
		INSERT INTO [dbo].[TransactionsSecondary]
				   (
					   [tr_transactionID]
					   ,[tr_sec_bpBuyerID]
					   ,[tr_sec_bpSellerID]
					   ,[tr_sec_date]
					   ,[tr_sec_buyerPrice]
					   ,[tr_sec_sellerPrice]
					   ,[tr_sec_otherInfo]
					   ,[tr_createdBy]
					   ,[tr_createdOn]
					   ,[tr_editedBy]
					   ,[tr_editedOn]
					   ,[tr_sec_quantity]
				   )
			 VALUES
				   (
						@tr_transactionID,
						@tr_sec_bpBuyerID,
						@tr_sec_bpSellerID,
						@tr_sec_date, 
						@tr_sec_buyerPrice, 
						@tr_sec_sellerPrice,
						@tr_sec_otherInfo,
						@tr_createdBy,
						GETDATE(),
						null,
						null,
						@tr_sec_quantity
				   ) 

		SELECT TOP 1 ts.tr_sec_tranID FROM dbo.TransactionsSecondary ts ORDER BY ts.tr_sec_tranID DESC
		END
	ELSE IF @crudOperation = 'UPDATE'
	BEGIN
	UPDATE [dbo].[TransactionsSecondary]
	   SET [tr_transactionID] = @tr_transactionID
		  ,[tr_sec_bpBuyerID] = @tr_sec_bpBuyerID
		  ,[tr_sec_bpSellerID] = @tr_sec_bpSellerID
		  ,[tr_sec_date] = @tr_sec_date
		  ,[tr_sec_buyerPrice] = @tr_sec_buyerPrice
		  ,[tr_sec_sellerPrice] = @tr_sec_sellerPrice
		  ,[tr_sec_otherInfo] = @tr_sec_otherInfo
		  ,[tr_editedBy] = @tr_editedBy
		  ,[tr_editedOn] = GETDATE()
		  ,[tr_sec_quantity] = @tr_sec_quantity
	 WHERE tr_sec_tranID = @tr_sec_tranID
	 SELECT @tr_sec_tranID
	END
	ELSE IF @crudOperation = 'DELETE'
	BEGIN
		DELETE FROM [dbo].[TransactionsSecondary] WHERE tr_sec_tranID = @tr_sec_tranID 
		SELECT @tr_sec_tranID  
	END
	ELSE IF @crudOperation = 'DELETE_ALL'
	BEGIN
		DELETE FROM [dbo].[TransactionsSecondary] WHERE tr_transactionID = @tr_transactionID   
	END
	ELSE IF @crudOperation = 'READ'
	BEGIN
		SELECT * FROM [dbo].[TransactionsSecondary] ts WHERE ts.tr_sec_tranID = @tr_sec_tranID
	END
	ELSE IF @crudOperation = 'READ_ALL'
	BEGIN
		SELECT * FROM [dbo].[TransactionsSecondary] ts where ts.tr_transactionID = @tr_transactionID
	END 
END