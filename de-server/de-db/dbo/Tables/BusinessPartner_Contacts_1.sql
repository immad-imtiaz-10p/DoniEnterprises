CREATE TABLE [dbo].[BusinessPartner_Contacts] (
    [bp_cont_ID]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [bp_ID]                  BIGINT         NOT NULL,
    [bp_Cont_IsPrimary]      BIT            DEFAULT ((0)) NULL,
    [bp_Cont_fullName]       NVARCHAR (100) NOT NULL,
    [bp_Cont_designation]    NVARCHAR (100) NULL,
    [bp_Cont_Email]          NVARCHAR (100) NULL,
    [bp_Cont_PrimaryNumber]  NVARCHAR (100) NULL,
    [bp_Cont_SecondryNumber] NVARCHAR (100) NULL,
    [bp_Cont_CreatedOn]      DATETIME       NOT NULL,
    [bp_Cont_LastEditedOn]   DATETIME       NULL,
    [bp_Cont_CreatedBy]      INT            NULL,
    [bp_Cont_EditedBy]       INT            NULL,
    PRIMARY KEY CLUSTERED ([bp_ID] ASC, [bp_cont_ID] ASC),
    FOREIGN KEY ([bp_Cont_CreatedBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([bp_Cont_EditedBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([bp_ID]) REFERENCES [dbo].[BusinessPartner] ([bp_ID])
);

