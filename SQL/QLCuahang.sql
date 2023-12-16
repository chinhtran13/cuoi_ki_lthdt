DROP DATABASE QLYcuahang
CREATE DATABASE QLYcuahang
ON PRIMARY
    (NAME = QLBanHang_data,
    FILENAME = 'D:\QLBanHang.mdf',
    SIZE = 10MB,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 5MB )
LOG ON
    (NAME = QLBanHang_log,
    FILENAME = 'D:\QLBanHang.ldf',
    SIZE = 5MB,
    MAXSIZE = 100MB,
    FILEGROWTH = 5MB);

GO
USE QLYcuahang
--update 16/12
DROP TABLE HoaDon
DROP TABLE NhanVien
DROP TABLE KhuyenMai
DROP TABLE ThanhVien
DROP TABLE SanPham
DROP TABLE CTHD

GO
CREATE TABLE NhanVien (
    MaNV VARCHAR(50) PRIMARY KEY,
    TenNV VARCHAR(255) NOT NULL,
    SDT VARCHAR(15) NOT NULL,
    Email VARCHAR(255) NOT NULL,
);

CREATE TABLE KhuyenMai (
    MaKM VARCHAR(50) PRIMARY KEY,
    LoaiKM VARCHAR(255) NOT NULL,
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL,
    ComboKM VARCHAR(255),
    PhanTramGiam FLOAT NOT NULL
);

CREATE TABLE ThanhVien (
    SDTTV VARCHAR(15) PRIMARY KEY,
    TenTV VARCHAR(255) NOT NULL,
    Email VARCHAR(255)
);

CREATE TABLE SanPham (
    MaSP VARCHAR(50) PRIMARY KEY,
    TenSP VARCHAR(255) NOT NULL,
    Gia FLOAT NOT NULL,
    SoLuong INT NOT NULL,
	LoaiSP VARCHAR(255) NOT NULL
);

CREATE TABLE HoaDon (
    MaHD VARCHAR(50) PRIMARY KEY,
    NgayTao DATE NOT NULL,
    SDT VARCHAR(15) NULL,
    MaNV VARCHAR(50) NOT NULL,
    MaKM VARCHAR(50) NULL,
    FOREIGN KEY (SDT) REFERENCES ThanhVien(SDTTV),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaKM) REFERENCES KhuyenMai(MaKM)
);

CREATE TABLE CTHD (
    MaHD VARCHAR(50) NOT NULL,
    MaSP VARCHAR(50) NOT NULL,
    SL INT NOT NULL,
    DonGia FLOAT NOT NULL,
    TongTien FLOAT NOT NULL,
    PRIMARY KEY (MaHD, MaSP),
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);
-- Inserting data into NhanVien
INSERT INTO NhanVien (MaNV, TenNV, SDT, Email)
VALUES
(1, 'Nguyen Van A', '0123456789', 'nva@example.com'),
(2, 'Le Thi B', '0123456780', 'ltb@example.com'),
(3, 'Tran Van C', '0123456781', 'tvc@example.com'),
(4, 'Pham Thi D', '0123456782', 'ptd@example.com'),
(5, 'Hoang Van E', '0123456783', 'hve@example.com');

-- Inserting data into KhuyenMai
INSERT INTO KhuyenMai (MaKM, LoaiKM, NgayBatDau, NgayKetThuc, ComboKM, PhanTramGiam)
VALUES
(1, 'Discount', '2023-01-01', '2023-01-31','', 10),
(2, 'Discount', '2023-02-01', '2023-02-28', 'Product 2, 1,3', 15)

-- Inserting data into ThanhVien
INSERT INTO ThanhVien (SDTTV, TenTV, Email)
VALUES
('0987654321', 'Nguyen Van F', 'nvf@example.com'),
('0987654320', 'Le Thi G', 'ltg@example.com'),
('0987654319', 'Tran Van H', 'tvh@example.com'),
('0987654318', 'Pham Thi I', 'pti@example.com'),
('0987654317', 'Hoang Van J', 'hvj@example.com');

-- Inserting data into SanPham
INSERT INTO SanPham (MaSP, TenSP, Gia, SoLuong, LoaiSP)
VALUES
(1, 'Product 1', 10000, 100, 'Do An'),
(2, 'Product 2', 20000, 200, 'Do An'),
(3, 'Product 3', 30000, 300, 'Do Uong'),
(4, 'Product 4', 40000, 400, 'Do Uong'),
(5, 'Product 5', 50000, 500, 'Do Uong');

-- Inserting data into HoaDon
INSERT INTO HoaDon (MaHD, NgayTao, SDT, MaNV, MaKM)
VALUES
(1, '2023-06-01', '0987654321', 1, 1),
(2, '2023-06-02', '0987654320', 2, 2),
(3, '2023-06-03', null, 3, null),
(4, '2023-06-04', null, 4, null),
(5, '2023-06-05', '0987654317', 5, null);

-- Inserting data into CTHD
INSERT INTO CTHD (MaHD, MaSP, SL, DonGia, TongTien)
VALUES
(1, 1, 10, 10000, 100000),
(2, 2, 20, 20000, 400000),
(3, 3, 30, 30000, 900000),
(4, 4, 40, 40000, 1600000),
(5, 5, 50, 50000, 2500000);

select *
from CTHD
