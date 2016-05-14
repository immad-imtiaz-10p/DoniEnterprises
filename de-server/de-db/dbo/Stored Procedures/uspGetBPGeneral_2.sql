CREATE PROCEDURE [dbo].[uspGetBPGeneral]
(
	@bp_ID bigint
)
AS
BEGIN
	SELECT * from dbo.BusinessPartner bp where bp.bp_ID = @bp_ID 
END