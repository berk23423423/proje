-- Test Verileri Ekleme Scripti
-- Bu script'i SSMS'de çalıştırarak test verileri ekleyebilirsiniz

USE yemekhanemenusıstemı;
GO

-- Kategoriler Ekle
IF NOT EXISTS (SELECT * FROM categories WHERE category = 'Ana Yemekler')
BEGIN
    INSERT INTO categories (category, status) VALUES ('Ana Yemekler', 'Active');
END

IF NOT EXISTS (SELECT * FROM categories WHERE category = 'Tatlılar')
BEGIN
    INSERT INTO categories (category, status) VALUES ('Tatlılar', 'Active');
END

IF NOT EXISTS (SELECT * FROM categories WHERE category = 'İçecekler')
BEGIN
    INSERT INTO categories (category, status) VALUES ('İçecekler', 'Active');
END
GO

-- Ürünler Ekle
IF NOT EXISTS (SELECT * FROM products WHERE productid = 'PROD-001')
BEGIN
    INSERT INTO products (productid, productname, category, stock, price, status)
    VALUES ('PROD-001', 'Köfte', 'Ana Yemekler', 100, 45.00, 'Available');
END

IF NOT EXISTS (SELECT * FROM products WHERE productid = 'PROD-002')
BEGIN
    INSERT INTO products (productid, productname, category, stock, price, status)
    VALUES ('PROD-002', 'Döner', 'Ana Yemekler', 80, 50.00, 'Available');
END

IF NOT EXISTS (SELECT * FROM products WHERE productid = 'PROD-003')
BEGIN
    INSERT INTO products (productid, productname, category, stock, price, status)
    VALUES ('PROD-003', 'Baklava', 'Tatlılar', 50, 35.00, 'Available');
END

IF NOT EXISTS (SELECT * FROM products WHERE productid = 'PROD-004')
BEGIN
    INSERT INTO products (productid, productname, category, stock, price, status)
    VALUES ('PROD-004', 'Kola', 'İçecekler', 200, 10.00, 'Available');
END
GO

-- Tedarikçi Ekle
IF NOT EXISTS (SELECT * FROM suppliers WHERE supplier_code = 'SUP-001')
BEGIN
    INSERT INTO suppliers (supplier_code, supplier_name, contact_person, phone, email, address)
    VALUES ('SUP-001', 'Örnek Tedarikçi', 'Ahmet Yılmaz', '05551234567', 'ornek@tedarikci.com', 'İstanbul');
END
GO

-- Depo Ekle
IF NOT EXISTS (SELECT * FROM warehouses WHERE warehouse_code = 'WH-001')
BEGIN
    INSERT INTO warehouses (warehouse_code, warehouse_name, location)
    VALUES ('WH-001', 'Ana Depo', 'İstanbul');
END
GO

PRINT 'Test verileri başarıyla eklendi!';
GO

