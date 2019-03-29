/*---------------------------------------------------------- 
MASV : 42.01.104.076 - Nguyễn Sơn Lâm 
		42.01.104.099 - Trần Thị Yến Nhi
		42.01.104.129 - Nguyễn Như Quỳnh
		42.01.104.167 - Đỗ Thị Thanh Thi
		42.01.104.150 - Nguyễn Văn Tuấn 
LAB: 03 - NHOM 
NGAY:  4/5/2019
----------------------------------------------------------*/ 
--tạo database
create database BMCSDL_QLSinhVien
go
use BMCSDL_QLSinhVien
go

/*---------------------------------------------------------- 
MASV : 42.01.104.076 - Nguyễn Sơn Lâm 
		42.01.104.099 - Trần Thị Yến Nhi
		42.01.104.129 - Nguyễn Như Quỳnh
		42.01.104.167 - Đỗ Thị Thanh Thi
		42.01.104.150 - Nguyễn Văn Tuấn 
LAB: 03 - NHOM 
NGAY:  4/5/2019
----------------------------------------------------------*/ 
create table NhanVien
(
	MaNV nvarchar(20) primary key,
	HoTen nvarchar(100) not null,
	Email nvarchar(20),
	Luong varbinary(MAX),
	TenDN nvarchar(100) not null unique,
	MatKhau varbinary(MAX) not null,
	--khóa công khai
	PubKey varchar(20)
)

go
create table Lop
(
	MaLop varchar(20) primary key,
	TenLop nvarchar(100) not null,
	MaNV nvarchar(20) foreign key (MaNV) REFERENCES NhanVien(MaNV)
)
go

create table SinhVien
(
	MaSV nvarchar(20) primary key,
	HoTen nvarchar(100) not null,
	NgaySinh Datetime,
	DiaChi nvarchar(200),
	MaLop varchar(20) foreign key (MaLop) references Lop(MaLop),
	TenDN nvarchar(100) not null,
	MatKhau varbinary not null
)
go

create table HocPhan
(
	MaHP varchar(20) primary key,
	TenHP nvarchar(100) not null,
	SoTC int 
)
go
create table BangDiem
(
	MaSV nvarchar(20) foreign key(MaSV) references SinhVien(MaSV),
	MaHP varchar(20) foreign key (MaHP) references HocPhan(MaHP),
	DiemThi varbinary --Phải mã hóa
)
/*---------------------------------------------------------- 
MASV : 42.01.104.076 - Nguyễn Sơn Lâm 
		42.01.104.099 - Trần Thị Yến Nhi
		42.01.104.129 - Nguyễn Như Quỳnh
		42.01.104.167 - Đỗ Thị Thanh Thi
		42.01.104.150 - Nguyễn Văn Tuấn 
LAB: 03 - NHOM 
NGAY:  4/5/2019
----------------------------------------------------------*/ 
-- i) Stored dùng để thêm mới dữ liệu (Insert) vào table NHANVIEN 
SELECT * FROM sys.symmetric_keys 

--tạo master key
CREATE MASTER KEY ENCRYPTION BY PASSWORD = '123';

-- tạo khóa ASYMMETRIC

CREATE PROCEDURE SP_INS_PUBLIC_NHANVIEN
(
	@manv varchar(20),
	@hoten nvarchar(100),
	@email varchar(20),
	@luongcb varchar(200),
	@tendn nvarchar(100),
	@matkhau varchar(200)
)
as
begin 
	DECLARE @MAHOA NVARCHAR(MAX) = 
	'CREATE ASYMMETRIC KEY MaHoaLuong
		WITH ALGORITHM = RSA_512
		ENCRYPTION BY PASSWORD = '''+@matkhau+''''
    EXEC(@MAHOA)
	declare @luong varbinary(MAX), @mk varbinary(MAX)
	insert into NhanVien(MaNV,HoTen,Email,Luong,TenDN,MatKhau,PubKey)
	values (@manv,@hoten,@email,ENCRYPTBYASYMKEY(ASYMKEY_ID('MaHoaLuong'),CONVERT(varbinary,@luongcb)),@tendn,HASHBYTES('SHA1',CONVERT(varbinary,@matkhau)),@manv)
end

--
DROP ASYMMETRIC KEY MaHoaLuong

drop procedure SP_INS_PUBLIC_NHANVIEN
--
exec SP_INS_PUBLIC_NHANVIEN 'NV04', 'NGUYEN VAN C', 'NVC@', '3000000', 'NVC', 'abcd14'
EXEC SP_INS_PUBLIC_NHANVIEN 'NV01', 'NGUYEN VAN A', 'NVA@', 3000000, 'NVA', 'abcd12' 

Select * from NhanVien

---ii))Stored dùng để truy vấn dữ liệu nhân viên (NHANVIEN) 

create procedure SP_SEL_PUBLIC_NHANVIEN 
	@tendn nvarchar(100), 
	@mk varchar(200)
as
begin
	declare @matkhau varbinary(200)
	select @matkhau = CONVERT(varbinary(200),@mk)
	Select MaNV, HoTen, Email, CONVERT(varchar(200),DECRYPTBYASYMKEY(ASYMKEY_ID('MaHoaLuong'),Luong)) as LUONGCB
	from NhanVien where TenDN = @tendn and MatKhau = @matkhau
end

drop procedure SP_SEL_PUBLIC_NHANVIEN

exec SP_SEL_PUBLIC_NHANVIEN 'NVA', 'abcd12'

select * from NhanVien