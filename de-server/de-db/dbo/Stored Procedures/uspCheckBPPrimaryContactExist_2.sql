CREATE PROCEDURE [dbo].[uspCheckBPPrimaryContactExist]
(
	@bp_ID bigint
)
AS
BEGIN
    DECLARE @NoOfPrimaryContacts int
	
	SELECT @NoOfPrimaryContacts = COUNT(*)  
		FROM dbo.BusinessPartner_Contacts bpc 
		WHERE bpc.bp_Cont_IsPrimary = 1 and bpc.bp_ID = @bp_ID
	
	SELECT @NoOfPrimaryContacts  
END