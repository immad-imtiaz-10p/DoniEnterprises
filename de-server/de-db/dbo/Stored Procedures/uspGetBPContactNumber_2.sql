CREATE PROCEDURE [dbo].[uspGetBPContactNumber]
(
	@bp_ID bigint
)
AS
BEGIN
	SELECT * from dbo.BusinessPartner_ContactNumbers bp where bp.bp_ID = @bp_ID 
END