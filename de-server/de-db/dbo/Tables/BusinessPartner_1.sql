CREATE TABLE [dbo].[BusinessPartner] (
    [bp_ID]               BIGINT         IDENTITY (1, 1) NOT NULL,
    [bp_Name]             NVARCHAR (500) NOT NULL,
    [bp_website]          NVARCHAR (500) NULL,
    [bp_credibilityIndex] INT            DEFAULT ((0)) NOT NULL,
    [bp_onDoniContract]   BIT            DEFAULT ((0)) NULL,
    [bp_isBuyer]          BIT            DEFAULT ((0)) NULL,
    [bp_isSeller]         BIT            DEFAULT ((0)) NULL,
    [bp_isShipper]        BIT            DEFAULT ((0)) NULL,
    [bp_isBroker]         BIT            DEFAULT ((0)) NULL,
    [bp_country]          NVARCHAR (150) NULL,
    [bp_address]          NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([bp_ID] ASC)
);

