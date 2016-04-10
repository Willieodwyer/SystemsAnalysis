CREATE TABLE [dbo].[Supplier] (
    [SupplierID]  INT            NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [Address]     NVARCHAR (MAX) NULL,
    [PhoneNumber] INT            NULL,
    [Notes]       NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([SupplierID] ASC)
);

