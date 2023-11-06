

CREATE or ALTER VIEW v_khachhang
AS
SELECT * FROM KhachHang
go


CREATE or ALTER VIEW v_nhanvien
AS
SELECT NhanVien.idNV, NhanVien.Ho_Ten, NhanVien.soDT_NV, CongViec.TenCV, NhanVien.TrangThai
FROM NhanVien join CongViec ON NhanVien.idCV = CongViec.idCV
GO


CREATE or ALTER VIEW v_dienthoai
AS
SELECT * FROM DienThoai
go

CREATE or ALTER VIEW v_hoadon
AS
SELECT * FROM HoaDon
go

CREATE or ALTER VIEW v_phancong
AS
SELECT BangPhanCa.idCa, NhanVien.Ho_Ten, CongViec.TenCV, CaLamViec.Gio_BatDau, CaLamViec.Gio_KetThuc, BangPhanCa.NgayLam, BangPhanCa.TrangThai
FROM BangPhanCa join NhanVien ON BangPhanCa.idNV = NhanVien.idNV join CongViec ON NhanVien.idCV = CongViec.idCV join CaLamViec on BangPhanCa.idCa = CaLamViec.idCa
go
