CREATE PROC [dbo].[uspAddTransaction]
(
           @tr_bpBuyerID bigint,
           @tr_bpSellerID bigint,
           @tr_productID int,
           @tr_fileID nvarchar(200),
           @tr_contractID nvarchar(200),
           @tr_date datetime,
           @tr_price int,
           @tr_FCL bit,
           @tr_MT bit,
           @tr_coversion_FCMT int,
           @tr_quantity int,
           @tr_doniContract bit,
           @tr_ownContract bit,
           @tr_contractualBuyer bigint,
           @tr_broker bigint,
           @tr_comissonType nvarchar(200),
           @tr_brokerComission int,
           @tr_differance int,
           @tr_discount int,
           @tr_netCommision int,
           @tr_shipmentDate datetime,
           @tr_shipmentAdddress nvarchar(max),
           @tr_shipmentStatus nvarchar(200),
           @tr_shipperID bigint,
           @tr_createdBy int,
		   @tr_washOutValue int,
		   @tr_shipmentCountry NVARCHAR(150),
		   @tr_commission int, 
		   @tr_transactionStatus NVARCHAR(200),
		   @tr_brokerInvolved bit
)
AS 
BEGIN

INSERT INTO [dbo].[Transactions]
           ([tr_bpBuyerID]
           ,[tr_bpSellerID]
           ,[tr_productID]
           ,[tr_fileID]
           ,[tr_contractID]
           ,[tr_date]
           ,[tr_price]
           ,[tr_FCL]
           ,[tr_MT]
           ,[tr_coversion_FCMT]
           ,[tr_quantity]
           ,[tr_doniContract]
           ,[tr_ownContract]
           ,[tr_contractualBuyer]
           ,[tr_broker]
           ,[tr_comissonType]
           ,[tr_brokerComission]
           ,[tr_differance]
           ,[tr_discount]
           ,[tr_netCommision]
           ,[tr_shipmentDate]
           ,[tr_shipmentAdddress]
           ,[tr_shipmentStatus]
           ,[tr_shipperID]
           ,[tr_createdOn]
           ,[tr_lastEditedOn]
           ,[tr_createdBy]
           ,[tr_lastEditedBy]
           ,[tr_washOutValue]
           ,[tr_shipmentCountry]
           ,[tr_commission]
           ,[tr_transactionStatus]
           ,[tr_brokerInvolved])
     VALUES
           (@tr_bpBuyerID,@tr_bpSellerID,@tr_productID,@tr_fileID,@tr_contractID,@tr_date,@tr_price,@tr_FCL,
		    @tr_MT,@tr_coversion_FCMT, @tr_quantity, @tr_doniContract, @tr_ownContract, @tr_contractualBuyer,
			@tr_broker,@tr_comissonType,@tr_brokerComission,@tr_differance,@tr_discount,@tr_netCommision,
            @tr_shipmentDate,@tr_shipmentAdddress,@tr_shipmentStatus,@tr_shipperID,GETDATE(),null,@tr_createdBy,
			null,@tr_washOutValue,@tr_shipmentCountry,@tr_commission, @tr_transactionStatus, @tr_brokerInvolved)
			
SELECT TOP 1 t.tr_transactionID from dbo.Transactions t order by t.tr_transactionID DESC			 


END