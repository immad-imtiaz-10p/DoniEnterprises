CREATE PROCEDURE [dbo].[uspUpdateBusinessPartnerEmail](
	@bp_ID bigint,
	@email NVARCHAR(300)
)
AS 
BEGIN
	 UPDATE [dbo].[BusinessPartner_Emails]
	 SET
	 		[email] = @email
     WHERE bp_ID = @bp_ID 
END