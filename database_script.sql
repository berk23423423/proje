-- Yemekhane Menu Sistemi Veritabanı Script
-- SQL Server için hazırlanmıştır

-- Veritabanını oluştur
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'yemekhanemenusıstemı')
BEGIN
    CREATE DATABASE yemekhanemenusıstemı;
END
GO

USE yemekhanemenusıstemı;
GO

-- Users Tablosu
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[users]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[users] (
        [id] INT PRIMARY KEY IDENTITY(1,1),
        [username] VARCHAR(50) NOT NULL UNIQUE,
        [password] VARCHAR(255) NOT NULL,
        [status] VARCHAR(20) NOT NULL DEFAULT 'Active',
        [date_created] DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO

-- Categories Tablosu
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categories]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[categories] (
        [id] INT PRIMARY KEY IDENTITY(1,1),
        [category] VARCHAR(100) NOT NULL UNIQUE,
        [status] VARCHAR(20) NOT NULL DEFAULT 'Active',
        [date_insert] DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO

-- Products Tablosu
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[products]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[products] (
        [id] INT PRIMARY KEY IDENTITY(1,1),
        [productid] VARCHAR(50) NOT NULL UNIQUE,
        [productname] VARCHAR(255) NOT NULL,
        [category] VARCHAR(100) NOT NULL,
        [stock] INT NOT NULL DEFAULT 0,
        [price] DECIMAL(18,2) NOT NULL,
        [status] VARCHAR(20) NOT NULL DEFAULT 'Active',
        [image] VARCHAR(500) NULL,
        [date_insert] DATETIME NOT NULL DEFAULT GETDATE(),
        [date_update] DATETIME NULL
    );
END
GO

-- Orders Tablosu
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[orders]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[orders] (
        [id] INT PRIMARY KEY IDENTITY(1,1),
        [customerId] VARCHAR(50) NOT NULL,
        [productids] VARCHAR(MAX) NOT NULL,
        [quantities] VARCHAR(MAX) NOT NULL,
        [prices] VARCHAR(MAX) NOT NULL,
        [total] DECIMAL(18,2) NOT NULL,
        [date_order] DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO

-- Tedarikçiler Tablosu
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[suppliers]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[suppliers] (
        [id] INT PRIMARY KEY IDENTITY(1,1),
        [supplier_code] VARCHAR(50) NOT NULL UNIQUE,
        [supplier_name] VARCHAR(255) NOT NULL,
        [contact_person] VARCHAR(255) NULL,
        [phone] VARCHAR(50) NULL,
        [email] VARCHAR(255) NULL,
        [address] VARCHAR(MAX) NULL,
        [status] VARCHAR(20) NOT NULL DEFAULT 'Active',
        [date_created] DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO

-- Depolar Tablosu
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[warehouses]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[warehouses] (
        [id] INT PRIMARY KEY IDENTITY(1,1),
        [warehouse_code] VARCHAR(50) NOT NULL UNIQUE,
        [warehouse_name] VARCHAR(255) NOT NULL,
        [location] VARCHAR(255) NULL,
        [status] VARCHAR(20) NOT NULL DEFAULT 'Active',
        [date_created] DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO

-- Depo Giriş Tablosu
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[warehouse_entries]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[warehouse_entries] (
        [id] INT PRIMARY KEY IDENTITY(1,1),
        [entry_code] VARCHAR(50) NOT NULL UNIQUE,
        [warehouse_id] INT NOT NULL,
        [supplier_id] INT NULL,
        [product_id] INT NOT NULL,
        [quantity] INT NOT NULL,
        [unit_price] DECIMAL(18,2) NULL,
        [total_price] DECIMAL(18,2) NULL,
        [entry_date] DATETIME NOT NULL DEFAULT GETDATE(),
        [notes] VARCHAR(MAX) NULL,
        FOREIGN KEY ([warehouse_id]) REFERENCES [warehouses]([id]),
        FOREIGN KEY ([supplier_id]) REFERENCES [suppliers]([id]),
        FOREIGN KEY ([product_id]) REFERENCES [products]([id])
    );
END
GO

-- Depo Çıkış Tablosu
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[warehouse_exits]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[warehouse_exits] (
        [id] INT PRIMARY KEY IDENTITY(1,1),
        [exit_code] VARCHAR(50) NOT NULL UNIQUE,
        [warehouse_id] INT NOT NULL,
        [product_id] INT NOT NULL,
        [quantity] INT NOT NULL,
        [unit_price] DECIMAL(18,2) NULL,
        [total_price] DECIMAL(18,2) NULL,
        [exit_date] DATETIME NOT NULL DEFAULT GETDATE(),
        [reason] VARCHAR(255) NULL,
        [notes] VARCHAR(MAX) NULL,
        FOREIGN KEY ([warehouse_id]) REFERENCES [warehouses]([id]),
        FOREIGN KEY ([product_id]) REFERENCES [products]([id])
    );
END
GO

-- Index'ler (Performans için)
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_orders_date_order')
BEGIN
    CREATE INDEX IX_orders_date_order ON [orders]([date_order]);
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_products_category')
BEGIN
    CREATE INDEX IX_products_category ON [products]([category]);
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_warehouse_entries_date')
BEGIN
    CREATE INDEX IX_warehouse_entries_date ON [warehouse_entries]([entry_date]);
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_warehouse_exits_date')
BEGIN
    CREATE INDEX IX_warehouse_exits_date ON [warehouse_exits]([exit_date]);
END
GO

PRINT 'Veritabanı ve tablolar başarıyla oluşturuldu!';
GO

