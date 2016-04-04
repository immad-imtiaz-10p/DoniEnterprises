CREATE TABLE [dbo].[dailyProductPrices] (
    [Prod_ID]      INT      NOT NULL,
    [PriceDate]    DATETIME NOT NULL,
    [Price]        INT      NULL,
    [tr_createdBy] INT      NOT NULL,
    [tr_editedBy]  INT      NULL,
    [tr_createdOn] DATETIME NOT NULL,
    [tr_editedOn]  DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Prod_ID] ASC, [PriceDate] ASC),
    FOREIGN KEY ([Prod_ID]) REFERENCES [dbo].[Products] ([ProductId]),
    FOREIGN KEY ([tr_createdBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([tr_editedBy]) REFERENCES [dbo].[AppUsers] ([UserID])
);

