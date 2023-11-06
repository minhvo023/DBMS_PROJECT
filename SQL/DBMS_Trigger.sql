-- Tạo trigger INSTEAD OF DELETE trên bảng HoaDon
CREATE or ALTER TRIGGER HoaDon_InsteadOfDelete --DONE
ON HoaDon
INSTEAD OF DELETE
AS
BEGIN
    -- Tạo bảng tạm thời lưu danh sách các id của hóa đơn bị xóa
    DECLARE @DeletedHD TABLE (idHD nvarchar(max));

    -- Lấy danh sách các id của hóa đơn bị xóa và lưu vào bảng tạm thời
    INSERT INTO @DeletedHD (idHD)
    SELECT idHD FROM deleted;

    -- Cập nhật lại số lượng bảng điện thoại bằng truy vấn lồng nhau
    UPDATE DienThoai
    SET SoLuong = DienThoai.SoLuong + D.SoLuong
    FROM DienThoai
    INNER JOIN (
        SELECT idHD, idDienThoai, SUM(SoLuong) AS SoLuong
        FROM ChiTietHoaDon
        WHERE idHD IN (SELECT idHD FROM @DeletedHD)
        GROUP BY idHD, idDienThoai
    ) AS D ON DienThoai.idDienThoai = D.idDienThoai;

	-- Tiếp theo, xóa chi tiết hóa đơn liên quan
    DELETE FROM ChiTietHoaDon
	WHERE idHD IN (SELECT idHD FROM @DeletedHD);

    -- Tiếp theo, xóa hóa đơn
    DELETE FROM HoaDon
    WHERE idHD IN (SELECT idHD FROM @DeletedHD);
END; 
GO


CREATE or ALTER TRIGGER KhachHang_KiemTra_TenKH_sdtKH --DONE
ON KhachHang
AFTER INSERT
AS
BEGIN
	IF EXISTS ( SELECT * FROM inserted i WHERE EXISTS (SELECT *FROM KhachHang k WHERE k.TenKH = i.TenKH AND k.idKH <> i.idKH))
	BEGIN
	-- Nếu trùng thì rollback
		ROLLBACK;
		RAISERROR('Tên Khách Hàng đã tồn tại!', 16,1)
	END
	IF EXISTS ( SELECT * FROM inserted i WHERE EXISTS (SELECT *FROM KhachHang k WHERE k.soDT_KH = i.soDT_KH AND k.idKH <> i.idKH))
	BEGIN
	-- Nếu trùng thì rollback
		ROLLBACK;
		RAISERROR('Số Điện Thoại Khách Hàng đã tồn tại!', 16,1)
	END
END
GO


CREATE OR ALTER TRIGGER NhanVien_KiemTra_Tuoi
ON NhanVien
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS ( SELECT 1 FROM inserted i WHERE DATEDIFF(YEAR, CAST(i.NgaySinh AS DATE), GETDATE()) < 18)
    BEGIN
        -- Nếu tuổi nhân viên dưới 18, thực hiện ROLLBACK và hiển thị thông báo lỗi
        ROLLBACK;
        RAISERROR('Tuổi Nhân Viên phải lớn hơn hoặc bằng 18!', 16, 1);
    END
	-- Kiểm tra số điện thoại nhân viên
    IF EXISTS ( SELECT 1 FROM inserted i WHERE LEN(i.soDT_NV) <> 10 )
    BEGIN
        -- Nếu số điện thoại không có đúng 10 số, thực hiện ROLLBACK và hiển thị thông báo lỗi
        ROLLBACK;
        RAISERROR('Số Điện Thoại Nhân Viên sai định dạng!', 16, 1);
    END
END;


