CREATE Procedure [dbo].[uspUpdateBusinessPartnerContactNumber](
	@ph_ID bigint,
	@bpID bigint,
	@contactType NVARCHAR(50),
	@ContactNumber NVARCHAR(300),
	@editedBy int
)
AS
BEGIN

UPDATE 
	[dbo].[BusinessPartner_ContactNumbers]
    SET     [bp_ID] = @bpID
           ,[contactNumber] = @ContactNumber
           ,[contactType] = @ContactType           
           ,[editedOn] = GETDATE()
           ,[editedBy] = @editedBy
    WHERE ph_ID = @ph_ID
END