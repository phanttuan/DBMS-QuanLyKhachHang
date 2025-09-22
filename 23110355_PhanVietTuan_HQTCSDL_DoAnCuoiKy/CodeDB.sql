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
    Gender NVARCHAR(10),
    MembershipTier NVARCHAR(20) NOT NULL DEFAULT N'Đồng',
    CreatedAt DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    UpdatedAt DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT CK_Customer_Gender CHECK (Gender IN (N'Nam', N'Nữ')),
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
    ProductID VARCHAR(10) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    Price DECIMAL(12, 2) NOT NULL,
    IsAvailable BIT NOT NULL DEFAULT 1,
    CONSTRAINT CK_Product_Price CHECK (Price >= 0)
);

CREATE TABLE OrderDetail (
    OrderID INT NOT NULL,
    ProductID VARCHAR(10) NOT NULL,
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

-- Thêm khách hàng
INSERT INTO Customer (FullName, PhoneNumber, Email, DateOfBirth, Gender, CreatedAt, UpdatedAt)
VALUES 
(N'Nguyễn Văn An',      '0901234567', 'an.nguyen@mail.com',     '1990-05-15', N'Nam', '2025-07-01', '2025-07-01'),
(N'Trần Thị Bình',      '0912345678', 'binh.tran@mail.com',     '1985-08-22', N'Nữ', '2025-07-04', '2025-07-04'),
(N'Lê Hoài Cường',      '0923456789', 'cuong.le@mail.com',      '1992-12-03', N'Nam', '2025-07-07', '2025-07-07'),
(N'Phạm Thị Dung',      '0934567890', 'dung.pham@mail.com',     '1988-06-18', N'Nữ', '2025-07-10', '2025-07-10'),
(N'Hoàng Văn Em',       '0945678901', 'em.hoang@mail.com',      '1995-02-14', N'Nam', '2025-07-13', '2025-07-13'),
(N'Nguyễn Thị Phương',  '0956789012', 'phuong.nguyen@mail.com', '1987-09-25', N'Nữ', '2025-07-16', '2025-07-16'),
(N'Trần Văn Giang',     '0967890123', 'giang.tran@mail.com',    '1993-11-07', N'Nam', '2025-07-19', '2025-07-19'),
(N'Lê Thị Hoa',         '0978901234', 'hoa.le@mail.com',        '1990-04-12', N'Nữ', '2025-07-22', '2025-07-22'),
(N'Phạm Văn Ích',       '0989012345', 'ich.pham@mail.com',      '1986-01-30', N'Nam', '2025-07-25', '2025-07-25'),
(N'Hoàng Thị Khánh',    '0990123456', 'khanh.hoang@mail.com',   '1991-07-19', N'Nữ', '2025-07-28', '2025-07-28'),
(N'Nguyễn Văn Long',    '0901111111', 'long.nguyen@mail.com',   '1989-03-08', N'Nam', '2025-08-01', '2025-08-01'),
(N'Trần Thị Mai',       '0902222222', 'mai.tran@mail.com',      '1994-10-16', N'Nữ', '2025-08-04', '2025-08-04'),
(N'Lê Văn Nam',         '0903333333', 'nam.le@mail.com',        '1987-12-25', N'Nam', '2025-08-07', '2025-08-07'),
(N'Phạm Thị Oanh',      '0904444444', 'oanh.pham@mail.com',     '1992-05-30', N'Nữ', '2025-08-10', '2025-08-10'),
(N'Hoàng Văn Phúc',     '0905555555', 'phuc.hoang@mail.com',    '1988-08-14', N'Nam', '2025-08-13', '2025-08-13');

-- Thêm sản phẩm
INSERT INTO Product (ProductID, ProductName, [Description], Price, IsAvailable)
VALUES
(N'CF01', N'Cà phê đen đá',       N'Cà phê robusta rang xay truyền thống, uống với đá', 25000.00, 1),
(N'CF02', N'Cà phê sữa đá',       N'Cà phê đen kết hợp với sữa đặc, uống với đá', 30000.00, 1),
(N'CF03', N'Bạc xỉu',             N'Cà phê sữa với nhiều sữa, ít cà phê', 35000.00, 1),
(N'CF04', N'Cappuccino',          N'Cà phê espresso với foam sữa mịn', 45000.00, 1),
(N'CF05', N'Americano',           N'Espresso pha loãng với nước nóng', 40000.00, 1),
(N'CF06', N'Latte',               N'Espresso với nhiều sữa nóng và ít foam', 50000.00, 1),
(N'CF07', N'Mocha',               N'Cà phê kết hợp với chocolate và sữa', 55000.00, 1),
(N'CF08', N'Cà phê cốt dừa',      N'Cà phê với nước cốt dừa thơm béo', 40000.00, 1),
(N'CF09', N'Espresso',            N'Cà phê espresso nguyên chất đậm đà', 35000.00, 1),
(N'CF10', N'Cà phê phin',         N'Cà phê phin truyền thống Việt Nam', 28000.00, 1),
(N'TR01', N'Trà đá',              N'Trà truyền thống pha với đá', 15000.00, 1),
(N'TR02', N'Trà sữa truyền thống',N'Trà đen kết hợp với sữa tươi', 35000.00, 1),
(N'TR03', N'Trà sữa trân châu',   N'Trà sữa với trân châu đen dai ngon', 40000.00, 1),
(N'TR04', N'Trà xanh',            N'Trà xanh thơm mát', 20000.00, 1),
(N'TR05', N'Trà ô long',          N'Trà ô long thảo mộc', 25000.00, 1),
(N'TR06', N'Trà gừng mật ong',    N'Trà gừng ấm với mật ong ngọt ngào', 30000.00, 1),
(N'TR07', N'Trà chanh',           N'Trà đen với chanh tươi', 25000.00, 1),
(N'TR08', N'Trà sen',             N'Trà sen thơm dịu', 35000.00, 1),
(N'TR09', N'Trà atiso',           N'Trà atiso thanh mát', 28000.00, 1),
(N'JU01', N'Nước ép cam',         N'Cam tươi vắt nguyên chất', 35000.00, 1),
(N'JU02', N'Nước ép dứa',         N'Dứa tươi xay với đá', 30000.00, 1),
(N'JU03', N'Nước ép táo',         N'Táo tươi xay nhuyễn', 40000.00, 1),
(N'JU04', N'Sinh tố bơ',          N'Bơ xay với sữa tươi', 45000.00, 1),
(N'JU05', N'Sinh tố mango',       N'Xoài chín xay với đá', 42000.00, 1),
(N'JU06', N'Nước chanh đá',       N'Chanh tươi với đường', 20000.00, 1),
(N'JU07', N'Sinh tố dâu',         N'Dâu tây tươi xay với sữa', 48000.00, 1),
(N'JU08', N'Nước ép dưa hấu',     N'Dưa hấu tươi mát', 25000.00, 1),
(N'JU09', N'Sinh tố chuối',       N'Chuối chín xay với sữa đặc', 35000.00, 1),
(N'CK01', N'Bánh tiramisu',       N'Bánh tiramisu Ý truyền thống', 65000.00, 1),
(N'CK02', N'Bánh flan',           N'Bánh flan caramen mềm mịn', 35000.00, 1),
(N'CK03', N'Bánh cheese cake',    N'Bánh phô mai New York style', 70000.00, 1),
(N'CK04', N'Bánh su kem',         N'Bánh su nhân kem tươi', 25000.00, 1),
(N'CK05', N'Bánh macaron',        N'Set 6 bánh macaron nhiều màu', 80000.00, 1),
(N'CK06', N'Bánh croissant',      N'Bánh sừng bò bơ thơm', 30000.00, 1),
(N'CK07', N'Bánh muffin chocolate',N'Bánh nướng nhỏ với chocolate chip', 35000.00, 1),
(N'CK08', N'Bánh bông lan',       N'Bánh bông lan mềm xốp', 20000.00, 1),
(N'CK09', N'Bánh cupcake',        N'Bánh cupcake kem bơ', 28000.00, 1),
(N'BM01', N'Bánh mì thịt nướng',  N'Bánh mì với thịt nướng và rau', 45000.00, 1),
(N'BM02', N'Sandwich gà',         N'Sandwich với gà nướng và salad', 50000.00, 1),
(N'BM03', N'Pizza mini',          N'Pizza nhỏ với nhiều topping', 60000.00, 1),
(N'BM04', N'Hamburger',           N'Hamburger bò với khoai tây', 65000.00, 1),
(N'BM05', N'Hotdog',              N'Hotdog xúc xích với sốt', 40000.00, 1),
(N'BM06', N'Bánh tráng nướng',    N'Bánh tráng nướng đặc sản', 25000.00, 1),
(N'BM07', N'Xúc xích nướng',      N'Xúc xích nướng than hoa', 35000.00, 1),
(N'BM08', N'Bánh mì pate',        N'Bánh mì pate truyền thống', 30000.00, 1),
(N'DU01', N'Nước suối',           N'Nước suối tinh khiết', 10000.00, 1),
(N'DU02', N'Coca Cola',           N'Nước ngọt có gas', 15000.00, 1),
(N'DU03', N'Sprite',              N'Nước ngọt vị chanh', 15000.00, 1),
(N'DU04', N'Trà xanh không độ',   N'Trà xanh 0 đường', 18000.00, 1),
(N'DU05', N'Redbull',             N'Nước tăng lực', 25000.00, 0),
(N'DU06', N'Sting',               N'Nước tăng lực vị dâu', 20000.00, 1),
(N'DU07', N'Pepsi',               N'Nước ngọt có gas', 15000.00, 1),
(N'DU08', N'7Up',                 N'Nước ngọt không caffeine', 15000.00, 1);

-- Thêm đơn hàng
INSERT INTO [Order] (CustomerID, TotalAmount, PaymentStatus, OrderStatus, OrderDate)
VALUES 
(1, 80000.00, 'Paid', 'Completed', '2025-07-01 08:30:00'),
(2, 45000.00, 'Paid', 'Completed', '2025-07-04 09:15:00'),
(3, 150000.00, 'Paid', 'Completed', '2025-07-07 10:20:00'),
(4, 95000.00, 'Paid', 'Completed', '2025-07-10 11:45:00'),
(5, 70000.00, 'Unpaid', 'Pending', '2025-07-13 14:30:00'),
(6, 110000.00, 'Paid', 'Completed', '2025-07-16 16:20:00'),
(7, 85000.00, 'Paid', 'Completed', '2025-07-19 08:45:00'),
(8, 130000.00, 'Paid', 'Completed', '2025-07-22 12:30:00'),
(9, 45000.00, 'Unpaid', 'Pending', '2025-07-25 15:45:00'),
(10, 115000.00, 'Paid', 'Completed', '2025-07-28 10:15:00'),
(11, 160000.00, 'Unpaid', 'Canceled', '2025-08-04 14:20:00'),
(12, 55000.00, 'Paid', 'Completed', '2025-08-07 09:30:00'),
(13, 90000.00, 'Paid', 'Completed', '2025-08-10 13:45:00'),
(14, 75000.00, 'Unpaid', 'Pending', '2025-08-13 16:30:00'),
(15, 120000.00, 'Paid', 'Completed', '2025-08-13 10:15:00'),
-- Đơn nâng hạng Silver cho khách 2
(2, 2155000.00, 'Paid', 'Completed', '2025-08-15 08:00:00'),
-- Đơn nâng hạng Gold cho khách 5
(5, 5000000.00, 'Paid', 'Completed', '2025-08-17 08:00:00');

-- Thêm chi tiết đơn hàng
INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice) VALUES 
(1, N'CF04', 1, 45000.00),
(1, N'CK01', 1, 65000.00),

(2, N'CF04', 1, 45000.00),

(3, N'CF01', 2, 25000.00),
(3, N'JU04', 1, 45000.00),
(3, N'CK03', 1, 70000.00),
(3, N'BM02', 1, 50000.00),

(4, N'TR03', 2, 40000.00),
(4, N'CK02', 1, 35000.00),

(5, N'CF06', 1, 50000.00),
(5, N'CK04', 1, 25000.00),

(6, N'TR02', 2, 35000.00),
(6, N'JU01', 1, 35000.00),
(6, N'DU02', 1, 15000.00),

(7, N'CF07', 1, 55000.00),
(7, N'BM06', 1, 25000.00),
(7, N'DU01', 1, 10000.00),

(8, N'CF05', 2, 40000.00),
(8, N'BM03', 1, 60000.00),

(9, N'CF02', 1, 30000.00),
(9, N'TR01', 1, 15000.00),

(10, N'CF08', 1, 40000.00),
(10, N'JU05', 1, 42000.00),
(10, N'BM04', 1, 65000.00),

(11, N'CF01', 1, 25000.00),

(12, N'CF03', 2, 35000.00),
(12, N'CK05', 1, 80000.00),
(12, N'BM05', 1, 40000.00),

(13, N'CF05', 1, 40000.00),
(13, N'JU02', 1, 30000.00),

(14, N'TR05', 1, 25000.00),
(14, N'CK06', 1, 30000.00),

(15, N'CF06', 1, 50000.00),
(15, N'JU03', 1, 40000.00),

-- Đơn nâng hạng Silver cho khách 2 (OrderID=16)
(16, N'CK03', 31, 69500.00), -- 31 bánh cheese cake x 69,500 = 2,155,000

-- Đơn nâng hạng Gold cho khách 5 (OrderID=17)
(17, N'CF03', 100, 50000.00); -- 100 bạc xỉu x 50,000 = 5,000,000


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

ALTER ROLE roleQuanLyKhachHang ADD MEMBER qlkh;
ALTER ROLE roleThongKe ADD MEMBER qltk;

GRANT EXECUTE ON OBJECT::dbo.sp_PhanQuyenTaiKhoan TO qltk;
GRANT EXECUTE ON OBJECT::dbo.sp_PhanQuyenTaiKhoan TO roleThongKe;

GRANT EXECUTE ON OBJECT::dbo.sp_PhanQuyenTaiKhoan TO qlkh;
GRANT EXECUTE ON OBJECT::dbo.sp_PhanQuyenTaiKhoan TO roleQuanLyKhachHang;
GO