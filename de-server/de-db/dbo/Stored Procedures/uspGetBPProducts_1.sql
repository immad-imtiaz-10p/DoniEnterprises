CREATE PROCEDURE [dbo].[uspGetBPProducts]
(
	@bp_ID bigint
)
AS
BEGIN
	SELECT * 
	
	from dbo.BusinessPartner_Products bp
	where bp.bp_ID = @bp_ID 
END