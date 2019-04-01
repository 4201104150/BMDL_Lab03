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
create table NHANVIEN
(
	MANV varchar(20),
	HOTEN nvarchar(100) not null,
	EMAIL varchar(20),
	LUONG varbinary(200),
	TENDN nvarchar(100) not null,
	MATKHAU varbinary(200) not null,
	PUBKEY varchar(20),
	constraint pk_nv primary key (MANV),
)
go
create table LOP
(
	MALOP varchar(20),
	TENLOP nvarchar(100) not null,
	MANV varchar(20),
	constraint pk_lop primary key (MALOP),
	constraint fk_lop_nv foreign key (MANV) references NHANVIEN(MANV),
)
go

create table SINHVIEN
(
	MASV nvarchar(20),
	HOTEN nvarchar(100) not null,
	NGAYSINH datetime,
	DIACHI nvarchar(200),
	MALOP varchar(20),
	TENDN nvarchar(100) not null,
	MATKHAU varbinary(200) not null,
	constraint pk_sv primary key (MASV),
	constraint fk_sv_lop foreign key (MALOP) references LOP(MALOP),
)
go

create table HOCPHAN
(
	MAHP varchar(20),
	TENHP  nvarchar(100) not null,
	SOTC int
	constraint pk_hp primary key (MAHP),
)
go
create table BANGDIEM
(
	MASV nvarchar(20),
	MAHP varchar(20),
	DIEMTHI varbinary(200),
	constraint pk_bd primary key (MASV,MAHP),
	constraint fk_bd_sv foreign key (MASV) references SINHVIEN(MASV),
	constraint fk_bd_hp foreign key (MAHP) references HOCPHAN(MAHP),
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
/*CREATE MASTER KEY ENCRYPTION BY PASSWORD = '123';
--drop  MASTER KEY ENCRYPTION

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
	select @mk = CONVERT(varbinary(200),@matkhau)
	select @luong = CONVERT(varbinary(200),@luongcb)
	insert into NhanVien(MaNV,HoTen,Email,Luong,TenDN,MatKhau,PubKey)
	values (@manv,@hoten,@email,ENCRYPTBYASYMKEY(ASYMKEY_ID('MaHoaLuong'),@luong),@tendn,HASHBYTES('SHA1',@mk),@manv)
end

--
DROP ASYMMETRIC KEY MaHoaLuong

drop procedure SP_INS_PUBLIC_NHANVIEN

--
*/

--i)

CREATE MASTER KEY ENCRYPTION BY   
PASSWORD = 'MAHOA';


/* TẠO PROCEDURE NHANVIEN*/
CREATE PROC SP_INS_PUBLIC_NHANVIEN
	@MANV NVARCHAR(20),
	@HOTEN NVARCHAR(100),
	@EMAIL VARCHAR(20) ,
	@LUONG VARCHAR(100),
	@TENDN NVARCHAR(100),
	@MATKHAU NVARCHAR(20)	
as
BEGIN 
	PRINT @LUONG

	DECLARE @MAHOAMATKHAU VARBINARY(500)
	SET @MAHOAMATKHAU = HASHBYTES('SHA1', @MATKHAU);
	
	DECLARE @TAOKHOA NVARCHAR(MAX) = '
	CREATE ASYMMETRIC KEY MAHOALUONG'+@MANV+'
	WITH ALGORITHM = RSA_512
	encryption by password = '''+@MATKHAU+'''';
	EXECUTE(@TAOKHOA)
	INSERT INTO NHANVIEN
	VALUES (@MANV,@HOTEN,@EMAIL,ENCRYPTBYASYMKEY(ASYMKEY_ID('MAHOALUONG'+@MANV),@LUONG),@TENDN,@MAHOAMATKHAU,@MANV)
END
GO

EXEC SP_INS_PUBLIC_NHANVIEN 'NV01', 'NGUYEN VAN A', 'NVA@',
3000000, 'NVA', 'abcd12'
select * from NHANVIEN where MANV = 'NV01'


--ii)

/* TRUY XUAT NHANVIEN*/
CREATE PROC SP_SEL_PUBLIC_NHANVIEN @MANV VARCHAR(20), @MATKHAU NVARCHAR(100)
AS
BEGIN
	DECLARE @CHECKMATKHAU NVARCHAR(20) 
	SELECT @CHECKMATKHAU = MATKHAU FROM NHANVIEN WHERE MANV = @MANV;
	IF(HASHBYTES('SHA1',@MATKHAU) = @CHECKMATKHAU)
		BEGIN
			SELECT MANV, HOTEN , EMAIL,CONVERT(VARCHAR(200),DECRYPTBYASYMKEY(ASYMKEY_ID('MAHOALUONG'+@MANV),LUONG,@MATKHAU)) LUONG FROM NHANVIEN WHERE MANV = @MANV
		END
	ELSE
		BEGIN
			PRINT('KHONG TON TAI MAT KHAU');
		END
END

EXEC SP_SEL_PUBLIC_NHANVIEN 'NV01', 'abcd12'

--SELECT * FROM NHANVIEN WHERE MANV = 'NV01'

DROP PROCEDURE SP_SEL_PUBLIC_NHANVIEN