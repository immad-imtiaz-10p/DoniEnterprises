CREATE TABLE [dbo].[BusinessPartner_Emails] (
    [email_ID] BIGINT         IDENTITY (1, 1) NOT NULL,
    [bp_ID]    BIGINT         NOT NULL,
    [email]    NVARCHAR (300) NOT NULL,
    PRIMARY KEY CLUSTERED ([bp_ID] ASC, [email_ID] ASC),
    FOREIGN KEY ([bp_ID]) REFERENCES [dbo].[BusinessPartner] ([bp_ID])
);

