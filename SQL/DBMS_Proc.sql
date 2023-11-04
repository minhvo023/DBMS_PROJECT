use QuanLyCuaHangDienThoai



create or alter procedure proc_TimKiemHangDT
(
	 @hang_dt nvarchar(max),
	 @giaban nvarchar(max)
)
as
begin
	if @hang_dt != '0' and @giaban != '0'
	begin
		if @giaban = '< 10tr'
			begin
				select *
				from DienThoai
				where GiaBan < 10000000 and TenHangDT LIKE '%' + @hang_dt
			end;
		if @giaban = 'Từ 10tr - 25tr'
			begin
				select *
				from DienThoai
				where GiaBan <= 25000000 and GiaBan >= 10000000 and TenHangDT LIKE '%' + @hang_dt
			end;
		if @giaban = '> 25tr'
			begin
				select *
				from DienThoai
				where GiaBan > 25000000 and TenHangDT LIKE '%' + @hang_dt
			end;
	end;
	else
	begin
		if @hang_dt != '0'
		begin
			SELECT *
			FROM DienThoai
			WHERE TenHangDT LIKE '%' + @hang_dt
		end;

		else if @giaban != '0'
		begin
			if @giaban = '< 10tr'
				begin
					select *
					from DienThoai
					where GiaBan < 10000000 
				end;
			if @giaban = 'Từ 10tr - 25tr'
				begin
					select *
					from DienThoai
					where GiaBan <= 25000000 and GiaBan >= 10000000 
				end;
			if @giaban = '> 25tr'
				begin
					select *
					from DienThoai
					where GiaBan > 25000000 
				end;
		end;

		else
		begin
			SELECT *
			FROM DienThoai
		end;

	end;
end;

create or alter procedure proc_TimKiemTenDT
(
	@ten_dt nvarchar(max)
)
as 
begin
	if @ten_dt is not null
	begin
		SELECT *
		FROM DienThoai
		WHERE TenDienThoai LIKE '%' + @ten_dt + '%';
	end;
	else
	begin
		SELECT *
		FROM DienThoai
	end;
end;


create or alter procedure proc_chitiethoadon_kh
(
	@id_hoadon nvarchar(max)
)
as
begin
	if @id_hoadon is not null
	begin
		SELECT DISTINCT KhachHang.idKH, KhachHang.TenKH,KhachHang.soDT_KH,KhachHang.DiaChi
		FROM KhachHang, ChiTietHoaDon
		WHERE ChiTietHoaDon.idKH = KhachHang.idKH and ChiTietHoaDon.idHD = @id_hoadon
	end;
end;


create or alter procedure proc_chitiethoadon_nv
(
	@id_hoadon nvarchar(max)
)
as
begin
	if @id_hoadon is not null
	begin
		SELECT DISTINCT NhanVien.idNV, NhanVien.Ho_Ten,CongViec.TenCV
		FROM NhanVien join CongViec ON NhanVien.idCV = CongViec.idCV, ChiTietHoaDon
		WHERE ChiTietHoaDon.idNV = NhanVien.idNV and ChiTietHoaDon.idHD = @id_hoadon
	end;
end;


create or alter procedure proc_chitiethoadon_dt
(
	@id_hoadon nvarchar(max)
)
as
begin
	if @id_hoadon is not null
	begin
		SELECT DienThoai.idDienThoai,DienThoai.TenDienThoai,DienThoai.TenHangDT,DienThoai.MauSac, DienThoai.DungLuong,DienThoai.GiaBan, ChiTietHoaDon.SoLuong
		FROM DienThoai, ChiTietHoaDon
		WHERE ChiTietHoaDon.idDienThoai = DienThoai.idDienThoai and ChiTietHoaDon.idHD = @id_hoadon
	end;
end;

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
        FROM KhachHang, ChiTietHoaDon
        WHERE ChiTietHoaDon.idKH = KhachHang.idKH AND ChiTietHoaDon.idHD = @id_hoadon;

        -- Lấy thông tin Nhân viên
        SELECT DISTINCT NhanVien.idNV, NhanVien.Ho_Ten, CongViec.TenCV
        FROM NhanVien
        JOIN CongViec ON NhanVien.idCV = CongViec.idCV
        JOIN ChiTietHoaDon ON ChiTietHoaDon.idNV = NhanVien.idNV
        WHERE ChiTietHoaDon.idHD = @id_hoadon;

        -- Lấy thông tin Điện thoại
        SELECT DienThoai.idDienThoai, DienThoai.TenDienThoai, DienThoai.TenHangDT, DienThoai.MauSac, DienThoai.DungLuong, DienThoai.GiaBan, ChiTietHoaDon.SoLuong
        FROM DienThoai, ChiTietHoaDon
        WHERE ChiTietHoaDon.idDienThoai = DienThoai.idDienThoai AND ChiTietHoaDon.idHD = @id_hoadon;
    END;
END;



create or alter procedure proc_giohang
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


CREATE OR ALTER PROCEDURE proc_timkiemhoadon_date_and_status
(
    @date nvarchar(max),
    @status nvarchar(max)
)
AS
BEGIN
    IF @date IS NOT NULL AND @status IS NOT NULL
    BEGIN
        SELECT *
        FROM v_hoadon
        WHERE v_hoadon.Ngay = @date AND v_hoadon.TrangThai = @status;
    END
    ELSE IF @date IS NOT NULL
    BEGIN
        SELECT *
        FROM v_hoadon
        WHERE v_hoadon.Ngay = @date;
    END
    ELSE IF @status IS NOT NULL
    BEGIN
        SELECT *
        FROM v_hoadon
        WHERE v_hoadon.TrangThai = @status;
    END
END;


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


create or alter procedure proc_lichsumuahang
(
	@id_kh nvarchar(max)
)
as
begin
	if @id_kh is not null
	begin
		SELECT HoaDon.Ngay,DienThoai.TenDienThoai,DienThoai.MauSac,DienThoai.DungLuong,ChiTietHoaDon.SoLuong,ChiTietHoaDon.TongTien
		FROM KhachHang 
		join ChiTietHoaDon ON KhachHang.idKH = ChiTietHoaDon.idKH 
		join DienThoai ON DienThoai.idDienThoai = ChiTietHoaDon.idDienThoai
		join HoaDon ON HoaDon.idHD = ChiTietHoaDon.idHD
		WHERE KhachHang.idKH = @id_kh
	end;
end;



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



CREATE PROCEDURE proc_InsertOrUpdateDienThoai
    @idDienThoai nchar(10),
    @TenDienThoai nvarchar(255),
    @TenHangDT nvarchar(255),
    @MauSac nvarchar(255),
    @DungLuong nvarchar(255),
    @GiaBan float,
    @SoLuong float,
    @TinhTrang nvarchar(255),
    @HinhAnh varbinary(max)
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
            TinhTrang = @TinhTrang,
            HinhAnh = @HinhAnh
        WHERE idDienThoai = @idDienThoai;
    END
    ELSE
    BEGIN
        -- Bản ghi chưa tồn tại, thực hiện INSERT
        INSERT INTO DienThoai (idDienThoai, TenDienThoai, TenHangDT, MauSac, DungLuong, GiaBan, SoLuong, TinhTrang, HinhAnh)
        VALUES (@idDienThoai, @TenDienThoai, @TenHangDT, @MauSac, @DungLuong, @GiaBan, @SoLuong, @TinhTrang, @HinhAnh);
    END;
END;