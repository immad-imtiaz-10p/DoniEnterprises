CREATE PROCEDURE dbo.uspDeleteBusinessPartnerBankDetails
(
  @bankDetails_ID bigint
)
AS 
BEGIN
	DELETE FROM dbo.BusinessPartner_BankDetails WHERE bankDetails_ID = @bankDetails_ID 
END