CREATE PROCEDURE dbo.uspAddRecentViewedItem
(
	@tr_visitedOn datetime,
	@tr_pageVisitedState nvarchar(max),
	@tr_pageVisitedParams nvarchar(max),
	@tr_pageTitle nvarchar(100),
	@UserID int
)
AS
BEGIN
INSERT INTO [dbo].[transactionViewed]
           ([tr_visitedOn]
           ,[tr_pageVisitedState]
           ,[tr_pageVisitedParams]
           ,[tr_pageTitle]
           ,[UserID])
     VALUES
           (
		   @tr_visitedOn,
           @tr_pageVisitedState,
           @tr_pageVisitedParams,
           @tr_pageTitle,
           @UserID
		   )
END