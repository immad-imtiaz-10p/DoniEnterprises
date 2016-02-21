CREATE TABLE [dbo].[transactionViewed] (
    [tr_visitedID]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [tr_visitedOn]         DATETIME       NOT NULL,
    [tr_pageVisitedState]  NVARCHAR (MAX) NOT NULL,
    [tr_pageVisitedParams] NVARCHAR (MAX) NOT NULL,
    [tr_pageTitle]         NVARCHAR (100) NULL,
    [UserID]               INT            NULL,
    PRIMARY KEY CLUSTERED ([tr_visitedID] ASC),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[AppUsers] ([UserID])
);

