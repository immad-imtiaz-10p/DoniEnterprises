CREATE TABLE [dbo].[TransactionsNotes] (
    [tr_transactionID]    BIGINT        NOT NULL,
    [tr_tranNoteID]       BIGINT        IDENTITY (1, 1) NOT NULL,
    [tr_transactionNotes] VARCHAR (MAX) NULL,
    [tr_createdBy]        INT           NOT NULL,
    [tr_createdOn]        DATETIME      NULL,
    [tr_editedOn]         DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([tr_tranNoteID] ASC, [tr_transactionID] ASC),
    FOREIGN KEY ([tr_createdBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([tr_transactionID]) REFERENCES [dbo].[Transactions] ([tr_transactionID]),
    UNIQUE NONCLUSTERED ([tr_tranNoteID] ASC)
);

