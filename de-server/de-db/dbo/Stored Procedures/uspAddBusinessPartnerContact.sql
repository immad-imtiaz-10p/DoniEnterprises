
CREATE Procedure [dbo].[uspAddBusinessPartnerContact](
	@bpId bigint,
	@bp_Cont_IsPrimary bit,
	@bp_Cont_fullName nvarchar(100),
	@bp_Cont_designation nvarchar(100),
	@bp_Cont_Email nvarchar(100),
	@bp_Cont_PrimaryNumber nvarchar(100),
	@bp_Cont_SecondryNumber nvarchar(100),
	@bp_Cont_CreatedBy int
)
AS

BEGIN

INSERT INTO [dbo].[BusinessPartner_Contacts]
           ([bp_ID]
           ,[bp_Cont_IsPrimary]
           ,[bp_Cont_fullName]
           ,[bp_Cont_designation]
           ,[bp_Cont_Email]
           ,[bp_Cont_PrimaryNumber]
           ,[bp_Cont_SecondryNumber]
           ,[bp_Cont_CreatedOn]
           ,[bp_Cont_LastEditedOn]
           ,[bp_Cont_CreatedBy]
           ,[bp_Cont_EditedBy])
     VALUES
           (@bpID, @bp_Cont_IsPrimary,@bp_Cont_fullName,@bp_Cont_designation,@bp_Cont_Email, @bp_Cont_PrimaryNumber, @bp_Cont_SecondryNumber, GETDATE(),null,@bp_Cont_CreatedBy,null)

DECLARE @bp_contact_Id bigint


SELECT Top 1 @bp_contact_Id = bpc.bp_cont_ID 
FROM [dbo].[BusinessPartner_Contacts] bpc 
ORDER BY bpc.bp_cont_ID DESC

SELECT @bp_contact_Id 

END