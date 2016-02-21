CREATE TABLE [dbo].[BusinessPartner_Products] (
    [bp_ID]   BIGINT NOT NULL,
    [prod_ID] INT    NOT NULL,
    PRIMARY KEY CLUSTERED ([bp_ID] ASC, [prod_ID] ASC),
    FOREIGN KEY ([bp_ID]) REFERENCES [dbo].[BusinessPartner] ([bp_ID]),
    FOREIGN KEY ([prod_ID]) REFERENCES [dbo].[Products] ([ProductId])
);

