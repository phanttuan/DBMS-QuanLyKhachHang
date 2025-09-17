CREATE TABLE Customer (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    PhoneNumber VARCHAR(12) NOT NULL UNIQUE,
    Email VARCHAR(100) UNIQUE,
    Address NVARCHAR(255),
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
    SubTotal AS CAST((Quantity * UnitPrice) AS DECIMAL(12, 2)) PERSISTED,

    CONSTRAINT PK_OrderDetail PRIMARY KEY (OrderID, ProductID),
    CONSTRAINT FK_OrderDetail_Order FOREIGN KEY (OrderID) REFERENCES [Order](OrderID) ON DELETE CASCADE,
    CONSTRAINT FK_OrderDetail_Product FOREIGN KEY (ProductID) REFERENCES Product(ProductID),
    CONSTRAINT CK_OrderDetail_Quantity CHECK (Quantity > 0),
    CONSTRAINT CK_OrderDetail_UnitPrice CHECK (UnitPrice >= 0)
);