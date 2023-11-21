CREATE ROLE NhanVien

-- Các quyền cơ bản cho NhanVien
GRANT SELECT, REFERENCES ON BangPhanCa TO NhanVien
GRANT SELECT, REFERENCES ON CaLamViec TO NhanVien
GRANT SELECT, REFERENCES ON ChiTietHoaDon TO NhanVien
GRANT SELECT, REFERENCES ON ChiTietDonNhap TO NhanVien
GRANT SELECT, REFERENCES ON CongViec TO NhanVien
GRANT SELECT, REFERENCES ON NhanVien TO NhanVien
GRANT SELECT, REFERENCES ON DienThoai TO NhanVien
GRANT SELECT, REFERENCES ON HangDienThoai TO NhanVien
GRANT SELECT, REFERENCES ON NhaCungCap TO NhanVien
GRANT SELECT, INSERT, REFERENCES ON DonNhap TO NhanVien
GRANT SELECT, INSERT, REFERENCES ON HoaDon TO NhanVien
GRANT SELECT, INSERT, REFERENCES ON KhachHang TO NhanVien

-- Các quyền thực thi proc, func của NhanVien
GRANT EXECUTE TO NhanVien
GRANT SELECT TO NhanVien

-- Bỏ bớt các quyền thêm, xóa, sửa, cập nhật từ các proc của NhanVien
DENY EXECUTE ON proc_DienThoai_Delete TO NhanVien
DENY EXECUTE ON proc_DienThoai_InsertOrUpdate TO NhanVien
DENY EXECUTE ON proc_KhachHang_XoaKH TO NhanVien
DENY EXECUTE ON proc_NhanVien_InsertOrUpdate TO NhanVien
DENY EXECUTE ON proc_NhanVien_XoaNV TO NhanVien
DENY EXECUTE ON proc_PhanCa_Insert TO NhanVien
DENY SELECT ON func_PhanCa_TK_Date_Ca TO NhanVien
DENY EXECUTE ON proc_NhanVien_ttct TO NhanVien

GO


