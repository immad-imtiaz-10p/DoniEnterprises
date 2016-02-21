CREATE TABLE [dbo].[AppUserRights] (
    [AppUserID] INT          NOT NULL,
    [Area]      VARCHAR (50) NOT NULL,
    [Actions]   VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([AppUserID] ASC, [Area] ASC, [Actions] ASC),
    FOREIGN KEY ([AppUserID]) REFERENCES [dbo].[AppUsers] ([UserID])
);

