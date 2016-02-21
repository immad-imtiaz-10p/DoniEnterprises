CREATE PROCEDURE dbo.uspAddBusinessPartnerEmail(
	@bp_ID bigint,
	@email NVARCHAR(300)
)
AS 
BEGIN
	INSERT INTO [dbo].[BusinessPartner_Emails]
           ([bp_ID]
           ,[email])
     VALUES
           ( @bp_ID, @email) 
END