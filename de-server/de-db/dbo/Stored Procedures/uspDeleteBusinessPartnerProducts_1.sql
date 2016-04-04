CREATE PROCEDURE [dbo].[uspDeleteBusinessPartnerProducts]
(
  @bp_ID bigint,
  @prod_ID int
)
AS 
BEGIN
	DELETE FROM dbo.BusinessPartner_Products WHERE bp_ID = @bp_ID AND prod_ID = @prod_ID
END 