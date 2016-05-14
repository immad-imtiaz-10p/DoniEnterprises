CREATE PROCEDURE [dbo].[uspUpdateBusinessPartnerProduct](
	@bp_ID bigint,
	@prod_ID NVARCHAR(300)
)
AS 
BEGIN
	 UPDATE [dbo].[BusinessPartner_Products]
            SET [prod_ID] = @prod_ID
     WHERE bp_ID = @bp_ID AND prod_ID = @prod_ID

END