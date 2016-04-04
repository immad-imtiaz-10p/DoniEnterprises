CREATE TABLE [dbo].[BusinessPartner_BankDetails] (
    [bankDetails_ID] BIGINT         IDENTITY (1, 1) NOT NULL,
    [bp_ID]          BIGINT         NOT NULL,
    [branchAddress]  NVARCHAR (MAX) NOT NULL,
    [bankName]       NVARCHAR (100) NULL,
    [AccountTitle]   NVARCHAR (150) NULL,
    [AccountNumber]  NVARCHAR (100) NULL,
    [AccountCountry] NVARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([bp_ID] ASC, [bankDetails_ID] ASC),
    FOREIGN KEY ([bp_ID]) REFERENCES [dbo].[BusinessPartner] ([bp_ID])
);

