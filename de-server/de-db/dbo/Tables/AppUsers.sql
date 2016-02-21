CREATE TABLE [dbo].[AppUsers] (
    [UserID]          INT              IDENTITY (1, 1) NOT NULL,
    [UserPass]        NVARCHAR (MAX)   NOT NULL,
    [UserEmail]       NVARCHAR (128)   NOT NULL,
    [CreatedOn]       DATETIME         NOT NULL,
    [UserGuid]        UNIQUEIDENTIFIER NOT NULL,
    [UserDesignation] VARCHAR (200)    NOT NULL,
    [IsSuperUser]     BIT              DEFAULT ((0)) NOT NULL,
    [initials]        NVARCHAR (10)    NULL,
    [firstName]       NVARCHAR (50)    NULL,
    [lastName]        NVARCHAR (50)    NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [Unique_Email] UNIQUE NONCLUSTERED ([UserEmail] ASC),
    CONSTRAINT [Unique_Guid] UNIQUE NONCLUSTERED ([UserGuid] ASC)
);

