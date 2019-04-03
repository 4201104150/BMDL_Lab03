/*---------------------------------------------------------- 
MASV : 42.01.104.076 - Nguyễn Sơn Lâm 
		42.01.104.099 - Trần Thị Yến Nhi
		42.01.104.129 - Nguyễn Như Quỳnh
		42.01.104.167 - Đỗ Thị Thanh Thi
		42.01.104.150 - Nguyễn Văn Tuấn 
LAB: 03 - NHOM 
NGAY:  1/4/2019
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
NGAY:  1/4/2019
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
NGAY:  1/4/2019
----------------------------------------------------------*/ 
-- i) Stored dùng để thêm mới dữ liệu (Insert) vào table NHANVIEN 
SELECT * FROM sys.symmetric_keys 

--i)

CREATE MASTER KEY ENCRYPTION BY   
PASSWORD = 'MAHOA';

drop Master key	

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

	DECLARE @MAHOAMATKHAU VARBINARY(500)
	SET @MAHOAMATKHAU = HASHBYTES('SHA1', @MATKHAU);

	DECLARE @TAOKHOA NVARCHAR(MAX) = '
	CREATE ASYMMETRIC KEY MAHOALUONG'+@TENDN+'
	WITH ALGORITHM = RSA_512
	encryption by password = '''+@MATKHAU+'''';
	EXECUTE(@TAOKHOA)
	INSERT INTO NHANVIEN
	VALUES (@MANV,@HOTEN,@EMAIL,ENCRYPTBYASYMKEY(ASYMKEY_ID('MAHOALUONG'+@TENDN),@LUONG),@TENDN,@MAHOAMATKHAU,@MANV)
END
GO

EXEC SP_INS_PUBLIC_NHANVIEN 'NV01', 'NGUYEN VAN A', 'NVA@',3000000, 'NVA', 'abcd12'

select * from NHANVIEN where MANV = 'NV01'

drop proc SP_INS_PUBLIC_NHANVIEN

 


--ii)

/* TRUY XUAT NHANVIEN*/
CREATE PROC SP_SEL_PUBLIC_NHANVIEN @TENDN VARCHAR(20), @MATKHAU NVARCHAR(100)
AS
BEGIN
	DECLARE @CHECKMATKHAU NVARCHAR(20) 
	SELECT @CHECKMATKHAU = MATKHAU FROM NHANVIEN WHERE TENDN = @TENDN;
	IF(HASHBYTES('SHA1',@MATKHAU) = @CHECKMATKHAU)
		BEGIN
			SELECT MANV, HOTEN , EMAIL,CONVERT(VARCHAR(200),DECRYPTBYASYMKEY(ASYMKEY_ID('MAHOALUONG'+@TENDN),LUONG,@MATKHAU)) as LUONGCB FROM NHANVIEN WHERE TENDN=@TENDN
		END
	ELSE
		BEGIN
			PRINT('KHONG TON TAI MAT KHAU');
		END
END

EXEC SP_SEL_PUBLIC_NHANVIEN 'NVA', 'abcd12'

--SELECT * FROM NHANVIEN WHERE MANV = 'NV01'

DROP PROCEDURE SP_SEL_PUBLIC_NHANVIEN

--
create procedure XLDN @Username nvarchar(100), @Password varchar(20)
as
begin
	select * from NHANVIEN where TENDN=@Username and MATKHAU=HASHBYTES('SHA1',@Password)
end

drop proc XLDN
select * from NHANVIEN

select HASHBYTES('SHA1','abcd12')

exec XLDN 'NVA','abcd12'

create procedure xlThemLopHocPhan01
@malop varchar(20),
@tenlop nvarchar(100),
@manv varchar(20)
as
begin
--	if exists (select * from HOCPHAN where MAHP=@malop)
--	begin
		insert into HOCPHAN values (@malop,@tenlop,@manv)
--	end
end

exec xlThemLopHocPhan01 'BMCSDL',N'Bảo mật cơ sở dữ liệu',3
exec xlThemLopHocPhan01 'BMANM',N'Bảo mật an nin mạng',2
exec xlThemLopHocPhan01 'LTDT',N'Lý thuyết đồ thị',3

select * from LOP

drop proc xlThemLopHocPhan01

create procedure xlNhapDiem @masv nvarchar(100), @mahp nvarchar(100),@diemthi varchar(20),@publickey varchar(100)
as
begin
	begin try
	 insert into BANGDIEM values (@masv,@mahp,ENCRYPTBYASYMKEY(ASYMKEY_ID('MAHOALUONG'+@publickey),@diemthi));
	end try
	begin catch
		rollback tran
	end catch
end

exec  xlNhapDiem 'SV01','BMCSDL','9','NV01'

drop proc xlNhapDiem

create procedure SP_INS_SINHVIEN
(@masv nvarchar(20),@hoten nvarchar(100),@ngaysinh datetime,@diachi nvarchar(200),@malop varchar(10),@tendn nvarchar(20),@matkhau nvarchar(16))
as
begin
	set nocount on
	begin try
		insert into SINHVIEN values (@masv,@hoten,@ngaysinh,@diachi,@malop,@tendn,HASHBYTES('MD5',@matkhau))
	end try
	begin catch
        rollback tran
		return
    end catch
end
drop proc SP_INS_SINHVIEN

exec SP_INS_SINHVIEN 'SV01', 'NGUYEN VAN Aa', '1/1/1990', '280 AN DUONG VUONG', 'CNTT-T', 'NVaa', '123456'
exec SP_INS_SINHVIEN 'SV02', 'NGUYEN VAN Bb', '1/1/1990', '280 AN DUONG VUONG', 'CNTT-T', 'NVbb', '123456'

create procedure xlXemDiemThi @manv varchar(20),@pass nvarchar(20)
as
begin
	select a.MASV,b.HOTEN,CONVERT(VARCHAR(200),DECRYPTBYASYMKEY(ASYMKEY_ID('MAHOALUONG'+@manv),a.DIEMTHI,@pass))  from BANGDIEM a,SINHVIEN b,LOP c,NHANVIEN d where a.MASV=b.MASV and c.MANV=d.MANV and c.MALOP=b.MALOP and d.MANV=@manv
end
--update sv
create procedure xlUpdateSV
(@masv varchar(10), @hoten nvarchar(100),@ngaysinh datetime,@diachi nvarchar(200),@malop varchar(10),@matkhau nvarchar(16))
as
begin
	set nocount on
	begin try
		update  SINHVIEN set HOTEN=@hoten,NGAYSINH=@ngaysinh,DIACHI=@diachi,MALOP=@malop,MATKHAU=HASHBYTES('MD5',@matkhau) where MASV=@masv
	end try
	begin catch
        rollback tran
		return
    end catch
end

create procedure xlXemDSSV @manv varchar(20)
as
begin
	select a.MASV,a.NGAYSINH,a.DIACHI,a.TENDN From SINHVIEN a,LOP b,NHANVIEN c where a.MALOP=b.MALOP and b.MANV=c.MANV and c.MANV=@manv;
end
