CREATE TABLE [dbo].[ShipmentStatus] (
    [id]     INT          IDENTITY (1, 1) NOT NULL,
    [status] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

