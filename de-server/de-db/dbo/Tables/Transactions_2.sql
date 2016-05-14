CREATE TABLE [dbo].[Transactions] (
    [tr_transactionID]  BIGINT          IDENTITY (1, 1) NOT NULL,
    [tr_date]           DATETIME        NULL,
    [tr_bpBuyerID]      BIGINT          NULL,
    [tr_bpSellerID]     BIGINT          NULL,
    [tr_productID]      INT             NULL,
    [tr_origin]         NVARCHAR (150)  NULL,
    [tr_quantity]       DECIMAL (24, 2) NULL,
    [tr_price]          DECIMAL (24, 2) NULL,
    [tr_packing]        VARCHAR (50)    NULL,
    [tr_shipment_start] DATETIME        NULL,
    [tr_shipment_end]   DATETIME        NULL,
    [tr_fileID]         NVARCHAR (200)  NULL,
    [tr_contractID]     NVARCHAR (200)  NULL,
    [tr_other_info]     VARCHAR (MAX)   NULL,
    [tr_createdBy]      INT             NOT NULL,
    [tr_createdOn]      DATETIME        NULL,
    [tr_editedBy]       INT             NULL,
    [tr_editedOn]       DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([tr_transactionID] ASC),
    FOREIGN KEY ([tr_bpBuyerID]) REFERENCES [dbo].[BusinessPartner] ([bp_ID]),
    FOREIGN KEY ([tr_bpSellerID]) REFERENCES [dbo].[BusinessPartner] ([bp_ID]),
    FOREIGN KEY ([tr_createdBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([tr_editedBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([tr_productID]) REFERENCES [dbo].[Products] ([ProductId])
);


GO
CREATE NONCLUSTERED INDEX [NonClusteredIndex-TransactionDate]
    ON [dbo].[Transactions]([tr_transactionID] ASC, [tr_date] ASC)
    INCLUDE([tr_bpBuyerID], [tr_bpSellerID], [tr_productID]);

