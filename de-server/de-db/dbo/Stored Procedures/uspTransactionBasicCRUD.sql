/****** Object:  StoredProcedure [dbo].[uspTransactionSecondaryCRUD]    Script Date: 1/6/2016 12:46:15 PM ******/

CREATE PROC [dbo].[uspTransactionBasicCRUD]
(
	@crudOperation varchar(50),
	@tr_transactionID bigint,
	@tr_date datetime,
    @tr_bpBuyerID bigint,
    @tr_bpSellerID bigint,
    @tr_productID int,
    @tr_origin nvarchar(150),
    @tr_quantity int,
    @tr_price int,
    @tr_packing nvarchar(50),
    @tr_shipment_start datetime,
    @tr_shipment_end datetime,
    @tr_fileID nvarchar(200),
    @tr_contractID nvarchar(200),
    @tr_other_info varchar(max),
    @tr_createdBy int,
    @tr_editedBy int    	
)
AS 
BEGIN
	IF @crudOperation = 'CREATE'
	BEGIN
		INSERT INTO [dbo].[Transactions]
           ([tr_date]
           ,[tr_bpBuyerID]
           ,[tr_bpSellerID]
           ,[tr_productID]
           ,[tr_origin]
           ,[tr_quantity]
           ,[tr_price]
           ,[tr_packing]
           ,[tr_shipment_start]
           ,[tr_shipment_end]
           ,[tr_fileID]
           ,[tr_contractID]
           ,[tr_other_info]
           ,[tr_createdBy]
           ,[tr_createdOn]
           ,[tr_editedBy]
           ,[tr_editedOn])
     VALUES
           (
		   @tr_date, 
		   @tr_bpBuyerID,
           @tr_bpSellerID, 
           @tr_productID, 
           @tr_origin, 
           @tr_quantity,
           @tr_price, 
           @tr_packing, 
           @tr_shipment_start,
		   @tr_shipment_end, 
           @tr_fileID,
           @tr_contractID,
           @tr_other_info,
           @tr_createdBy, 
           GETDATE(), 
           null, 
           null)

	   SELECT TOP 1 t.tr_transactionID 
	   FROM dbo.Transactions  t 
	   order by t.tr_transactionID desc
	END
	ELSE IF @crudOperation = 'UPDATE'
	BEGIN
		UPDATE [dbo].[Transactions]
		SET [tr_date] = @tr_date
		,[tr_bpBuyerID] = @tr_bpBuyerID
		,[tr_bpSellerID] = @tr_bpSellerID
		,[tr_productID] = @tr_productID
		,[tr_origin] = @tr_origin
		,[tr_quantity] = @tr_quantity
		,[tr_price] = @tr_price
		,[tr_packing] = @tr_packing
		,[tr_shipment_start] = @tr_shipment_start
		,[tr_shipment_end] = @tr_shipment_end
		,[tr_fileID] = @tr_fileID
		,[tr_contractID] = @tr_contractID
		,[tr_other_info] = @tr_other_info
		,[tr_editedBy] = @tr_editedBy
		,[tr_editedOn] = GETDATE()
		WHERE [tr_transactionID] = @tr_transactionID

		SELECT @tr_transactionID

	END
	ELSE IF @crudOperation = 'DELETE'
	BEGIN
		DELETE FROM dbo.TransactionsCommission
		WHERE [tr_transactionID] = @tr_transactionID
		
		DELETE FROM dbo.TransactionsContract
		WHERE tr_transactionID = @tr_transactionID
		
		DELETE FROM dbo.TransactionsSecondary
		WHERE tr_transactionID = @tr_transactionID
		
		DELETE FROM dbo.TransactionsShipment
		WHERE tr_transactionID = @tr_transactionID
		
		DELETE FROM dbo.TransactionsStatus
		WHERE tr_transactionID = @tr_transactionID

		DELETE FROM dbo.TransactionsNotes
		WHERE tr_transactionID = @tr_transactionID

		DELETE FROM dbo.TransactionFiles 
		WHERE tf_transactionID = @tr_transactionID

		DELETE FROM [dbo].[Transactions] 
		WHERE [tr_transactionID] = @tr_transactionID

		SELECT @tr_transactionID
    END
	
END