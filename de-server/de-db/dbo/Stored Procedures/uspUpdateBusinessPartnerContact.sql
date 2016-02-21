CREATE Procedure [dbo].[uspUpdateBusinessPartnerContact](
	@bp_cont_ID bigint,
	@bpId bigint,
	@bp_Cont_IsPrimary bit,
	@bp_Cont_fullName nvarchar(100),
	@bp_Cont_designation nvarchar(100),
	@bp_Cont_Email nvarchar(100),
	@bp_Cont_PrimaryNumber nvarchar(100),
	@bp_Cont_SecondryNumber nvarchar(100),
	@bp_Cont_EditedBy int
)
AS

BEGIN

UPDATE [dbo].[BusinessPartner_Contacts]
       SET        
			[bp_ID] = @bpId
           ,[bp_Cont_IsPrimary] = @bp_Cont_IsPrimary
           ,[bp_Cont_fullName] = @bp_Cont_fullName
           ,[bp_Cont_designation] = @bp_Cont_designation
           ,[bp_Cont_Email] = @bp_Cont_Email
           ,[bp_Cont_PrimaryNumber] = @bp_Cont_PrimaryNumber
           ,[bp_Cont_SecondryNumber] = @bp_Cont_SecondryNumber
           ,[bp_Cont_LastEditedOn] = GETDATE()
           ,[bp_Cont_EditedBy] = @bp_Cont_EditedBy
	   WHERE 
			bp_cont_ID = @bp_cont_ID   

END