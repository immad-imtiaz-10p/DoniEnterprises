CREATE TABLE [dbo].[dailyProductPrices] (
    [Prod_ID]      INT             NOT NULL,
    [PriceDate]    DATETIME        NOT NULL,
    [Price]        DECIMAL (24, 2) DEFAULT (NULL) NULL,
    [tr_createdBy] INT             NOT NULL,
    [tr_editedBy]  INT             NULL,
    [tr_createdOn] DATETIME        NOT NULL,
    [tr_editedOn]  DATETIME        NULL,
    [localPrice]   DECIMAL (24, 2) DEFAULT (NULL) NULL,
    PRIMARY KEY CLUSTERED ([Prod_ID] ASC, [PriceDate] ASC),
    FOREIGN KEY ([Prod_ID]) REFERENCES [dbo].[Products] ([ProductId]),
    FOREIGN KEY ([tr_createdBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([tr_editedBy]) REFERENCES [dbo].[AppUsers] ([UserID])
);

