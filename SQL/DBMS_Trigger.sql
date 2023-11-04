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

	UPDATE HoaDon
	Set TrangThai = N'Đơn Đã Hủy'
	WHERE idHD IN (SELECT idHD FROM @DeletedHDIDs);
END;

    -- Tiếp theo, xóa chi tiết hóa đơn liên quan
    --DELETE FROM ChiTietHoaDon
    --WHERE idHD IN (SELECT idHD FROM @DeletedHDIDs);

    -- Tiếp theo, xóa hóa đơn
    --DELETE FROM HoaDon
    --WHERE idHD IN (SELECT idHD FROM @DeletedHDIDs);

CREATE OR ALTER TRIGGER UpdateTrangThaiVaKiemTraDienThoai
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
		RAISERROR ('Error, vui lòng kiểm tra lại thông tin', 0, 0)
		ROLLBACK;
	END;
END;


CREATE OR ALTER TRIGGER InsteadOfDeleteTrigger
ON DienThoai
INSTEAD OF DELETE
AS
BEGIN
    -- Cập nhật tình trạng thành "ngừng bán"
    UPDATE DienThoai
    SET TinhTrang = N'Ngừng bán'
    WHERE DienThoai.idDienThoai IN (SELECT idDienThoai FROM deleted);
END;


DELETE FROM DienThoai WHERE idDienThoai = 'dt07'