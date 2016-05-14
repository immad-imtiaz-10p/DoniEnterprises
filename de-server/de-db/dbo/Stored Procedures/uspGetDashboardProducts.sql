CREATE PROCEDURE dbo.uspGetDashboardProducts
(
	@userId int
)
AS
BEGIN
	SELECT * FROM dbo.userDashboardProducts WHERE userid = @userId
END