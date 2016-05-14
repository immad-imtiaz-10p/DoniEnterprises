CREATE PROC [dbo].[uspUpdateBusinessPartner]
(
	@bp_ID bigint,
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
	UPDATE [dbo].[BusinessPartner]
            SET 
			[bp_Name] = @BPName
           ,[bp_website] = @BPWebsite
           ,[bp_credibilityIndex] = @ReliabilityIndex
           ,[bp_onDoniContract] = @OnDoniContract
           ,[bp_isBuyer] = @IsBuyer
           ,[bp_isSeller] = @IsSupplier
           ,[bp_isShipper] = @IsShipper
           ,[bp_isBroker] = @IsBroker
           ,[bp_country] = @Country
           ,[bp_address] = @Address
     WHERE bp_ID = @bp_ID
END