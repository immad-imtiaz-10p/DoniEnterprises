CREATE TABLE [dbo].[BusinessPartner_ContactNumbers] (
    [ph_ID]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [bp_ID]         BIGINT         NOT NULL,
    [contactNumber] NVARCHAR (300) NOT NULL,
    [contactType]   NVARCHAR (50)  DEFAULT ('NOT GIVEN') NULL,
    [createdOn]     DATETIME       NULL,
    [createdBy]     INT            NULL,
    [editedOn]      DATETIME       NULL,
    [editedBy]      INT            NULL,
    PRIMARY KEY CLUSTERED ([bp_ID] ASC, [ph_ID] ASC),
    FOREIGN KEY ([bp_ID]) REFERENCES [dbo].[BusinessPartner] ([bp_ID]),
    FOREIGN KEY ([createdBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([editedBy]) REFERENCES [dbo].[AppUsers] ([UserID])
);

