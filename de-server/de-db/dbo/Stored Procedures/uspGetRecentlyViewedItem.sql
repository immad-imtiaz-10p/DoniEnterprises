CREATE PROCEDURE dbo.uspGetRecentlyViewedItem
(
	@UserID int
)
AS 
BEGIN
	SELECT TOP 5 * FROM dbo.transactionViewed ORDER BY tr_visitedID DESC
END