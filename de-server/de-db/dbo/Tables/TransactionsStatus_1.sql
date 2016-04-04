CREATE TABLE [dbo].[TransactionsStatus] (
    [tr_transactionID]     BIGINT        NOT NULL,
    [tr_transactionStatus] VARCHAR (100) NOT NULL,
    [tr_washoutValueAtPar] INT           DEFAULT ((-1)) NULL,
    [tr_createdBy]         INT           NOT NULL,
    [tr_createdOn]         DATETIME      NULL,
    [tr_editedBy]          INT           NULL,
    [tr_editedOn]          DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([tr_transactionID] ASC),
    FOREIGN KEY ([tr_createdBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([tr_createdBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([tr_editedBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([tr_editedBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([tr_transactionID]) REFERENCES [dbo].[Transactions] ([tr_transactionID])
);

