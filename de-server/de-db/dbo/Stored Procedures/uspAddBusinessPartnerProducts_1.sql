CREATE PROCEDURE [dbo].[uspAddBusinessPartnerProducts](
	@bp_ID bigint,
	@prod_ID int
)
AS 
BEGIN
	INSERT INTO [dbo].[BusinessPartner_Products]
           ([bp_ID]
           ,[prod_ID])
     VALUES
           (@bp_ID,@prod_ID)

END