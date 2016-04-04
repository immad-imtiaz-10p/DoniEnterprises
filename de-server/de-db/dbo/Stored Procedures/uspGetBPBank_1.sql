CREATE PROCEDURE dbo.uspGetBPBank
(
	@bp_ID bigint
)
AS
BEGIN
	SELECT * from dbo.BusinessPartner_BankDetails bp where bp.bp_ID = @bp_ID 
END