CREATE DATABASE QuanLyKhachHangDb;
GO
USE QuanLyKhachHangDb;
GO

CREATE TABLE Customer (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    PhoneNumber VARCHAR(12) NOT NULL UNIQUE,
    Email VARCHAR(100) UNIQUE,
    DateOfBirth DATE,
    Gender NVARCHAR(10) NOT NULL,
    MembershipTier NVARCHAR(20) NOT NULL DEFAULT N'Đồng',
    CreatedAt DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    UpdatedAt DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT CK_Customer_Gender CHECK (Gender IN (N'Nam', N'Nữ')),
    CONSTRAINT CK_Customer_DateOfBirth CHECK (DateOfBirth <= CAST(SYSDATETIME() AS DATE)),
    CONSTRAINT CK_Customer_MembershipTier CHECK (MembershipTier IN (N'Đồng', N'Bạc', N'Vàng', N'Kim cương'))
);

CREATE TABLE [Order] (
    OrderID INT IDENTITY PRIMARY KEY,
    OrderDate DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    CustomerID INT NULL,
    TotalAmount DECIMAL(14, 2) NOT NULL,
    PaymentStatus VARCHAR(20) NOT NULL DEFAULT 'Unpaid',
    OrderStatus VARCHAR(20) NOT NULL DEFAULT 'Pending',
    CONSTRAINT FK_Order_Customer FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    CONSTRAINT CK_Order_TotalAmount CHECK (TotalAmount >= 0),
    CONSTRAINT CK_Order_PaymentStatus CHECK (PaymentStatus IN ('Unpaid', 'Paid', 'Partially Paid')),
    CONSTRAINT CK_Order_OrderStatus CHECK (OrderStatus IN ('Pending', 'Completed', 'Canceled'))
);

CREATE TABLE Product (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    Price DECIMAL(12, 2) NOT NULL,
    IsAvailable BIT NOT NULL DEFAULT 1,
    CONSTRAINT CK_Product_Price CHECK (Price >= 0)
);

CREATE TABLE OrderDetail (
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(12, 2) NOT NULL,
    CONSTRAINT PK_OrderDetail PRIMARY KEY (OrderID, ProductID),
    CONSTRAINT FK_OrderDetail_Order FOREIGN KEY (OrderID) REFERENCES [Order](OrderID) ON DELETE CASCADE,
    CONSTRAINT FK_OrderDetail_Product FOREIGN KEY (ProductID) REFERENCES Product(ProductID),
    CONSTRAINT CK_OrderDetail_Quantity CHECK (Quantity > 0),
    CONSTRAINT CK_OrderDetail_UnitPrice CHECK (UnitPrice >= 0)
);

-- Xóa dữ liệu cũ
DELETE FROM OrderDetail;
DELETE FROM [Order];
DELETE FROM Product;
DELETE FROM Customer;
DBCC CHECKIDENT('Customer', RESEED, 0);
DBCC CHECKIDENT('[Order]', RESEED, 0);
DBCC CHECKIDENT('Product', RESEED, 0);

INSERT INTO Customer (FullName, PhoneNumber, Email, DateOfBirth, Gender, MembershipTier, CreatedAt, UpdatedAt) VALUES
(N'Nguyễn Văn An', '0901234567', 'an.nguyen@gmail.com', '1990-05-15', N'Nam', N'Đồng', '2025-06-01', '2025-06-01'),
(N'Trần Thị Bình', '0912345678', 'binh.tran@gmail.com', '1992-08-20', N'Nữ', N'Đồng', '2025-06-03', '2025-06-03'),
(N'Lê Hoài Cường', '0923456789', 'cuong.le@gmail.com', '1988-12-30', N'Nam', N'Đồng', '2025-06-05', '2025-06-05'),
(N'Phạm Thị Dung', '0934567890', 'dung.pham@gmail.com', '1995-01-05', N'Nữ', N'Bạc', '2025-06-07', '2025-06-07'),
(N'Hoàng Văn Em', '0945678901', 'em.hoang@gmail.com', '1993-07-10', N'Nam', N'Bạc', '2025-06-09', '2025-06-09'),
(N'Nguyễn Thị Phương', '0956789012', 'phuong.nguyen@gmail.com', '1991-03-25', N'Nữ', N'Vàng', '2025-06-11', '2025-06-11'),
(N'Trần Văn Giang', '0967890123', 'giang.tran@gmail.com', '1994-09-14', N'Nam', N'Vàng', '2025-06-13', '2025-06-13'),
(N'Lê Thị Hoa', '0978901234', 'hoa.le@gmail.com', '1996-06-18', N'Nữ', N'Kim cương', '2025-06-15', '2025-06-15'),
(N'Phạm Văn Ích', '0989012345', 'ich.pham@gmail.com', '1989-11-22', N'Nam', N'Kim cương', '2025-06-17', '2025-06-17'),
(N'Hoàng Thị Khánh', '0990123456', 'khanh.hoang@gmail.com', '1990-02-28', N'Nữ', N'Đồng', '2025-06-19', '2025-06-19'),
(N'Nguyễn Văn Long', '0901111111', 'long.nguyen@gmail.com', '1992-04-30', N'Nam', N'Đồng', '2025-06-21', '2025-06-21'),
(N'Trần Thị Mai', '0902222222', 'mai.tran@gmail.com', '1995-10-12', N'Nữ', N'Đồng', '2025-06-23', '2025-06-23'),
(N'Lê Văn Nam', '0903333333', 'nam.le@gmail.com', '1987-12-01', N'Nam', N'Đồng', '2025-06-25', '2025-06-25'),
(N'Phạm Thị Oanh', '0904444444', 'oanh.pham@gmail.com', '1993-05-27', N'Nữ', N'Đồng', '2025-06-27', '2025-06-27'),
(N'Hoàng Văn Phúc', '0905555555', 'phuc.hoang@gmail.com', '1996-08-05', N'Nam', N'Đồng', '2025-06-29', '2025-06-29');-- Thêm Products (50 sản phẩm, ProductID sẽ tự tăng từ 1 đến 50)

INSERT INTO Product (ProductName, [Description], Price, IsAvailable) VALUES
(N'Cà phê đen đá', N'Cà phê robusta rang xay truyền thống, uống với đá', 25000, 1),
(N'Cà phê sữa đá', N'Cà phê đen kết hợp với sữa đặc, uống với đá', 30000, 1),
(N'Bạc xỉu', N'Cà phê sữa với nhiều sữa, ít cà phê', 35000, 1),
(N'Cappuccino', N'Cà phê espresso với foam sữa mịn', 45000, 1),
(N'Americano', N'Espresso pha loãng với nước nóng', 40000, 1),
(N'Latte', N'Espresso với nhiều sữa nóng và ít foam', 50000, 1),
(N'Mocha', N'Cà phê kết hợp với chocolate và sữa', 55000, 1),
(N'Cà phê cốt dừa', N'Cà phê với nước cốt dừa thơm béo', 40000, 1),
(N'Espresso', N'Cà phê espresso nguyên chất đậm đà', 35000, 1),
(N'Cà phê phin', N'Cà phê phin truyền thống Việt Nam', 28000, 1),
(N'Trà đá', N'Trà truyền thống pha với đá', 15000, 1),
(N'Trà sữa truyền thống', N'Trà đen kết hợp với sữa tươi', 35000, 1),
(N'Trà sữa trân châu', N'Trà sữa với trân châu đen dai ngon', 40000, 1),
(N'Trà xanh', N'Trà xanh thơm mát', 20000, 1),
(N'Trà ô long', N'Trà ô long thảo mộc', 25000, 1),
(N'Trà gừng mật ong', N'Trà gừng ấm với mật ong ngọt ngào', 30000, 1),
(N'Trà chanh', N'Trà đen với chanh tươi', 25000, 1),
(N'Trà sen', N'Trà sen thơm dịu', 35000, 1),
(N'Trà atiso', N'Trà atiso thanh mát', 28000, 1),
(N'Nước ép cam', N'Cam tươi vắt nguyên chất', 35000, 1),
(N'Nước ép dứa', N'Dứa tươi xay với đá', 30000, 1),
(N'Nước ép táo', N'Táo tươi xay nhuyễn', 40000, 1),
(N'Sinh tố bơ', N'Bơ xay với sữa tươi', 45000, 1),
(N'Sinh tố mango', N'Xoài chín xay với đá', 42000, 1),
(N'Nước chanh đá', N'Chanh tươi với đường', 20000, 1),
(N'Sinh tố dâu', N'Dâu tây tươi xay với sữa', 48000, 1),
(N'Nước ép dưa hấu', N'Dưa hấu tươi mát', 25000, 1),
(N'Sinh tố chuối', N'Chuối chín xay với sữa đặc', 35000, 1),
(N'Bánh tiramisu', N'Bánh tiramisu Ý truyền thống', 65000, 1),
(N'Bánh flan', N'Bánh flan caramen mềm mịn', 35000, 1),
(N'Bánh cheese cake', N'Bánh phô mai New York style', 70000, 1),
(N'Bánh su kem', N'Bánh su nhân kem tươi', 25000, 1),
(N'Bánh macaron', N'Set 6 bánh macaron nhiều màu', 80000, 1),
(N'Bánh croissant', N'Bánh sừng bò bơ thơm', 30000, 1),
(N'Bánh muffin chocolate', N'Bánh nướng nhỏ với chocolate chip', 35000, 1),
(N'Bánh bông lan', N'Bánh bông lan mềm xốp', 20000, 1),
(N'Bánh cupcake', N'Bánh cupcake kem bơ', 28000, 1),
(N'Bánh mì thịt nướng', N'Bánh mì với thịt nướng và rau', 45000, 1),
(N'Sandwich gà', N'Sandwich với gà nướng và salad', 50000, 1),
(N'Pizza mini', N'Pizza nhỏ với nhiều topping', 60000, 1),
(N'Hamburger', N'Hamburger bò với khoai tây', 65000, 1),
(N'Hotdog', N'Hotdog xúc xích với sốt', 40000, 1),
(N'Bánh tráng nướng', N'Bánh tráng nướng đặc sản', 25000, 1),
(N'Xúc xích nướng', N'Xúc xích nướng than hoa', 35000, 1),
(N'Bánh mì pate', N'Bánh mì pate truyền thống', 30000, 1),
(N'Nước suối', N'Nước suối tinh khiết', 10000, 1),
(N'Coca Cola', N'Nước ngọt có gas', 15000, 1),
(N'Sprite', N'Nước ngọt vị chanh', 15000, 1),
(N'Trà xanh không độ', N'Trà xanh 0 đường', 18000, 1),
(N'Redbull', N'Nước tăng lực', 25000, 0),
(N'Sting', N'Nước tăng lực vị dâu', 20000, 1),
(N'Pepsi', N'Nước ngọt có gas', 15000, 1),
(N'7Up', N'Nước ngọt không caffeine', 15000, 1);

-- Thêm Orders 
INSERT INTO [Order] (CustomerID, TotalAmount, PaymentStatus, OrderStatus, OrderDate) VALUES
(1, 80000.00, 'Paid', 'Completed', '2025-09-01 08:30:00'),
(2, 45000.00, 'Paid', 'Completed', '2025-09-01 09:15:00'),
(3, 150000.00, 'Paid', 'Completed', '2025-09-02 10:20:00'),
(4, 95000.00, 'Paid', 'Completed', '2025-09-02 11:45:00'),
(5, 70000.00, 'Unpaid', 'Pending', '2025-09-20 14:30:00'),
(6, 110000.00, 'Paid', 'Completed', '2025-09-18 16:20:00'),
(7, 85000.00, 'Paid', 'Completed', '2025-09-19 08:45:00'),
(8, 130000.00, 'Paid', 'Completed', '2025-09-19 12:30:00'),
(9, 45000.00, 'Unpaid', 'Pending', '2025-09-20 15:45:00'),
(10, 115000.00, 'Paid', 'Completed', '2025-09-20 10:15:00'),
(11, 160000.00, 'Paid', 'Canceled', '2025-09-15 14:20:00'),
(12, 55000.00, 'Paid', 'Completed', '2025-09-16 09:30:00'),
(13, 90000.00, 'Paid', 'Completed', '2025-09-17 13:45:00'),
(14, 75000.00, 'Unpaid', 'Pending', '2025-09-20 16:30:00'),
(15, 120000.00, 'Paid', 'Completed', '2025-09-18 10:15:00');

-- Thêm OrderDetail 
INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice) VALUES
(1, 4, 1, 45000.00), -- Cappuccino
(1, 29, 1, 65000.00), -- Bánh tiramisu
(2, 4, 1, 45000.00), -- Cappuccino
(3, 1, 2, 25000.00), -- Cà phê đen đá x2
(3, 24, 1, 45000.00), -- Sinh tố bơ
(3, 31, 1, 70000.00), -- Cheese cake
(3, 37, 1, 50000.00), -- Sandwich gà
(4, 13, 2, 40000.00), -- Trà sữa trân châu x2
(4, 30, 1, 35000.00), -- Bánh flan
(5, 6, 1, 50000.00), -- Latte
(5, 32, 1, 25000.00), -- Bánh su kem
(6, 12, 2, 35000.00), -- Trà sữa truyền thống x2
(6, 21, 1, 35000.00), -- Nước ép cam
(6, 45, 1, 15000.00), -- Coca Cola
(7, 7, 1, 55000.00), -- Mocha
(7, 42, 1, 25000.00), -- Bánh tráng nướng
(7, 44, 1, 10000.00), -- Nước suối
(8, 5, 2, 40000.00), -- Americano x2
(8, 39, 1, 60000.00), -- Pizza mini
(9, 2, 1, 30000.00), -- Cà phê sữa đá
(9, 11, 1, 15000.00), -- Trà đá
(10, 8, 1, 40000.00), -- Cà phê cốt dừa
(10, 25, 1, 42000.00), -- Sinh tố mango
(10, 41, 1, 65000.00), -- Hamburger
(11, 1, 1, 25000.00), -- Cà phê đen đá
(12, 3, 2, 35000.00), -- Bạc xỉu x2
(12, 33, 1, 80000.00), -- Macaron
(12, 40, 1, 40000.00), -- Hotdog
(13, 5, 1, 40000.00), -- Americano
(13, 22, 1, 30000.00), -- Nước ép dứa
(14, 15, 1, 25000.00), -- Trà ô long
(14, 34, 1, 30000.00), -- Croissant
(15, 6, 1, 50000.00), -- Latte
(15, 23, 1, 40000.00); -- Nước ép táo

-- Đơn cho khách 2
INSERT INTO [Order] (CustomerID, TotalAmount, PaymentStatus, OrderStatus, OrderDate)
VALUES (2, 2170000, 'Paid', 'Completed', '2025-09-22 10:30:00');
INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice)
VALUES (SCOPE_IDENTITY(), 31, 31, 70000.00);

-- Đơn cho khách 5
INSERT INTO [Order] (CustomerID, TotalAmount, PaymentStatus, OrderStatus, OrderDate)
VALUES (5, 3500000, 'Paid', 'Completed', '2025-09-22 10:45:00');
INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice)
VALUES (SCOPE_IDENTITY(), 3, 100, 35000.00);

-- Phân quyền
USE QuanLyKhachHangDb;
IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'qlkh') DROP USER qlkh;
IF EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'qltk') DROP USER qltk;
GO

USE master;
IF EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'nhanvienqlkh') DROP LOGIN nhanvienqlkh;
IF EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'nhanvienqltk') DROP LOGIN nhanvienqltk;
GO

CREATE LOGIN nhanvienqlkh WITH PASSWORD='123@123';
CREATE LOGIN nhanvienqltk WITH PASSWORD='456@456';
ALTER LOGIN nhanvienqlkh WITH DEFAULT_DATABASE=QuanLyKhachHangDb;
ALTER LOGIN nhanvienqltk WITH DEFAULT_DATABASE=QuanLyKhachHangDb;
GO
USE QuanLyKhachHangDb;
CREATE USER qlkh FOR LOGIN nhanvienqlkh;
CREATE USER qltk FOR LOGIN nhanvienqltk;
GO

CREATE ROLE roleQuanLyKhachHang;
CREATE ROLE roleThongKe;
GO

GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.Customer TO roleQuanLyKhachHang;
GRANT EXECUTE ON OBJECT::dbo.sp_HienThiThongTinKhachHang TO roleQuanLyKhachHang;
GRANT EXECUTE ON OBJECT::dbo.sp_ThemKhachHang TO roleQuanLyKhachHang;
GRANT EXECUTE ON OBJECT::dbo.sp_SuaKhachHang TO roleQuanLyKhachHang;
GRANT EXECUTE ON OBJECT::dbo.sp_XoaKhachHang TO roleQuanLyKhachHang;

GRANT SELECT ON dbo.Customer TO roleThongKe;
GRANT SELECT ON dbo.[Order] TO roleThongKe;
GRANT SELECT ON dbo.OrderDetail TO roleThongKe;
GRANT SELECT ON dbo.Product TO roleThongKe;

GRANT INSERT, UPDATE, DELETE ON dbo.[Order]     TO roleThongKe;
GRANT INSERT, UPDATE, DELETE ON dbo.OrderDetail TO roleThongKe;
GRANT INSERT, UPDATE, DELETE ON dbo.Product     TO roleThongKe;

DENY INSERT, UPDATE, DELETE ON dbo.Customer TO roleThongKe;

GRANT EXECUTE ON OBJECT::dbo.sp_HienThiTanSuatChiTieu  TO roleThongKe;
GRANT EXECUTE ON OBJECT::dbo.sp_HienThiTongChiTieu     TO roleThongKe;
GRANT EXECUTE ON OBJECT::dbo.sp_LichSuMuaHang          TO roleThongKe;
GRANT EXECUTE ON OBJECT::dbo.sp_HienThiThongTinKhachHang TO roleThongKe;

DENY EXECUTE ON OBJECT::dbo.sp_ThemKhachHang TO roleThongKe;
DENY EXECUTE ON OBJECT::dbo.sp_SuaKhachHang  TO roleThongKe;
DENY EXECUTE ON OBJECT::dbo.sp_XoaKhachHang  TO roleThongKe;

GRANT SELECT  ON OBJECT::dbo.fn_ThongKeKhachChiTieuTheoQuy   TO roleThongKe;
GRANT SELECT  ON OBJECT::dbo.fn_ThongKeKhachMoiTheoQuy       TO roleThongKe;
GRANT SELECT  ON OBJECT::dbo.fn_ThongKeKhachNgungMua         TO roleThongKe;
GRANT SELECT  ON OBJECT::dbo.fn_ThongKeTanSuatChiTieuTheoQuy TO roleThongKe;
GRANT EXECUTE ON OBJECT::dbo.fn_TinhTongChiTieuMotKhach      TO roleThongKe;

GRANT EXECUTE ON OBJECT::dbo.sp_PhanQuyenTaiKhoan TO qltk;
GRANT EXECUTE ON OBJECT::dbo.sp_PhanQuyenTaiKhoan TO roleThongKe;

GRANT EXECUTE ON OBJECT::dbo.sp_PhanQuyenTaiKhoan TO qlkh;
GRANT EXECUTE ON OBJECT::dbo.sp_PhanQuyenTaiKhoan TO roleQuanLyKhachHang;
GO