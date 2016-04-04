CREATE TABLE [dbo].[Products] (
    [ProductId]     INT            IDENTITY (1, 1) NOT NULL,
    [ProductName]   NVARCHAR (250) NULL,
    [CreatedOn]     DATETIME       NOT NULL,
    [CreatedBy]     INT            NULL,
    [LastUpdatedOn] DATETIME       NULL,
    [LastUpdatedBy] INT            NULL,
    [moisture]      INT            DEFAULT ((0)) NULL,
    [purity]        INT            DEFAULT ((0)) NULL,
    [weaveled]      INT            DEFAULT ((0)) NULL,
    [origin]        VARCHAR (50)   NULL,
    [splits]        INT            DEFAULT ((0)) NULL,
    [quality]       NVARCHAR (MAX) NULL,
    [damaged]       INT            NULL,
    [foreignMatter] INT            NULL,
    [greenDamaged]  INT            NULL,
    [otherColor]    INT            NULL,
    [wrinkled]      INT            NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC),
    FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[AppUsers] ([UserID]),
    FOREIGN KEY ([LastUpdatedBy]) REFERENCES [dbo].[AppUsers] ([UserID])
);


GO
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20150915-215934]
    ON [dbo].[Products]([ProductId] ASC)
    INCLUDE([ProductName]);

