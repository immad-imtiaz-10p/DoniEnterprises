CREATE Procedure [dbo].[uspUpdateBusinessPartnerBankDetails]
(
	@bankDetails_ID bigint,
	@bpID bigint,
	@branchAddress NVARCHAR(max),
	@bankName NVARCHAR(150),
	@AccountTitle NVARCHAR(150),
	@AccountNumber NVARCHAR(100),
	@AccountCountry NVARCHAR(150)
)
AS 
BEGIN
UPDATE [dbo].[BusinessPartner_BankDetails]
       SET
	        [bp_ID] = @bpID
           ,[branchAddress] = @branchAddress
           ,[bankName] = @bankName
           ,[AccountTitle] = @AccountTitle
           ,[AccountNumber] = @AccountNumber
           ,[AccountCountry] = @AccountCountry
       WHERE bankDetails_ID = @bankDetails_ID
END