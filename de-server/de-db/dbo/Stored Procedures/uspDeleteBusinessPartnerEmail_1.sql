CREATE PROCEDURE dbo.uspDeleteBusinessPartnerEmail
(
  @email_ID bigint
)
AS 
BEGIN
	DELETE FROM dbo.BusinessPartner_Emails WHERE email_ID = @email_ID 
END 