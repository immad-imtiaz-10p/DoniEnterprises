/****** Object:  StoredProcedure [dbo].[uspTransactionSecondaryCRUD]    Script Date: 1/6/2016 12:46:15 PM ******/

CREATE PROC [dbo].[uspTransactionShipmentCRUD]
(
	@crudOperation varchar(50),
	@tr_transactionID bigint,
    @tr_ship_notShipped bit,
    @tr_ship_notShipped_reason varchar(500),
    @tr_ship_extension varchar(100),
    @tr_ship_appReceived bit,
    @tr_expectedShipment datetime,
    @tr_inTransit datetime,
    @tr_shipped bit,
    @tr_dateShipped datetime,
    @tr_expectedArrival datetime,
    @tr_transitPort varchar(500),
    @tr_ship_arrivedAtPort bit,
    @tr_dateArrived datetime,
    @tr_actualArrived datetime,
    @tr_ship_BlNo varchar(50),
    @tr_ship_invoiceNo varchar(50),
    @tr_ship_invoiceAmt int,
    @tr_ship_quantity int,
    @tr_ship_vesselNo varchar(50),
    @tr_ship_primaryShipperId bigint,
    @tr_ship_portLoad varchar(500),
    @tr_ship_portDest varchar(500),
    @tr_ship_shipLineCont varchar(500),
    @tr_createdBy int,    
    @tr_editedBy int,
	@tr_ship_chk_reason bit,
    @tr_ship_chk_shpExt bit,
    @tr_ship_chk_expShp bit,
    @tr_ship_chk_inTransit bit,
    @tr_ship_chk_dateShipped bit,
    @tr_ship_chk_expArrival bit,
    @tr_ship_chk_transitPort bit,
    @tr_ship_chk_dateArrived bit,
    @tr_ship_chk_actualArrived bit
    	
)
AS 
BEGIN
	IF @crudOperation = 'CREATE'
	BEGIN
		INSERT INTO [dbo].[TransactionsShipment]
           ([tr_transactionID]
           ,[tr_ship_notShipped]
           ,[tr_ship_notShipped_reason]
           ,[tr_ship_extension]
           ,[tr_ship_appReceived]
           ,[tr_expectedShipment]
           ,[tr_inTransit]
           ,[tr_shipped]
           ,[tr_dateShipped]
           ,[tr_expectedArrival]
           ,[tr_transitPort]
           ,[tr_ship_arrivedAtPort]
           ,[tr_dateArrived]
           ,[tr_actualArrived]
           ,[tr_ship_BlNo]
           ,[tr_ship_invoiceNo]
           ,[tr_ship_invoiceAmt]
           ,[tr_ship_quantity]
           ,[tr_ship_vesselNo]
           ,[tr_ship_primaryShipperId]
           ,[tr_ship_portLoad]
           ,[tr_ship_portDest]
           ,[tr_ship_shipLineCont]
           ,[tr_createdBy]
           ,[tr_createdOn]
           ,[tr_editedBy]
           ,[tr_editedOn]
		   ,[tr_ship_chk_reason]
           ,[tr_ship_chk_shpExt]
           ,[tr_ship_chk_expShp]
           ,[tr_ship_chk_inTransit]
           ,[tr_ship_chk_dateShipped]
           ,[tr_ship_chk_expArrival]
           ,[tr_ship_chk_transitPort]
           ,[tr_ship_chk_dateArrived]
           ,[tr_ship_chk_actualArrived])
     VALUES
           (@tr_transactionID
           ,@tr_ship_notShipped
           ,@tr_ship_notShipped_reason 
           ,@tr_ship_extension
           ,@tr_ship_appReceived
           ,@tr_expectedShipment
           ,@tr_inTransit
           ,@tr_shipped
           ,@tr_dateShipped
           ,@tr_expectedArrival
           ,@tr_transitPort
           ,@tr_ship_arrivedAtPort
           ,@tr_dateArrived
           ,@tr_actualArrived
           ,@tr_ship_BlNo
           ,@tr_ship_invoiceNo
           ,@tr_ship_invoiceAmt
           ,@tr_ship_quantity
           ,@tr_ship_vesselNo
           ,@tr_ship_primaryShipperId
           ,@tr_ship_portLoad
           ,@tr_ship_portDest
           ,@tr_ship_shipLineCont
           ,@tr_createdBy
           ,GETDATE()
           ,null
           ,null
		   ,@tr_ship_chk_reason
           ,@tr_ship_chk_shpExt
           ,@tr_ship_chk_expShp
           ,@tr_ship_chk_inTransit
           ,@tr_ship_chk_dateShipped
           ,@tr_ship_chk_expArrival
           ,@tr_ship_chk_transitPort
           ,@tr_ship_chk_dateArrived
           ,@tr_ship_chk_actualArrived)
	END
	ELSE IF @crudOperation = 'UPDATE'
	BEGIN
		UPDATE [dbo].[TransactionsShipment]
		SET 
		 [tr_ship_notShipped] = @tr_ship_notShipped
		,[tr_ship_notShipped_reason] = @tr_ship_notShipped_reason
		,[tr_ship_extension] = @tr_ship_extension
		,[tr_ship_appReceived] = @tr_ship_appReceived
		,[tr_expectedShipment] = @tr_expectedShipment
		,[tr_inTransit] = @tr_inTransit
		,[tr_shipped] = @tr_shipped
		,[tr_dateShipped] = @tr_dateShipped
		,[tr_expectedArrival] = @tr_expectedArrival
		,[tr_transitPort] = @tr_transitPort
		,[tr_ship_arrivedAtPort] = @tr_ship_arrivedAtPort
		,[tr_dateArrived] = @tr_dateArrived
		,[tr_actualArrived] = @tr_actualArrived
		,[tr_ship_BlNo] = @tr_ship_BlNo
		,[tr_ship_invoiceNo] = @tr_ship_invoiceNo
		,[tr_ship_invoiceAmt] = @tr_ship_invoiceAmt
		,[tr_ship_quantity] = @tr_ship_quantity
		,[tr_ship_vesselNo] = @tr_ship_vesselNo
		,[tr_ship_primaryShipperId] = @tr_ship_primaryShipperId
		,[tr_ship_portLoad] = @tr_ship_portLoad
		,[tr_ship_portDest] = @tr_ship_portDest
		,[tr_ship_shipLineCont] = @tr_ship_shipLineCont
		,[tr_editedBy] = @tr_editedBy
		,[tr_editedOn] = GETDATE()
		,[tr_ship_chk_reason] = @tr_ship_chk_reason
      ,[tr_ship_chk_shpExt] = @tr_ship_chk_shpExt
      ,[tr_ship_chk_expShp] = @tr_ship_chk_expShp
      ,[tr_ship_chk_inTransit] = @tr_ship_chk_inTransit
      ,[tr_ship_chk_dateShipped] = @tr_ship_chk_dateShipped
      ,[tr_ship_chk_expArrival] = @tr_ship_chk_expArrival
      ,[tr_ship_chk_transitPort] = @tr_ship_chk_transitPort
      ,[tr_ship_chk_dateArrived] = @tr_ship_chk_dateArrived
      ,[tr_ship_chk_actualArrived] = @tr_ship_chk_actualArrived
	  WHERE tr_transactionID = @tr_transactionID
	END
	ELSE IF @crudOperation = 'DELETE'
	BEGIN
		 DELETE FROM [dbo].[TransactionsShipment] WHERE tr_transactionID = @tr_transactionID
	END
END