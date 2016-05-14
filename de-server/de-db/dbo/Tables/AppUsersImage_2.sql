CREATE TABLE [dbo].[AppUsersImage] (
    [AppUserID] INT   NOT NULL,
    [ImageData] IMAGE NULL,
    CONSTRAINT [PK_ImageData] PRIMARY KEY CLUSTERED ([AppUserID] ASC),
    FOREIGN KEY ([AppUserID]) REFERENCES [dbo].[AppUsers] ([UserID]) ON DELETE CASCADE
);

