CREATE TABLE [dbo].[Products] (
    [ProductID]  INT            NOT NULL,
    [Price]      FLOAT (53)     NULL,
    [Type]       NVARCHAR (MAX) NULL,
    [SupplierID] INT            NULL,
    [Name] NVARCHAR(MAX) NULL, 
    PRIMARY KEY CLUSTERED ([ProductID] ASC)
);

