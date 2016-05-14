CREATE PROCEDURE [dbo].[uspGetBPContact]
(
	@bp_ID bigint
)
AS
BEGIN
	SELECT * from dbo.BusinessPartner_Contacts bp where bp.bp_ID = @bp_ID 
END