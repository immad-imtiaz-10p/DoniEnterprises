CREATE TABLE [dbo].[TransactionFiles] (
    [tf_transactionID] BIGINT          NOT NULL,
    [tf_fileID]        INT             IDENTITY (1, 1) NOT NULL,
    [tf_file]          VARBINARY (MAX) NOT NULL,
    [tf_fileType]      VARCHAR (50)    NOT NULL,
    [tf_fileName]      VARCHAR (50)    NOT NULL,
    [tf_createdBy]     INT             NULL,
    [tf_createdOn]     DATETIME        NULL,
    [tf_editedBy]      INT             NULL,
    [tf_editedOn]      DATETIME        NULL,
    FOREIGN KEY ([tf_createdBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([tf_editedBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([tf_editedBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([tf_transactionID]) REFERENCES [dbo].[Transactions] ([tr_transactionID]),
    FOREIGN KEY ([tf_transactionID]) REFERENCES [dbo].[Transactions] ([tr_transactionID])
);

