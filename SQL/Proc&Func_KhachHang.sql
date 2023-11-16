CREATE or ALTER PROCEDURE proc_KhachHang_lsmh -- DONE
(
	@idKH nvarchar(max)
)
AS
BEGIN
	IF EXISTS (SELECT * FROM HoaDon join ChiTietHoaDon ON HoaDon.idHD = ChiTietHoaDon.idHD WHERE HoaDon.idKH = @idKH)
	BEGIN
		SELECT HoaDon.idHD, HoaDon.Ngay,DienThoai.TenDienThoai,DienThoai.MauSac,DienThoai.DungLuong,ChiTietHoaDon.SoLuong,ChiTietHoaDon.TongTien
		FROM KhachHang 
		join HoaDon ON KhachHang.idKH = HoaDon.idKH 
		join ChiTietHoaDon ON HoaDon.idHD = ChiTietHoaDon.idHD
		join DienThoai ON DienThoai.idDienThoai = ChiTietHoaDon.idDienThoai
		WHERE KhachHang.idKH = @idKH
	END;
	ELSE
	BEGIN
		RAISERROR('Khách vãng lai!',16,1);
	END;
END;
GO

CREATE or ALTER PROCEDURE proc_KhachHang_InsertOrUpdate --DONE
    @idKH nchar(10),
    @TenKH nvarchar(255),
    @DiaChi nvarchar(255),
    @soDT_KH nvarchar(20)
AS
BEGIN
	IF(@TenKH = '' OR @DiaChi = '' OR @soDT_KH = '' )
	BEGIN
		RAISERROR (N'Bạn chưa nhập thông tin Khách Hàng! ',16,1);
		RETURN
	END
    IF EXISTS (SELECT 1 FROM KhachHang WHERE idKH = @idKH)
    BEGIN
        -- Bản ghi khách hàng đã tồn tại, thực hiện UPDATE
        UPDATE KhachHang
        SET
            TenKH = @TenKH,
            DiaChi = @DiaChi,
            soDT_KH = @soDT_KH
        WHERE idKH = @idKH;
    END
    ELSE
    BEGIN
        -- Bản ghi khách hàng chưa tồn tại, thực hiện INSERT
        INSERT INTO KhachHang (idKH, TenKH, DiaChi, soDT_KH)
        VALUES (@idKH, @TenKH, @DiaChi, @soDT_KH);
    END;
END;
GO

CREATE or ALTER PROCEDURE proc_KhachHang_XoaKH --DONE
	@idKH NVARCHAR(255)
AS
BEGIN
    -- Kiểm tra xem khách hàng có đơn hàng đang tồn tại không
    IF EXISTS (SELECT 1 FROM HoaDon WHERE idKH = @idKH)
    BEGIN
        RAISERROR('Đây là Khách Hàng tiềm năng!', 16, 1)
    END
    ELSE
    BEGIN
        DELETE FROM KhachHang WHERE idKH = @idKH
    END
END
GO

CREATE OR ALTER PROCEDURE proc_KhachHang_TK_sdt
(
    @sdt varchar(max) = null
)
AS
BEGIN
    IF @sdt IS NOT NULL AND LEN(@sdt) = 10
    BEGIN
        IF EXISTS (SELECT * FROM KhachHang WHERE KhachHang.soDT_KH LIKE '%' + @sdt + '%')
        BEGIN
            SELECT *
            FROM KhachHang
            WHERE KhachHang.soDT_KH LIKE '%' + @sdt + '%';
        END
        ELSE
        BEGIN
            RAISERROR('Không tìm thấy! - Hãy tạo thông tin!', 16, 1);
        END;
    END
    ELSE
    BEGIN
        RAISERROR('Số điện thoại không hợp lệ!', 16, 1);
    END;
END;
GO

CREATE OR ALTER FUNCTION func_KhachHang_idMAX()
RETURNS NCHAR(10)
AS
BEGIN
	DECLARE @maxId NCHAR(10)
	SELECT @maxId = MAX(idKH) FROM KhachHang
	RETURN @maxId
END
GO


CREATE OR ALTER FUNCTION func_KhachHang_idMAX()
RETURNS NCHAR(10)
AS
BEGIN
	DECLARE @maxId NCHAR(10)
	SELECT @maxId = MAX(idKH) FROM KhachHang
	RETURN @maxId
END
GO
