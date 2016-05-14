CREATE TABLE [dbo].[Origin] (
    [origin_id]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [origin_name] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([origin_id] ASC),
    UNIQUE NONCLUSTERED ([origin_name] ASC)
);

