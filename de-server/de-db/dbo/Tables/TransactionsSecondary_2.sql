CREATE TABLE [dbo].[TransactionsSecondary] (
    [tr_transactionID]   BIGINT          NULL,
    [tr_sec_tranID]      BIGINT          IDENTITY (1, 1) NOT NULL,
    [tr_sec_bpBuyerID]   BIGINT          NULL,
    [tr_sec_bpSellerID]  BIGINT          NULL,
    [tr_sec_date]        DATETIME        NOT NULL,
    [tr_sec_buyerPrice]  DECIMAL (24, 2) NULL,
    [tr_sec_sellerPrice] DECIMAL (24, 2) NULL,
    [tr_sec_otherInfo]   VARCHAR (4000)  NULL,
    [tr_createdBy]       INT             NOT NULL,
    [tr_createdOn]       DATETIME        NULL,
    [tr_editedBy]        INT             NULL,
    [tr_editedOn]        DATETIME        NULL,
    [tr_sec_quantity]    DECIMAL (24, 2) NULL,
    PRIMARY KEY CLUSTERED ([tr_sec_tranID] ASC),
    FOREIGN KEY ([tr_createdBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([tr_editedBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([tr_sec_bpBuyerID]) REFERENCES [dbo].[BusinessPartner] ([bp_ID]),
    FOREIGN KEY ([tr_sec_bpSellerID]) REFERENCES [dbo].[BusinessPartner] ([bp_ID]),
    FOREIGN KEY ([tr_transactionID]) REFERENCES [dbo].[Transactions] ([tr_transactionID])
);

