USE [ThietBiDienTu]
GO

INSERT INTO [dbo].[SanPham] 
([TenSP], [GiaTien], [UuDai], [SoLuongTon], [MoTa], [ThongSoKyThuat], [ChinhSachBaoHanh], [ThoiGianBaoHanh], [NgayTao], [TrangThai], [MaHinhAnh], [MaDanhMuc], [MaHang], [SoLuongDaBanRa], [GiaGoc])
VALUES 
('iPhone 14', 999.99, 10, 100, 'Newest iPhone 14 with advanced features', 'A15 Bionic chip, 6.1-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 1099.99),
('iPhone 14 Pro', 1099.99, 15, 50, 'iPhone 14 Pro with Pro features', 'A15 Bionic chip, 6.1-inch display, Pro camera', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 1199.99),
('iPhone 14 Pro Max', 1199.99, 15, 70, 'iPhone 14 Pro Max with larger display', 'A15 Bionic chip, 6.7-inch display, Pro camera', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 1299.99),
('iPhone 13', 799.99, 10, 200, 'iPhone 13 with advanced features', 'A14 Bionic chip, 6.1-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 899.99),
('iPhone 13 Pro', 899.99, 10, 150, 'iPhone 13 Pro with Pro features', 'A14 Bionic chip, 6.1-inch display, Pro camera', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 999.99),
('iPhone 13 Pro Max', 999.99, 10, 120, 'iPhone 13 Pro Max with larger display', 'A14 Bionic chip, 6.7-inch display, Pro camera', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 1099.99),
('iPhone 12', 699.99, 10, 250, 'iPhone 12 with advanced features', 'A13 Bionic chip, 6.1-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 799.99),
('iPhone 12 Pro', 799.99, 10, 180, 'iPhone 12 Pro with Pro features', 'A13 Bionic chip, 6.1-inch display, Pro camera', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 899.99),
('iPhone 12 Pro Max', 899.99, 10, 140, 'iPhone 12 Pro Max with larger display', 'A13 Bionic chip, 6.7-inch display, Pro camera', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 999.99),
('iPhone 11', 599.99, 10, 300, 'iPhone 11 with advanced features', 'A12 Bionic chip, 6.1-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 699.99),
('iPhone 11 Pro', 699.99, 10, 220, 'iPhone 11 Pro with Pro features', 'A12 Bionic chip, 6.1-inch display, Pro camera', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 799.99),
('iPhone 11 Pro Max', 799.99, 10, 160, 'iPhone 11 Pro Max with larger display', 'A12 Bionic chip, 6.7-inch display, Pro camera', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 899.99),
('iPhone XR', 499.99, 10, 350, 'iPhone XR with advanced features', 'A11 Bionic chip, 6.1-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 599.99),
('iPhone XS', 599.99, 10, 200, 'iPhone XS with advanced features', 'A11 Bionic chip, 5.8-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 699.99),
('iPhone XS Max', 699.99, 10, 180, 'iPhone XS Max with larger display', 'A11 Bionic chip, 6.5-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 799.99),
('iPhone X', 599.99, 10, 210, 'iPhone X with advanced features', 'A10 Bionic chip, 5.8-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 699.99),
('iPhone 8', 399.99, 10, 400, 'iPhone 8 with advanced features', 'A9 Bionic chip, 4.7-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 499.99),
('iPhone 8 Plus', 499.99, 10, 300, 'iPhone 8 Plus with larger display', 'A9 Bionic chip, 5.5-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 599.99),
('iPhone 7', 299.99, 10, 500, 'iPhone 7 with advanced features', 'A8 Bionic chip, 4.7-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 399.99),
('iPhone 7 Plus', 399.99, 10, 350, 'iPhone 7 Plus with larger display', 'A8 Bionic chip, 5.5-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 499.99)



USE [ThietBiDienTu]
GO

INSERT INTO [dbo].[SanPham] 
([TenSP], [GiaTien], [UuDai], [SoLuongTon], [MoTa], [ThongSoKyThuat], [ChinhSachBaoHanh], [ThoiGianBaoHanh], [NgayTao], [TrangThai], [MaHinhAnh], [MaDanhMuc], [MaHang], [SoLuongDaBanRa], [GiaGoc])
VALUES 
('Samsung Galaxy S21', 799.99, 10, 100, 'Newest Samsung Galaxy S21 with advanced features', 'Exynos 2100, 6.2-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 899.99),
('Samsung Galaxy S21 Plus', 899.99, 15, 50, 'Samsung Galaxy S21 Plus with larger display', 'Exynos 2100, 6.7-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 999.99),
('Samsung Galaxy S21 Ultra', 1099.99, 20, 70, 'Samsung Galaxy S21 Ultra with top features', 'Exynos 2100, 6.8-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 1199.99),
('Samsung Galaxy S20', 699.99, 10, 200, 'Samsung Galaxy S20 with advanced features', 'Exynos 990, 6.2-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 799.99),
('Samsung Galaxy S20 Plus', 799.99, 15, 150, 'Samsung Galaxy S20 Plus with larger display', 'Exynos 990, 6.7-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 899.99),
('Samsung Galaxy S20 Ultra', 999.99, 20, 120, 'Samsung Galaxy S20 Ultra with top features', 'Exynos 990, 6.9-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 1099.99),
('Samsung Galaxy Note 20', 899.99, 15, 100, 'Samsung Galaxy Note 20 with S-Pen', 'Exynos 990, 6.7-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 999.99),
('Samsung Galaxy Note 20 Ultra', 1099.99, 20, 80, 'Samsung Galaxy Note 20 Ultra with advanced S-Pen features', 'Exynos 990, 6.9-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 1199.99),
('Samsung Galaxy A72', 499.99, 10, 300, 'Samsung Galaxy A72 with quad camera', 'Snapdragon 720G, 6.7-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 599.99),
('Samsung Galaxy A52', 399.99, 10, 250, 'Samsung Galaxy A52 with quad camera', 'Snapdragon 720G, 6.5-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 499.99),
('Samsung Galaxy A32', 299.99, 10, 400, 'Samsung Galaxy A32 with quad camera', 'Mediatek Helio G80, 6.4-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 399.99),
('Samsung Galaxy M51', 349.99, 10, 350, 'Samsung Galaxy M51 with massive battery', 'Snapdragon 730G, 6.7-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 449.99),
('Samsung Galaxy M31', 249.99, 10, 500, 'Samsung Galaxy M31 with quad camera', 'Exynos 9611, 6.4-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 349.99),
('Samsung Galaxy M21', 199.99, 10, 600, 'Samsung Galaxy M21 with triple camera', 'Exynos 9611, 6.4-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 299.99),
('Samsung Galaxy M11', 149.99, 10, 700, 'Samsung Galaxy M11 with triple camera', 'Snapdragon 450, 6.4-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 199.99),
('Samsung Galaxy M01', 99.99, 10, 800, 'Samsung Galaxy M01 with dual camera', 'Snapdragon 439, 5.7-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 149.99),
('Samsung Galaxy Z Fold 2', 1799.99, 25, 30, 'Samsung Galaxy Z Fold 2 with foldable display', 'Snapdragon 865+, 7.6-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 1899.99),
('Samsung Galaxy Z Flip', 1299.99, 20, 40, 'Samsung Galaxy Z Flip with foldable display', 'Snapdragon 855+, 6.7-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 1399.99),
('Samsung Galaxy S10', 599.99, 15, 150, 'Samsung Galaxy S10 with advanced features', 'Exynos 9820, 6.1-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 699.99),
('Samsung Galaxy S10 Plus', 699.99, 15, 120, 'Samsung Galaxy S10 Plus with larger display', 'Exynos 9820, 6.4-inch display', '1-year warranty', 12, GETDATE(), 1, 4, 1, 2, 0, 799.99);
