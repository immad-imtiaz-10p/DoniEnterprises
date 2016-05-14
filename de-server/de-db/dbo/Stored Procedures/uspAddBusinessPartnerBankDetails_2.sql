CREATE Procedure [dbo].[uspAddBusinessPartnerBankDetails]
(
	@bpID bigint,
	@branchAddress NVARCHAR(max),
	@bankName NVARCHAR(150),
	@AccountTitle NVARCHAR(150),
	@AccountNumber NVARCHAR(100),
	@AccountCountry NVARCHAR(150)
)
AS 
BEGIN
INSERT INTO [dbo].[BusinessPartner_BankDetails]
           ([bp_ID]
           ,[branchAddress]
           ,[bankName]
           ,[AccountTitle]
           ,[AccountNumber]
           ,[AccountCountry])
     VALUES
           (@bpID,@branchAddress,@bankName,@AccountTitle,@AccountNumber,@AccountCountry)

DECLARE @bankDetails_ID bigint

SELECT  
        Top 1 @bankDetails_ID =  bd.bankDetails_ID 
		FROM dbo.BusinessPartner_BankDetails bd 
		ORDER BY bd.bankDetails_ID DESC

SELECT @bankDetails_ID

END