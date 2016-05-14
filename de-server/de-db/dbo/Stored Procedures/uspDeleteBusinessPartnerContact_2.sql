CREATE PROCEDURE [dbo].[uspDeleteBusinessPartnerContact]
(
  @bp_Cont_ID bigint
)
AS 
BEGIN
	DELETE FROM dbo.BusinessPartner_Contacts WHERE bp_cont_ID = @bp_Cont_ID 
END