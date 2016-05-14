CREATE PROC [dbo].[uspAddBusinessPartner]
(
	@IsSupplier bit,
	@IsBroker bit,
	@IsShipper bit,
	@IsBuyer bit,
	@OnDoniContract bit,
	@CreatedBy int,
	@ReliabilityIndex int,
	@BPName  nvarchar(500),
	@BPWebsite NVARCHAR(500),
	@Address NVARCHAR(max),
	@Country NVARCHAR(150)
)
AS 
BEGIN
	INSERT INTO [dbo].[BusinessPartner]
           ([bp_Name]
           ,[bp_website]
           ,[bp_credibilityIndex]
           ,[bp_onDoniContract]
           ,[bp_isBuyer]
           ,[bp_isSeller]
           ,[bp_isShipper]
           ,[bp_isBroker]
           ,[bp_country]
           ,[bp_address])
     VALUES
           (@BPName
           ,@BPWebsite
           ,@ReliabilityIndex
		   ,@OnDoniContract
           ,@IsBuyer
           ,@IsSupplier
           ,@IsShipper
           ,@IsBroker
           ,@Country
           ,@Address)


DECLARE @bp_ID int

SELECT TOP 1 bp.bp_ID FROM dbo.BusinessPartner bp order by bp.bp_ID DESC
END