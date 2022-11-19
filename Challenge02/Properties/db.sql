-- CREATE DATABASE
USE [master];
CREATE DATABASE [miniERP];
GO;

-- CREATE TABLES
USE [miniERP];
CREATE TABLE [dbo].[Users]
(
    [Id]        UNIQUEIDENTIFIER NOT NULL DEFAULT (newid()),
    [FirstName] NVARCHAR(50)     NOT NULL,
    [LastName]  NVARCHAR(50)     NOT NULL,
    [Password]  NVARCHAR(50)     NOT NULL,
    [Email]     NVARCHAR(50)     NOT NULL,
    [Salt]      NVARCHAR(50)     NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Users_Email] UNIQUE ([Email])
);

CREATE TABLE [dbo].[Customers]
(
    [Id]            UNIQUEIDENTIFIER NOT NULL DEFAULT (newid()),
    [FirstName]     VARCHAR(50)      NOT NULL,
    [LastName]      VARCHAR(50)      NOT NULL,
    [Address]       VARCHAR(100)     NOT NULL,
    [City]          VARCHAR(50)      NOT NULL,
    [State]         VARCHAR(50)      NOT NULL,
    [Zip]           VARCHAR(50)      NOT NULL,
    [Phone]         VARCHAR(50),
    [Email]         VARCHAR(50)      NOT NULL,
    [PaymentMethod] INT              NOT NULL DEFAULT (0),
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Customers_Email] UNIQUE ([Email]),
    CONSTRAINT [CK_Customers_PaymentType] CHECK ([PaymentMethod] IN (0, 1, 2))
);

CREATE TABLE [dbo].[Categories]
(
    [Id]          UNIQUEIDENTIFIER NOT NULL DEFAULT (newid()),
    [Name]        VARCHAR(50)      NOT NULL,
    [Description] VARCHAR(100),
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Categories_Name] UNIQUE ([Name])
);

CREATE TABLE [dbo].[Suppliers]
(
    [Id]            UNIQUEIDENTIFIER NOT NULL DEFAULT (newid()),
    [CompanyName]   VARCHAR(50)      NOT NULL,
    [FirstName]     VARCHAR(50)      NOT NULL,
    [LastName]      VARCHAR(50)      NOT NULL,
    [Address]       VARCHAR(100)     NOT NULL,
    [City]          VARCHAR(50)      NOT NULL,
    [State]         VARCHAR(50)      NOT NULL,
    [Zip]           VARCHAR(50)      NOT NULL,
    [Phone]         VARCHAR(50)      NOT NULL,
    [Email]         VARCHAR(50)      NOT NULL,
    [PaymentMethod] INT              NOT NULL DEFAULT (0),
    CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Suppliers_Email] UNIQUE ([Email]),
    CONSTRAINT [CK_Suppliers_PaymentType] CHECK ([PaymentMethod] IN (0, 1, 2))
);

CREATE TABLE [dbo].[Shippers]
(
    [Id]          UNIQUEIDENTIFIER NOT NULL DEFAULT (newid()),
    [CompanyName] VARCHAR(50)      NOT NULL,
    [Phone]       VARCHAR(50)      NOT NULL,
    CONSTRAINT [PK_Shippers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Shippers_CompanyName] UNIQUE ([CompanyName])
);

CREATE TABLE [dbo].[Products]
(
    [Id]          UNIQUEIDENTIFIER NOT NULL DEFAULT (newid()),
    [Name]        VARCHAR(50)      NOT NULL,
    [Description] VARCHAR(100),
    [UnitPrice]   DECIMAL(18, 2)   NOT NULL,
    [CategoryId]  UNIQUEIDENTIFIER NOT NULL,
    [SupplierId]  UNIQUEIDENTIFIER NOT NULL,
    [IsActive]    BIT              NOT NULL DEFAULT (1),
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Products_Name] UNIQUE ([Name]),
    CONSTRAINT [FK_Products_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]),
    CONSTRAINT [FK_Products_Suppliers] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Suppliers] ([Id]),
    CONSTRAINT [CK_Products_UnitPrice] CHECK ([UnitPrice] > 0),
    CONSTRAINT [CK_Products_Active] CHECK ([IsActive] IN (0, 1))
);

CREATE TABLE [dbo].[Inventory]
(
    [Id]        UNIQUEIDENTIFIER NOT NULL DEFAULT (newid()),
    [ProductId] UNIQUEIDENTIFIER NOT NULL,
    [Quantity]  INT              NOT NULL DEFAULT (0),
    CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Inventory_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]),
    CONSTRAINT [CK_Inventory_Quantity] CHECK ([Quantity] >= 0),
    CONSTRAINT [UQ_Inventory_ProductId] UNIQUE ([ProductId])
);

CREATE TABLE [dbo].[Payments]
(
    [Id]          UNIQUEIDENTIFIER NOT NULL DEFAULT (newid()),
    [CustomerId]  UNIQUEIDENTIFIER NOT NULL,
    [PaymentDate] DATETIME         NOT NULL DEFAULT (getdate()),
    [Amount]      DECIMAL(18, 2)   NOT NULL DEFAULT (0),
    CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Payments_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id]),
    CONSTRAINT [CK_Payments_Amount] CHECK ([Amount] > 0)
);

CREATE TABLE [dbo].[Orders]
(
    [Id]         UNIQUEIDENTIFIER NOT NULL DEFAULT (newid()),
    [CustomerId] UNIQUEIDENTIFIER NOT NULL,
    [OrderDate]  DATETIME         NOT NULL DEFAULT (getdate()),
    [ShipDate]   DATETIME,
    [ShipperId]  UNIQUEIDENTIFIER NOT NULL,
    [Total]      DECIMAL(18, 2)   NOT NULL DEFAULT (0),
    [IsActive]   BIT              NOT NULL DEFAULT (1),
    [PaymentId]  UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id]),
    CONSTRAINT [FK_Orders_Shippers] FOREIGN KEY ([ShipperId]) REFERENCES [dbo].[Shippers] ([Id]),
    CONSTRAINT [FK_Orders_Payments] FOREIGN KEY ([PaymentId]) REFERENCES [dbo].[Payments] ([Id]),
    CONSTRAINT [CK_Orders_Total] CHECK ([Total] >= 0),
    CONSTRAINT [CK_Orders_Active] CHECK ([IsActive] IN (0, 1))
);

CREATE TABLE [dbo].[OrderDetails]
(
    [Id]         UNIQUEIDENTIFIER NOT NULL DEFAULT (newid()),
    [OrderId]    UNIQUEIDENTIFIER NOT NULL,
    [ProductId]  UNIQUEIDENTIFIER NOT NULL,
    [Quantity]   INT              NOT NULL DEFAULT (0),
    [TotalPrice] DECIMAL(18, 2)   NOT NULL DEFAULT (0),
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]),
    CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]),
    CONSTRAINT [CK_OrderDetails_Quantity] CHECK ([Quantity] > 0),
    CONSTRAINT [CK_OrderDetails_UnitPrice] CHECK ([TotalPrice] > 0)
);

-- INSERT DATA
INSERT INTO [dbo].[Users] ([FirstName], [LastName], [Email], [Password], [Salt])
VALUES ('Admin', 'Admin', 'admin', 'jxWisimSvNK1nOmZrcnF0l8lRxVZ/hXA+wZVLkT4JUs=', '9RibeTWZ6FrrNdtwhKY5GQ==')

INSERT INTO [dbo].[Categories] ([Name], [Description])
VALUES ('Beverages', 'Soft drinks, coffees, teas, beers, and ales')
INSERT INTO [dbo].[Categories] ([Name], [Description])
VALUES ('Condiments', 'Sweet and savory sauces, relishes, spreads, and seasonings')
INSERT INTO [dbo].[Categories] ([Name], [Description])
VALUES ('Confections', 'Desserts, candies, and sweet breads')

INSERT INTO [dbo].[Suppliers] ([CompanyName], [FirstName], [LastName], [Address], [City], [State], [Zip], [Phone],
                               [Email], [PaymentMethod])
VALUES ('Exotic Liquids', 'Charlotte', 'Cooper', '49 Gilbert St.', 'London', 'London', 'EC1 4SD', '(171) 555-2222',
        'fakeemail5@fakeemail.com', 0)
INSERT INTO [dbo].[Suppliers] ([CompanyName], [FirstName], [LastName], [Address], [City], [State], [Zip], [Phone],
                               [Email], [PaymentMethod])
VALUES ('New Orleans Cajun Delights', 'Shelley', 'Burke', 'P.O. Box 78934', 'New Orleans', 'LA', '70117',
        '(100) 555-4822', 'fakeemail4@fakeemail.com', 0)

INSERT INTO [dbo].[Shippers] ([CompanyName], [Phone])
VALUES ('Speedy Express', '(503) 555-9831')
INSERT INTO [dbo].[Shippers] ([CompanyName], [Phone])
VALUES ('United Package', '(503) 555-3199')

INSERT INTO [dbo].[Customers] ([FirstName], [LastName], [Address], [City], [State], [Zip], [Phone], [Email],
                               [PaymentMethod])
VALUES ('Maria', 'Anders', 'Obere Str. 57', 'Berlin', 'Berlin', '12209', '030-0074321', 'fakeemail2@fakeemail.com', 1)
INSERT INTO [dbo].[Customers] ([FirstName], [LastName], [Address], [City], [State], [Zip], [Phone], [Email],
                               [PaymentMethod])
VALUES ('Ana', 'Trujillo', 'Avda. de la Constitución 2222', 'México D.F.', 'México D.F.', '05021', '(5) 555-4729',
        'fakeemail3@fakeemail.com', 1)

INSERT INTO [dbo].[Products] ([Name], [Description], [UnitPrice], [CategoryId], [SupplierId])
VALUES ('Chai', 'Spicy chai', 18.0000, (SELECT [Id] FROM [dbo].[Categories] WHERE [Name] = 'Beverages'),
        (SELECT [Id] FROM [dbo].[Suppliers] WHERE [CompanyName] = 'Exotic Liquids'))
INSERT INTO [dbo].[Products] ([Name], [Description], [UnitPrice], [CategoryId], [SupplierId])
VALUES ('Chang', 'An ancient Asian fermented beverage', 19.0000,
        (SELECT [Id] FROM [dbo].[Categories] WHERE [Name] = 'Beverages'),
        (SELECT [Id] FROM [dbo].[Suppliers] WHERE [CompanyName] = 'Exotic Liquids'))

INSERT INTO [dbo].[Payments] ([CustomerId], [PaymentDate], [Amount])
VALUES ((SELECT [Id] FROM [dbo].[Customers] WHERE [FirstName] = 'Maria' AND [LastName] = 'Anders'), '2018-01-01',
        100.00)
INSERT INTO [dbo].[Payments] ([CustomerId], [PaymentDate], [Amount])
VALUES ((SELECT [Id] FROM [dbo].[Customers] WHERE [FirstName] = 'Ana' AND [LastName] = 'Trujillo'), '2018-01-01',
        150.00)

INSERT INTO [dbo].[Orders] ([CustomerId], [ShipperId], [PaymentId], [OrderDate], [ShipDate], [Total], [IsActive])
VALUES ((SELECT [Id] FROM [dbo].[Customers] WHERE [FirstName] = 'Maria' AND [LastName] = 'Anders'),
        (SELECT [Id] FROM [dbo].[Shippers] WHERE [CompanyName] = 'Speedy Express'),
        (SELECT [Id]
         FROM [dbo].[Payments]
         WHERE [CustomerId] =
               (SELECT [Id] FROM [dbo].[Customers] WHERE [FirstName] = 'Maria' AND [LastName] = 'Anders')),
        '2018-01-01', '2018-01-03', 100.00, 1)
INSERT INTO [dbo].[Orders] ([CustomerId], [ShipperId], [PaymentId], [OrderDate], [ShipDate], [Total], [IsActive])
VALUES ((SELECT [Id] FROM [dbo].[Customers] WHERE [FirstName] = 'Ana' AND [LastName] = 'Trujillo'),
        (SELECT [Id] FROM [dbo].[Shippers] WHERE [CompanyName] = 'United Package'),
        (SELECT [Id]
         FROM [dbo].[Payments]
         WHERE [CustomerId] =
               (SELECT [Id] FROM [dbo].[Customers] WHERE [FirstName] = 'Ana' AND [LastName] = 'Trujillo')),
        '2018-01-01', '2018-01-03', 150.00, 1)

INSERT INTO [dbo].[OrderDetails] ([OrderId], [ProductId], [Quantity], [TotalPrice])
VALUES ((SELECT [Id]
         FROM [dbo].[Orders]
         WHERE [CustomerId] =
               (SELECT [Id] FROM [dbo].[Customers] WHERE [FirstName] = 'Maria' AND [LastName] = 'Anders')),
        (SELECT [Id] FROM [dbo].[Products] WHERE [Name] = 'Chai'),
        1, 18.00)
INSERT INTO [dbo].[OrderDetails] ([OrderId], [ProductId], [Quantity], [TotalPrice])
VALUES ((SELECT [Id]
         FROM [dbo].[Orders]
         WHERE [CustomerId] =
               (SELECT [Id] FROM [dbo].[Customers] WHERE [FirstName] = 'Ana' AND [LastName] = 'Trujillo')),
        (SELECT [Id] FROM [dbo].[Products] WHERE [Name] = 'Chang'),
        1, 19.00)

INSERT INTO [dbo].[Inventory] ([ProductId], [Quantity])
VALUES ((SELECT [Id] FROM [dbo].[Products] WHERE [Name] = 'Chai'), 100)
INSERT INTO [dbo].[Inventory] ([ProductId], [Quantity])
VALUES ((SELECT [Id] FROM [dbo].[Products] WHERE [Name] = 'Chang'), 100)

-- QUERIES
SELECT *
FROM [dbo].[Categories];
SELECT *
FROM [dbo].[Customers];
SELECT *
FROM [dbo].[Suppliers];
SELECT *
FROM [dbo].[Shippers];
SELECT *
FROM [dbo].[Products];
SELECT *
FROM [dbo].[Inventory];
SELECT *
FROM [dbo].[Orders];
SELECT *
FROM [dbo].[OrderDetails];
SELECT *
FROM [dbo].[Payments];
SELECT *
FROM [dbo].[Users];
