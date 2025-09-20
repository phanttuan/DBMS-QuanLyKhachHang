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
    Gender VARCHAR(10),
    MembershipTier VARCHAR(10) NOT NULL DEFAULT 'Bronze',
    CreatedAt DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    UpdatedAt DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT CK_Customer_Gender CHECK (Gender IN ('M', 'F', 'Other')),
    CONSTRAINT CK_Customer_MembershipTier CHECK (MembershipTier IN ('Bronze', 'Silver', 'Gold', 'VIP'))
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

-- Thêm khách hàng (10 khách) với trường CreatedAt (ngày sinh)
INSERT INTO Customer (FullName, PhoneNumber, Email, DateOfBirth, Gender, MembershipTier, CreatedAt)
VALUES 
(N'Nguyễn Thị Mai',      '0901000001', 'mai.nguyen@gmail.com',     '1990-02-01', 'F', 'Bronze', '2025-01-01'),
(N'Lê Văn Nam',          '0901000002', 'nam.le@gmail.com',         '1985-05-12', 'M', 'Bronze', '2025-01-12'),
(N'Phạm Thị Hoa',        '0901000003', 'hoa.pham@gmail.com',       '1998-08-20', 'F', 'Bronze', '2025-01-20'),
(N'Trần Minh Tuấn',      '0901000004', 'tuan.tran@gmail.com',      '1975-11-22', 'M', 'Bronze', '2025-01-22'),
(N'Bùi Anh Dũng',        '0901000005', 'dung.bui@gmail.com',       '1992-03-30', 'M', 'Bronze', '2025-01-30'),
(N'Võ Thị Hồng',         '0901000006', 'hong.vo@gmail.com',        '1999-07-08', 'F', 'Bronze', '2025-01-08'),
(N'Ngô Quang Huy',       '0901000007', 'huy.ngo@gmail.com',        '1991-10-17', 'M', 'Bronze', '2025-01-17'),
(N'Hồ Thị Thanh',        '0901000008', 'thanh.ho@gmail.com',       '1987-06-25', 'F', 'Bronze', '2025-01-25'),
(N'Đỗ Văn Khoa',         '0901000009', 'khoa.do@gmail.com',        '1996-04-19', 'M', 'Bronze', '2025-01-19'),
(N'Phan Thị Cẩm',        '0901000010', 'cam.phan@gmail.com',       '2001-09-15', 'F', 'Bronze', '2025-01-15');

-- Thêm sản phẩm (12 sản phẩm)
INSERT INTO Product (ProductID, ProductName, [Description], Price, IsAvailable)
VALUES
('CF01', N'Cà phê đen',         N'Cà phê rang xay truyền thống',          25000, 1),
('CF02', N'Cà phê sữa',         N'Cà phê pha với sữa đặc',                28000, 1),
('CF03', N'Cà phê muối',        N'Cà phê, sữa, muối',                     32000, 1),
('TEA01', N'Trà đào',           N'Trà đào tươi mát lạnh',                 35000, 1),
('TEA02', N'Trà chanh',         N'Trà chanh nguyên chất',                 30000, 1),
('JU01', N'Nước ép cam',        N'Nước ép cam nguyên chất',               40000, 1),
('JU02', N'Nước ép dứa',        N'Nước ép dứa tươi',                      39000, 1),
('JU03', N'Nước ép ổi',         N'Nước ép ổi tươi',                       38000, 1),
('CK01', N'Bánh cheesecake',    N'Bánh cheesecake vị truyền thống',       45000, 1),
('CK02', N'Bánh tiramisu',      N'Bánh tiramisu Ý',                       47000, 1),
('CK03', N'Bánh mousse',        N'Bánh mousse trái cây',                  43000, 1),
('CK04', N'Bánh flan',          N'Bánh flan mềm mịn',                     41000, 1);

-- Hóa đơn & Chi tiết hóa đơn đảm bảo các rank (OrderDate đều nằm trong khoảng 2025-07-02 đến 2025-09-19)
-- VIP: >= 10,000,000 (Khách 1 - Nguyễn Thị Mai)
INSERT INTO [Order] (OrderDate, CustomerID, TotalAmount, PaymentStatus, OrderStatus)
VALUES
('2025-07-10 08:00:00', 1, 2500000, 'Paid', 'Completed'),  -- Q3
('2025-08-05 09:00:00', 1, 2500000, 'Paid', 'Completed'),  -- Q3
('2025-09-01 10:00:00', 1, 2500000, 'Paid', 'Completed'),  -- Q3
('2025-09-15 11:00:00', 1, 2500000, 'Paid', 'Completed');  -- Q3

INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice) VALUES
(1, 'CF01', 50, 25000),
(2, 'CF02', 50, 28000),
(3, 'CK02', 53, 47000),
(4, 'JU01', 62, 40000);

-- Gold: >= 5,000,000 (Khách 2 - Lê Văn Nam)
INSERT INTO [Order] (OrderDate, CustomerID, TotalAmount, PaymentStatus, OrderStatus)
VALUES
('2025-07-15 08:00:00', 2, 2500000, 'Paid', 'Completed'),
('2025-08-20 09:00:00', 2, 2500000, 'Paid', 'Completed');

INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice) VALUES
(5, 'CF03', 50, 32000),
(6, 'TEA01', 71, 35000);

-- Silver: >= 2,000,000 (Khách 3 - Phạm Thị Hoa)
INSERT INTO [Order] (OrderDate, CustomerID, TotalAmount, PaymentStatus, OrderStatus)
VALUES
('2025-08-12 08:00:00', 3, 2000000, 'Paid', 'Completed');

INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice) VALUES
(7, 'CK01', 44, 45000);

-- Bronze: < 2,000,000 (Khách 4 - Trần Minh Tuấn)
INSERT INTO [Order] (OrderDate, CustomerID, TotalAmount, PaymentStatus, OrderStatus)
VALUES
('2025-07-18 08:00:00', 4, 1200000, 'Paid', 'Completed'),
('2025-08-23 09:00:00', 4, 600000, 'Paid', 'Completed');

INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice) VALUES
(8, 'CK03', 28, 43000),
(9, 'TEA02', 20, 30000);

-- Bronze: < 2,000,000 (Khách 5 - Bùi Anh Dũng)
INSERT INTO [Order] (OrderDate, CustomerID, TotalAmount, PaymentStatus, OrderStatus)
VALUES
('2025-09-07 10:00:00', 5, 1900000, 'Paid', 'Completed');

INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice) VALUES
(10, 'JU02', 48, 39000);

-- Silver: 2,000,000 (Khách 6 - Võ Thị Hồng)
INSERT INTO [Order] (OrderDate, CustomerID, TotalAmount, PaymentStatus, OrderStatus)
VALUES
('2025-07-28 10:00:00', 6, 2000000, 'Paid', 'Completed');

INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice) VALUES
(11, 'JU03', 53, 38000);

-- Gold: 5,000,000 (Khách 7 - Ngô Quang Huy)
INSERT INTO [Order] (OrderDate, CustomerID, TotalAmount, PaymentStatus, OrderStatus)
VALUES
('2025-07-29 08:00:00', 7, 2500000, 'Paid', 'Completed'),
('2025-09-12 09:00:00', 7, 2500000, 'Paid', 'Completed');

INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice) VALUES
(12, 'CK04', 61, 41000),
(13, 'TEA01', 71, 35000);

-- Bronze: 1,900,000 (Khách 8 - Hồ Thị Thanh)
INSERT INTO [Order] (OrderDate, CustomerID, TotalAmount, PaymentStatus, OrderStatus)
VALUES
('2025-08-18 09:00:00', 8, 1900000, 'Paid', 'Completed');

INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice) VALUES
(14, 'CF03', 59, 32000);

-- Bronze: < 2,000,000 (Khách 9 - Đỗ Văn Khoa)
INSERT INTO [Order] (OrderDate, CustomerID, TotalAmount, PaymentStatus, OrderStatus)
VALUES
('2025-09-05 08:00:00', 9, 1400000, 'Paid', 'Completed');

INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice) VALUES
(15, 'CK01', 31, 45000);

-- Silver: 2,000,000 (Khách 10 - Phan Thị Cẩm)
INSERT INTO [Order] (OrderDate, CustomerID, TotalAmount, PaymentStatus, OrderStatus)
VALUES
('2025-08-25 10:00:00', 10, 2000000, 'Paid', 'Completed');

INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice) VALUES
(16, 'CK02', 42, 47000);

-- TEST LÊN HẠNG TRIGGER
INSERT INTO [Order] (OrderDate, CustomerID, TotalAmount, PaymentStatus, OrderStatus)
VALUES ('2025-09-18 14:00:00', 3, 50000, 'Paid', 'Completed');
INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice)
VALUES (17, 'CF01', 2, 25000); -- 2 x 25.000 = 50.000

