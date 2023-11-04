-- Tạo trigger INSTEAD OF DELETE trên bảng HoaDon
CREATE or ALTER TRIGGER InsteadOfDeleteHoaDon
ON HoaDon
INSTEAD OF DELETE
AS
BEGIN
    -- Tạo bảng tạm thời lưu danh sách các id của hóa đơn bị xóa
    DECLARE @DeletedHDIDs TABLE (idHD nvarchar(max));

    -- Lấy danh sách các id của hóa đơn bị xóa và lưu vào bảng tạm thời
    INSERT INTO @DeletedHDIDs (idHD)
    SELECT idHD FROM deleted;

    -- Cập nhật lại số lượng bảng điện thoại bằng truy vấn lồng nhau
    UPDATE DienThoai
    SET SoLuong = DienThoai.SoLuong + D.SoLuong
    FROM DienThoai
    INNER JOIN (
        SELECT idHD, idDienThoai, SUM(SoLuong) AS SoLuong
        FROM ChiTietHoaDon
        WHERE idHD IN (SELECT idHD FROM @DeletedHDIDs)
        GROUP BY idHD, idDienThoai
    ) AS D ON DienThoai.idDienThoai = D.idDienThoai;

	-- Tiếp theo, xóa chi tiết hóa đơn liên quan
    DELETE FROM ChiTietHoaDon
	WHERE idHD IN (SELECT idHD FROM @DeletedHDIDs);

    -- Tiếp theo, xóa hóa đơn
    DELETE FROM HoaDon
    WHERE idHD IN (SELECT idHD FROM @DeletedHDIDs);

	/*UPDATE HoaDon
	Set TrangThai = N'Đơn Đã Hủy'
	WHERE idHD IN (SELECT idHD FROM @DeletedHDIDs);*/
END; 
GO


CREATE or ALTER TRIGGER KiemTraTenKH
ON KhachHang
AFTER INSERT, UPDATE
AS
BEGIN
	-- Kiểm tra số điện thoại vừa thêm có bị trùng lặp
	IF EXISTS ( SELECT * FROM inserted i WHERE EXISTS (SELECT *FROM KhachHang k WHERE k.TenKH = i.TenKH AND k.idKH <> i.idKH ))
	BEGIN
	-- Nếu trùng thì rollback
		ROLLBACK;
	END
END
GO


CREATE OR ALTER TRIGGER UpdateTrangThaiDienThoai
ON DienThoai
AFTER INSERT, UPDATE
AS
BEGIN
	-- Cập nhật trạng thái dựa trên số lượng
	UPDATE DienThoai
	SET TinhTrang = CASE
		WHEN SoLuong = 0 THEN N'Hết hàng'
		ELSE N'Còn hàng'
		END
	WHERE DienThoai.idDienThoai IN (SELECT idDienThoai FROM inserted);

	-- Kiểm tra và ngăn chặn cập nhật sai
	IF (SELECT COUNT(*) FROM inserted WHERE SoLuong < 0 OR GiaBan < 0) > 0 
	begin
		RAISERROR ('THÔNG TIN VỀ GIÁ HOẶC SỐ LƯỢNG KHÔNG CHÍNH XÁC', 0, 0)
		ROLLBACK;
	END;
END;
GO


CREATE TRIGGER DeleteCustomer
ON KhachHang
INSTEAD OF DELETE
AS
BEGIN
    DECLARE @idKH NVARCHAR(max)

    -- Lấy danh sách các khách hàng bị xóa từ bảng xóa ảo (deleted)
    SELECT @idKH = idKH
    FROM deleted

    -- Kiểm tra xem khách hàng có đơn hàng đang tồn tại không
    IF EXISTS (SELECT 1 FROM HoaDon WHERE idKH = @idKH)
    BEGIN
        RAISERROR('Không thể xóa khách hàng có đơn hàng đang tồn tại.', 16, 1)
        ROLLBACK TRANSACTION
    END
    ELSE
    BEGIN
        -- Nếu không có đơn hàng nào, thực hiện xóa khách hàng
        DELETE FROM KhachHang WHERE idKH = @idKH
    END
END
GO