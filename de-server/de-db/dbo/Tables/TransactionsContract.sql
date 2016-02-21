CREATE TABLE [dbo].[TransactionsContract] (
    [tr_transactionID]    BIGINT   NOT NULL,
    [tr_doniContract]     BIT      DEFAULT ((0)) NULL,
    [tr_ownContract]      BIT      DEFAULT ((0)) NULL,
    [tr_ContractualBuyer] BIGINT   NULL,
    [tr_createdBy]        INT      NOT NULL,
    [tr_createdOn]        DATETIME NULL,
    [tr_editedBy]         INT      NULL,
    [tr_editedOn]         DATETIME NULL,
    PRIMARY KEY CLUSTERED ([tr_transactionID] ASC),
    FOREIGN KEY ([tr_ContractualBuyer]) REFERENCES [dbo].[BusinessPartner] ([bp_ID]),
    FOREIGN KEY ([tr_createdBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([tr_editedBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([tr_transactionID]) REFERENCES [dbo].[Transactions] ([tr_transactionID])
);

