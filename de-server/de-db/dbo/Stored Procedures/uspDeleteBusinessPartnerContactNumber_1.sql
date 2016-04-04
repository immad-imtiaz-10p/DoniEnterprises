CREATE PROCEDURE dbo.uspDeleteBusinessPartnerContactNumber
(
  @ph_ID bigint
)
AS 
BEGIN
	DELETE FROM dbo.BusinessPartner_ContactNumbers WHERE ph_ID = @ph_ID 
END 