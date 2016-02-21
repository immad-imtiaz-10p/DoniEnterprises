CREATE TYPE [dbo].[ContactPerson] AS TABLE (
    [fullname]    NVARCHAR (250) NULL,
    [designation] NVARCHAR (100) NULL,
    [isPrimary]   BIT            NULL,
    [email]       NVARCHAR (400) NULL,
    [contactNum1] NVARCHAR (100) NULL,
    [contactNum2] NVARCHAR (100) NULL);

