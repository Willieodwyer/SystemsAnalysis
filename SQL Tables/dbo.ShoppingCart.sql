CREATE TABLE [dbo].[ShoppingCart] (
    [CustomerID] INT NOT NULL,
    [ProductID]  INT NULL,
    [Quantity]   INT NULL,
    PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);

