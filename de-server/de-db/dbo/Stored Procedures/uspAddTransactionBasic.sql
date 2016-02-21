CREATE PROC [dbo].[uspAddTransactionBasic]
(
		 @tr_date datetime,
         @tr_bpBuyerID bigint,
         @tr_bpSellerID bigint,
         @tr_productID int,
         @tr_origin nvarchar(150),
         @tr_quantity int,
         @tr_price int,
         @tr_packing nvarchar(1),
         @tr_shipment_start datetime,
         @tr_shipment_end datetime,
         @tr_fileID nvarchar(200),
         @tr_contractID nvarchar(200),
         @tr_other_info varchar(max),
         @tr_createdBy int,
         @tr_createdOn datetime,
         @tr_editedBy int,
         @tr_editedOn datetime
)
AS
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
           (@tr_date, @tr_bpBuyerID,
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

SELECT TOP 1 t.tr_transactionID FROM dbo.Transactions  t order by t.tr_transactionID desc 

END



