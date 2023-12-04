CREATE DATABASE quanLyBanHang

ON PRIMARY
(
	NAME = QL_BANHANG,
	FILENAME = 'E:\c# năm 2 kì 1\cuoi_ki_lthdt\SQL\QL_BANHANG.mdf',
	SIZE = 10MB,
	MAXSIZE = 50MB,
	FILEGROWTH = 5MB 
)
LOG ON
(
	NAME = QL_BANHANG_LOG,
	FILENAME = 'E:\c# năm 2 kì 1\cuoi_ki_lthdt\SQL\QL_BANHANG_LOG.ldf',
	SIZE = 200MB,
	MAXSIZE = 500MB,
	FILEGROWTH = 10MB 
)
-- Bảng Nhân viên
CREATE TABLE NhanVien (
    MaNhanVien INT PRIMARY KEY,
    TenNhanVien VARCHAR(255),
    SoDienThoai VARCHAR(20),
    Email VARCHAR(100)
);
-- Bảng Thức ăn/Thức uống
CREATE TABLE ThucAnThucUong (
    MaMon INT PRIMARY KEY,
    TenMon VARCHAR(255),
    Gia DECIMAL(10,2)
);
-- Bảng Thành viên
CREATE TABLE ThanhVien (
    MaThanhVien INT PRIMARY KEY,
    TenThanhVien VARCHAR(255),
    -- Thêm các cột khác theo nhu cầu
    ChiTietHoaDon INT,
    NgayDat DATE
);

-- Bảng Hóa đơn
CREATE TABLE HoaDon (
    MaHoaDon INT PRIMARY KEY,
    MaNhanVien INT,
    MaThanhVien INT,
    NgayTao DATE,
    TongTien DECIMAL(10,2),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien), -- Liên kết với bảng Nhân viên
    FOREIGN KEY (MaThanhVien) REFERENCES ThanhVien(MaThanhVien)
);

-- Bảng Chi tiết hóa đơn
CREATE TABLE ChiTietHoaDon (
    MaChiTietHoaDon INT PRIMARY KEY,
    MaHoaDon INT,
    MaMon INT,
    SoLuong INT,
    Gia DECIMAL(10,2),
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
    FOREIGN KEY (MaMon) REFERENCES ThucAnThucUong(MaMon)
);

-- Bảng Chương trình khuyến mãi
CREATE TABLE ChuongTrinhKhuyenMai (
    MaChuongTrinh INT PRIMARY KEY,
    LoaiChuongTrinh VARCHAR(50) CHECK (LoaiChuongTrinh IN ('theo ngay', 'theo combo')),
    MoTa TEXT,
    PhanTramGiamGia DECIMAL(5,2)
);

-- Bảng Chi tiết khuyến mãi
CREATE TABLE ChiTietKhuyenMai (
    MaChiTietKhuyenMai INT PRIMARY KEY,
    MaChuongTrinh INT,
    MaMon INT,
    PhanTramGiamGia DECIMAL(5,2),
    FOREIGN KEY (MaChuongTrinh) REFERENCES ChuongTrinhKhuyenMai(MaChuongTrinh),
    FOREIGN KEY (MaMon) REFERENCES ThucAnThucUong(MaMon)
);
