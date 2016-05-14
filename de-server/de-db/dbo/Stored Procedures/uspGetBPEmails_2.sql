CREATE PROCEDURE [dbo].[uspGetBPEmails]
(
	@bp_ID bigint
)
AS
BEGIN
	SELECT * from dbo.BusinessPartner_Emails bp where bp.bp_ID = @bp_ID 
END