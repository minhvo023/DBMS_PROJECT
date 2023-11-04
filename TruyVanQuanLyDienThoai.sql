use QuanLyCuaHangDienThoai


-------Thêm điện thoại----------
DROP PROCEDURE XoaDienThoai;

CREATE PROCEDURE ThemDienThoai
@idDienThoai nchar(10),
@TenHangDT nvarchar(100),
@TenDienThoai nvarchar(100),
@SoLuong float,
@MauSac nvarchar(30),
@DungLuong nchar(10),
@GiaBan float,
@NguonGoc nvarchar(100)=null,
@TinhTrang nvarchar(100)=null

AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
		IF NOT EXISTS (SELECT * FROM HangDienThoai  WHERE TenHangDT = @TenHangDT)
		BEGIN 
			INSERT INTO HangDienThoai(TenHangDT,NguonGoc,TinhTrang)
			VALUES (@TenHangDT,@NguonGoc,@TinhTrang)
		END
		INSERT INTO DienThoai VALUES
    (@idDienThoai, @TenHangDT, @TenDienThoai, @SoLuong, @MauSac, @DungLuong, @GiaBan)
		COMMIT TRAN
	END TRY

	BEGIN CATCH
			ROLLBACK
			DECLARE @err NVARCHAR(MAX)
			SELECT @err = N'Lỗi + ' + ERROR_MESSAGE()
			RAISERROR(@err, 16, 1)
	END CATCH
END
EXEC ThemDienThoai 'DT001', 'Apple', 'iPhone 14 Pro Max', 1000, 'Xanh dương', '128GB', 30000000
select * from DienThoai

go



--------Xóa điện thoại bất kì---------

CREATE PROCEDURE XoaDienThoai
    @idDienThoai nchar(10)
AS
BEGIN
    -- Xóa điện thoại từ bảng DienThoai
    DELETE FROM DienThoai
    WHERE idDienThoai = @idDienThoai;

    -- Cập nhật idDienThoai trong bảng ChiTietDonNhap thành NULL
   
END;




go
EXEC XoaDienThoai 'dt09'
go




---- Tìm kiếm điện thoại----------
CREATE FUNCTION TimKiemDienThoai(
    @tuKhoa NVARCHAR(100)
)
RETURNS TABLE
AS
RETURN
    SELECT *
    FROM DienThoai
    WHERE idDienThoai LIKE '%' + @tuKhoa + '%'
        OR TenHangDT LIKE '%' + @tuKhoa + '%'
        OR TenDienThoai LIKE '%' + @tuKhoa + '%'
        OR MauSac LIKE '%' + @tuKhoa + '%'
        OR DungLuong LIKE '%' + @tuKhoa + '%'
go




-----sửa thông tin điện thoại------
CREATE PROCEDURE SuaDienThoai
    @idDienThoai nchar(10),
    @TenHangDT nvarchar(100),
    @TenDienThoai nvarchar(100),
    @SoLuong float,
    @MauSac nvarchar(30),
    @DungLuong nchar(10),
    @GiaBan float
AS
BEGIN
    UPDATE DienThoai
    SET TenHangDT = @TenHangDT,
        TenDienThoai = @TenDienThoai,
        SoLuong = @SoLuong,
        MauSac = @MauSac,
        DungLuong = @DungLuong,
        GiaBan = @GiaBan
    WHERE idDienThoai = @idDienThoai;
END;

EXEC SuaDienThoai
    @idDienThoai = N'DT001',
    @TenHangDT = N'Samsung',
    @TenDienThoai = N'Galaxy S21',
    @SoLuong = 10,
    @MauSac = N'Đen',
    @DungLuong = N'128GB',
    @GiaBan = 15000000;

CREATE TRIGGER trg_ThemDienThoai
ON DienThoai
FOR INSERT, UPDATE
AS
BEGIN
    -- check idDienThoai
    IF EXISTS (SELECT * FROM inserted WHERE idDienThoai IS NULL OR LTRIM(RTRIM(idDienThoai)) = '')
    BEGIN
        RAISERROR('id điện thoại không được để trống', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END

    IF EXISTS (SELECT * FROM DienThoai WHERE idDienThoai IN (SELECT idDienThoai FROM inserted) AND EXISTS (SELECT 1 FROM deleted))
    BEGIN
        RAISERROR('id điện thoại đã tồn tại', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END

    -- check TenDienThoai
    IF EXISTS (SELECT * FROM inserted WHERE TenDienThoai IS NULL OR LTRIM(RTRIM(TenDienThoai)) = '')
    BEGIN
        RAISERROR('Tên điện thoại không được để trống', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END

    -- check TenHangDT
    IF EXISTS (SELECT * FROM inserted WHERE TenHangDT IS NULL OR LTRIM(RTRIM(TenHangDT)) = '')
    BEGIN
        RAISERROR('Tên hãng điện thoại không được để trống', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END
END



