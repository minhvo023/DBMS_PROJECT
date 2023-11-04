use QuanLyCuaHangDienThoai

-- PROC LIÊN QUAN ĐẾN ĐIỆN THOẠI
CREATE or ALTER PROCEDURE proc_TimKiemHangGiaDT
(
	 @hang_dt NVARCHAR(max),
	 @giaban NVARCHAR(max)
)
AS
BEGIN
	IF @hang_dt != '0' and @giaban != '0'
	BEGIN
		IF @giaban = '< 10tr'
			BEGIN
				SELECT *
				FROM DienThoai
				WHERE GiaBan < 10000000 and TenHangDT LIKE '%' + @hang_dt
			END;
		IF @giaban = 'Từ 10tr - 25tr'
			BEGIN
				SELECT *
				FROM DienThoai
				WHERE GiaBan <= 25000000 and GiaBan >= 10000000 and TenHangDT LIKE '%' + @hang_dt
			END;
		IF @giaban = '> 25tr'
			BEGIN
				SELECT *
				FROM DienThoai
				WHERE GiaBan > 25000000 and TenHangDT LIKE '%' + @hang_dt
			END;
	END;
	ELSE
	BEGIN
		IF @hang_dt != '0'
		BEGIN
			SELECT *
			FROM DienThoai
			WHERE TenHangDT LIKE '%' + @hang_dt
		END;

		ELSE IF @giaban != '0'
		BEGIN
			IF @giaban = '< 10tr'
				BEGIN
					SELECT *
					FROM DienThoai
					WHERE GiaBan < 10000000 
				END;
			IF @giaban = 'Từ 10tr - 25tr'
				BEGIN
					SELECT *
					FROM DienThoai
					WHERE GiaBan <= 25000000 and GiaBan >= 10000000 
				END;
			IF @giaban = '> 25tr'
				BEGIN
					SELECT *
					FROM DienThoai
					WHERE GiaBan > 25000000 
				END;
		END;

		ELSE
		BEGIN
			SELECT *
			FROM DienThoai
		END;

	END;
END;
GO

CREATE or ALTER PROCEDURE proc_TimKiemTenDT
(
	@ten_dt NVARCHAR(max)
)
AS 
BEGIN
	IF @ten_dt is not null
	BEGIN
		SELECT *
		FROM DienThoai
		WHERE TenDienThoai LIKE '%' + @ten_dt + '%';
	END;
	ELSE
	BEGIN
		SELECT *
		FROM DienThoai
	END;
END;
GO


CREATE or ALTER PROCEDURE proc_InsertOrUpdateDienThoai
    @idDienThoai nchar(10),
    @TenDienThoai nvarchar(255),
    @TenHangDT nvarchar(255),
    @MauSac nvarchar(255),
    @DungLuong nvarchar(255),
    @GiaBan float,
    @SoLuong float,
    @TinhTrang nvarchar(255),
    @HinhAnh varbinary(max) = NULL -- Thêm giá trị mặc định là NULL cho tham số @HinhAnh
AS
BEGIN
    IF EXISTS (SELECT 1 FROM DienThoai WHERE idDienThoai = @idDienThoai)
    BEGIN
        -- Bản ghi đã tồn tại, thực hiện UPDATE
        UPDATE DienThoai
        SET
            TenDienThoai = @TenDienThoai,
            TenHangDT = @TenHangDT,
            MauSac = @MauSac,
            DungLuong = @DungLuong,
            GiaBan = @GiaBan,
            SoLuong = @SoLuong,
            TrangThai = @TinhTrang,
            HinhAnh = @HinhAnh
        WHERE idDienThoai = @idDienThoai;
    END
    ELSE
    BEGIN
        -- Bản ghi chưa tồn tại, thực hiện INSERT
        INSERT INTO DienThoai (idDienThoai, TenDienThoai, TenHangDT, MauSac, DungLuong, GiaBan, SoLuong, TrangThai, HinhAnh)
        VALUES (@idDienThoai, @TenDienThoai, @TenHangDT, @MauSac, @DungLuong, @GiaBan, @SoLuong, @TinhTrang, @HinhAnh);
    END;
END;
GO


CREATE OR ALTER PROCEDURE proc_XoaDienThoai
(
    @idDienThoai NVARCHAR(max)
)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM ChiTietDonNhap join DonNhap ON ChiTietDonNhap.idDonNhap = DonNhap.idDonNhap WHERE idDienThoai = @idDienThoai AND TrangThai = 'Chưa nhận')
    BEGIN
        IF EXISTS (SELECT 1 FROM DienThoai WHERE idDienThoai = @idDienThoai AND SoLuong = 0)
        BEGIN
            DELETE FROM DienThoai WHERE idDienThoai = @idDienThoai;
        END
        ELSE
        BEGIN
            RAISERROR('Không thể xóa điện thoại vì vẫn còn hàng trong kho.', 16, 1);
        END
    END
    ELSE
    BEGIN
        RAISERROR('Hàng đang được nhập về.', 16, 1);
    END
END;
GO



-- PROC LIÊN QUAN ĐẾN HÓA ĐƠN
CREATE OR ALTER PROCEDURE proc_ChiTietHoaDon
(
    @id_hoadon nvarchar(max)
)
AS
BEGIN
    IF @id_hoadon IS NOT NULL
    BEGIN
        -- Lấy thông tin Khách hàng
        SELECT DISTINCT KhachHang.idKH, KhachHang.TenKH, KhachHang.soDT_KH, KhachHang.DiaChi
        FROM KhachHang, HoaDon
        WHERE HoaDon.idKH = KhachHang.idKH AND HoaDon.idHD = @id_hoadon;

        -- Lấy thông tin Nhân viên
        SELECT DISTINCT NhanVien.idNV, NhanVien.Ho_Ten, CongViec.TenCV
        FROM NhanVien
        JOIN CongViec ON NhanVien.idCV = CongViec.idCV
        JOIN HoaDon ON HoaDon.idNV = NhanVien.idNV
        WHERE HoaDon.idHD = @id_hoadon;

        -- Lấy thông tin Điện thoại
        SELECT DienThoai.idDienThoai, DienThoai.TenDienThoai, DienThoai.TenHangDT, DienThoai.MauSac, DienThoai.DungLuong, DienThoai.GiaBan, ChiTietHoaDon.SoLuong
        FROM DienThoai, ChiTietHoaDon
        WHERE ChiTietHoaDon.idDienThoai = DienThoai.idDienThoai AND ChiTietHoaDon.idHD = @id_hoadon;
    END;
END;
GO

CREATE OR ALTER PROCEDURE proc_TimKiemHoaDon_date_and_status
(
    @date nvarchar(max),
    @status nvarchar(max)
)
AS
BEGIN
    IF @date IS NOT NULL AND @status IS NOT NULL
    BEGIN
        SELECT *
        FROM HoaDon
        WHERE HoaDon.Ngay = @date AND HoaDon.TrangThai = @status;
    END
    ELSE IF @date IS NOT NULL
    BEGIN
        SELECT *
        FROM HoaDon
        WHERE HoaDon.Ngay = @date;
    END
    ELSE IF @status IS NOT NULL
    BEGIN
        SELECT *
        FROM HoaDon
        WHERE HoaDon.TrangThai = @status;
    END
END;
GO


create or alter procedure proc_themgiohang
(
	@id_dt nvarchar(max),
	@so_luong int
)
as
begin
	-- Kiểm tra nếu @so_luong lớn hơn số lượng tồn kho của điện thoại
	if @id_dt is not null and @so_luong > 0
	begin
		DECLARE @so_luong_ton int;

		-- Lấy số lượng tồn kho của điện thoại
		SELECT @so_luong_ton = DienThoai.SoLuong
		FROM DienThoai
		WHERE idDienThoai = @id_dt;

		-- Kiểm tra nếu @so_luong lớn hơn số lượng tồn kho
		if @so_luong <= @so_luong_ton
		begin
			-- Truy vấn thông tin sản phẩm nếu điều kiện hợp lệ
			SELECT DienThoai.idDienThoai, DienThoai.TenDienThoai, DienThoai.GiaBan, @so_luong AS SoLuong
			FROM DienThoai
			WHERE DienThoai.idDienThoai = @id_dt;
		end;
	end;
end;
GO



-- PROC LIÊN QUAN ĐẾN KHÁCH HÀNG
create or alter procedure proc_timkiemkhachhang_sdt
(
	@sdt varchar(max)
)
as
begin
	if @sdt is not null
	begin
		SELECT *
		FROM KhachHang
		WHERE KhachHang.soDT_KH LIKE '%' + @sdt + '%'
	end;
	else
	begin
		SELECT *
		FROM KhachHang
	end;
end;
GO


create or alter procedure proc_lichsumuahang
(
	@id_kh nvarchar(max)
)
as
begin
	if @id_kh is not null
	begin
		SELECT HoaDon.idHD, HoaDon.Ngay,DienThoai.TenDienThoai,DienThoai.MauSac,DienThoai.DungLuong,ChiTietHoaDon.SoLuong,ChiTietHoaDon.TongTien
		FROM KhachHang 
		join HoaDon ON KhachHang.idKH = HoaDon.idKH 
		join ChiTietHoaDon ON HoaDon.idHD = ChiTietHoaDon.idHD
		join DienThoai ON DienThoai.idDienThoai = ChiTietHoaDon.idDienThoai
		WHERE KhachHang.idKH = @id_kh
	end;
end;
GO

CREATE or ALTER PROCEDURE proc_InsertOrUpdateKhachHang
    @idKH nchar(10),
    @TenKH nvarchar(255),
    @DiaChi nvarchar(255),
    @soDT_KH nvarchar(20)
AS
BEGIN
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


-- PROC LIÊN QUAN ĐẾN NHÂN VIÊN
create or alter procedure proc_chitietthongtin_nv
(
	@id_nv nvarchar(max)
)
as
begin
	if @id_nv is not null
	begin
		SELECT *
		FROM NhanVien join CongViec ON NhanVien.idCV = CongViec.idCV
		WHERE NhanVien.idNV = @id_nv
	end;
end;
GO





