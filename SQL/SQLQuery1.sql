CREATE DATABASE QLYcuahang
ON PRIMARY
    (NAME = QLBanHang_data,
    FILENAME = 'D:\cuoi_ki_lthdt\SQL\QLBanHang.mdf',
    SIZE = 10MB,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 5MB )
LOG ON
    (NAME = QLBanHang_log,
    FILENAME = 'D:\cuoi_ki_lthdt\SQL\QLBanHang.ldf',
    SIZE = 5MB,
    MAXSIZE = 100MB,
    FILEGROWTH = 5MB);


GO
USE QLYcuahang

GO
CREATE TABLE ThongTinNV (
    IDNV INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Phone NVARCHAR(15) NOT NULL,
    Gender NVARCHAR(10),
    Department int NOT NULL
);

-- Bảng ngày làm việc
CREATE TABLE NgayLamViec (
    Ngay DATE,
    StartTime TIME,
    EndTime TIME,
    IDNV INT,
    FOREIGN KEY (IDNV) REFERENCES ThongTinNV(IDNV)
);

-- Bảng thông tin khách hàng
CREATE TABLE KhachHang (
    IDKH INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(255),
    Phone NVARCHAR(15),
    Gender NVARCHAR(10),
    BirthDay DATE
);

-- Bảng khuyến mãi
CREATE TABLE KhuyenMai (
    IDSale INT PRIMARY KEY,
    Type NVARCHAR(50),
    Name NVARCHAR(255),
    Rate DECIMAL(5, 2)
);

CREATE TABLE FOODcategory(
	 ID INT IDENTITY PRIMARY KEY,
	 name NVARCHAR(100)
);
-- Bảng menu
CREATE TABLE FOOD (
    IDFood INT IDENTITY PRIMARY KEY,
    Type NVARCHAR(50),
    Quantity INT,
    Price FLOAT,
    name NVARCHAR(255)
);

-- Bảng chi tiết đơn hàng
CREATE TABLE ChiTietDonHang (
    IDDetail INT PRIMARY KEY,
    TotalPrice DECIMAL(10, 2),
    IDSale INT,
    IDFood INT,  
    FOREIGN KEY (IDSale) REFERENCES KhuyenMai(IDSale),
    FOREIGN KEY (IDFood) REFERENCES FOOD(IDFood) 
);

-- Bảng đơn đặt hàng
CREATE TABLE DonDatHang (
    IDOrder INT PRIMARY KEY,
    Time TIME NOT NULL DEFAULT GETDATE(),
	StatusOrder NVARCHAR(50),
    IDNV INT,
    IDKH INT,
    IDDetail INT,
    FOREIGN KEY (IDNV) REFERENCES ThongTinNV(IDNV),
    FOREIGN KEY (IDKH) REFERENCES KhachHang(IDKH),
    FOREIGN KEY (IDDetail) REFERENCES ChiTietDonHang(IDDetail)
);

-- Bảng đơn hàng - mục
CREATE TABLE DonHang_Muc (
    IDoi INT PRIMARY KEY,
    IDOrderDetail INT,
    IDFood INT,
    Quantity INT,
    FOREIGN KEY (IDOrderDetail) REFERENCES ChiTietDonHang(IDDetail),
    FOREIGN KEY (IDFood) REFERENCES FOOD(IDFood)
);

-- Tài Khoản
CREATE TABLE Account (
	IDTK int IDENTITY PRIMARY KEY,
	DisplayName NVARCHAR(100) NOT NULL,
	UserName NVARCHAR(100) NOT NULL,
	PASSWORD NVARCHAR(1000) NOT NULL,
	Department INT NOT NULL,

);