

CREATE or ALTER VIEW v_khachhang
AS
SELECT * FROM KhachHang
go


CREATE or ALTER VIEW v_nhanvien
AS
SELECT NhanVien.idNV, NhanVien.Ho_Ten, NhanVien.soDT_NV, CongViec.TenCV, NhanVien.TrangThai, NhanVien.HinhAnh
FROM NhanVien join CongViec ON NhanVien.idCV = CongViec.idCV
WHERE CongViec.TenCV <> N'Quản lý'
GO


CREATE or ALTER VIEW v_dienthoai
AS
SELECT * FROM DienThoai
GO

CREATE or ALTER VIEW v_hoadon
AS
SELECT * FROM HoaDon
go

CREATE or ALTER VIEW v_phancong
AS
SELECT BangPhanCa.NgayLam ,NhanVien.idNV, NhanVien.Ho_Ten ,BangPhanCa.idCa,  BangPhanCa.TrangThai
FROM BangPhanCa join NhanVien ON BangPhanCa.idNV = NhanVien.idNV join CongViec ON NhanVien.idCV = CongViec.idCV join CaLamViec on BangPhanCa.idCa = CaLamViec.idCa
go

