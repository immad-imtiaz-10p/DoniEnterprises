CREATE TABLE [dbo].[userDashboardProducts] (
    [userid]    INT NOT NULL,
    [productId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([userid] ASC, [productId] ASC),
    FOREIGN KEY ([productId]) REFERENCES [dbo].[Products] ([ProductId]),
    FOREIGN KEY ([userid]) REFERENCES [dbo].[AppUsers] ([UserID])
);

