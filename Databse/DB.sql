--tạo database
create database BMCSDL_QLSinhVien
go
use BMCSDL_QLSinhVien
go
create table SinhVien
(
	MaSV nvarchar(20) primary key,
	HoTen nvarchar(100) not null,
	NgaySinh Datetime,
	DiaChi nvarchar(200),
	TenDN nvarchar(100) not null,
	MatKhau varbinary not null
)
go
create table NhanVien
(
	MaNV nvarchar(20) primary key,
	HoTen nvarchar(100) not null,
	Email nvarchar(20),
	Luong varbinary,
	TenDN nvarchar(100) not null unique,
	MatKhau varbinary not null,
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

--