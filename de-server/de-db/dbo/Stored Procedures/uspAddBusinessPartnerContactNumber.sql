
CREATE Procedure [dbo].[uspAddBusinessPartnerContactNumber](
	@bpId bigint,
	@contactType NVARCHAR(50),
	@ontactNumber NVARCHAR(300),
	@createdBy int
)
AS
BEGIN

INSERT INTO [dbo].[BusinessPartner_ContactNumbers]
           ([bp_ID]
           ,[contactNumber]
           ,[contactType]
           ,[createdOn]
           ,[createdBy]
           ,[editedOn]
           ,[editedBy])
     VALUES
           (@bpId
           ,@ontactNumber
           ,@contactType 
           ,GETDATE()
           ,@createdBy 
           ,null
           ,null)
	


END