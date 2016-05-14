CREATE TABLE [dbo].[UserEvents] (
    [EventID]          INT            IDENTITY (1, 1) NOT NULL,
    [UserID]           INT            NULL,
    [EventTime]        DATETIME       NULL,
    [EventDescription] NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([EventID] ASC),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[AppUsers] ([UserID])
);

