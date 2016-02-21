CREATE PROCEDURE [dbo].[uspDeleteBusinessPartner]
(
	@bp_ID bigint
)
AS
BEGIN
	
	DELETE FROM dbo.BusinessPartner_BankDetails where bp_ID = @bp_ID
	DELETE FROM dbo.BusinessPartner_ContactNumbers where bp_ID = @bp_ID
	DELETE FROM dbo.BusinessPartner_Emails where bp_ID = @bp_ID
    DELETE FROM dbo.BusinessPartner_Products where bp_ID = @bp_ID	 
	DELETE FROM dbo.BusinessPartner_Contacts where bp_ID = @bp_ID
	DELETE FROM dbo.BusinessPartner where bp_ID  = @bp_ID	
END