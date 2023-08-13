-- Bùi Duy Thanh_20211TT0660
create database QuanLyThuVien

drop database QuanLyThuVien
-- NHAN VIEN --
create table NhanVien
(
MaNhanVien nvarchar (20) primary key,
HoTenNV nvarchar (30),
NgaySinh date,
GioiTinh nvarchar (10),
DienThoai varchar (20)
)

-- THE THU VIEN--
create table TheThuVien
(
MaTheThuVien nvarchar (20) primary key,
HoTenDocGia nvarchar (30),
NgaySinh date,
GioiTinh nvarchar (10),
MaSach nvarchar (20),
MaNhanVien nvarchar (20)
)

-- SACH --
create table Sach
(
MaSach nvarchar (20) primary key,
TenSach nvarchar (50),
NamXuatBan int,
MaNXB nvarchar (20),
MaTheLoai nvarchar (20),
MaTacGia nvarchar (20)
)

-- TAC GIA --
create table TacGia
(
MaTacGia nvarchar (20) primary key,
HoTenTG nvarchar (30)
)

-- NHA XUAT BAN --
create table NhaXuatBan
(
MaNXB nvarchar (20) primary key,
TenNXB nvarchar (30),
SoDienThoai varchar (20)
)

-- THE LOAI SACH --
create table TheLoaiSach
(
MaTheLoai nvarchar (20) primary key,
TenTheThoai nvarchar (20),
)

-- MUON SACH --
create table MuonSach
(
MaMuonSach nvarchar (20) primary key,
MaTheThuVien nvarchar (20),
HoTenDocGia nvarchar (30),
MaSach nvarchar (20),
MaNhanVien nvarchar (20),
NgayMuon date,
NgayTra date,
TrangThai nvarchar (20)
)

-- TRA SACH --
create table TraSach
(
MaTraSach nvarchar (20) primary key,
MaMuonSach nvarchar (20),
MaTheThuVien nvarchar (20),
HoTenDocGia nvarchar (30),
MaSach nvarchar (20),
MaNhanVien nvarchar (20),
NgayDuTra date,
NgayThucTra date,
SoNgayQuaHan int,
TienPhat int
)

-- KHOA NGOAI SACH --

alter table TheThuVien
add constraint FK_TheThuVien_Sach
foreign key (MaSach) 
references Sach (MaSach)

alter table TheThuVien
add constraint FK_TheThuVien_NhanVien
foreign key (MaNhanVien) 
references NhanVien (MaNhanVien)

-- KHOA NGOAI SACH --
alter table Sach
add constraint FK_Sach_TheLoai
foreign key (MaTheLoai) 
references TheLoaiSach (MaTheLoai)
--select * from TheLoaiSach

alter table Sach
add constraint FK_Sach_NXB
foreign key (MaNXB) 
references NhaXuatBan (MaNXB)

alter table Sach
add constraint FK_Sach_TacGia
foreign key (MaTacGia) 
references TacGia (MaTacGia)

-- KHOA NGOAI MUON SACH -- 
alter table MuonSach
add constraint FK_MuonSach_TheThuVien
foreign key (MaTheThuVien) 
references TheThuVien (MaTheThuVien)

alter table MuonSach
add constraint FK_MuonSach_Sach
foreign key (MaSach) 
references Sach (MaSach)

alter table MuonSach
add constraint FK_MuonSach_NhanVien
foreign key (MaNhanVien) 
references NhanVien (MaNhanVien)

-- KHOA NGOAI TRA SACH -- 
alter table TraSach
add constraint FK_TraSach_TheThuVien
foreign key (MaTheThuVien) 
references TheThuVien (MaTheThuVien)

alter table TraSach
add constraint FK_TraSach_Sach
foreign key (MaSach) 
references Sach (MaSach)

alter table TraSach
add constraint FK_TraSach_NhanVien
foreign key (MaNhanVien) 
references NhanVien (MaNhanVien)

------ 
--INSERT INTO NHANVIEN (MANHANVIEN, HOTENNV, NGAYSINH, GIOITINH, DIENTHOAI)
--VALUES('NV1', N'Nguyễn Văn A', '2-2-2000', 'Nam', 355555558),
--('NV2', N'Nguyễn Thị Hà', '6-23-1996', N'Nữ', 389998777),
--('NV3', N'Nguyễn Anh Dũng', '5-1-2001', 'Nam', 377778889)

--INSERT INTO NHAXUATBAN (MANXB, TENNXB, SODIENTHOAI) 
--VALUES ('NXB1', N'Nguyễn Văn Nam', 123456789),
--('NXB2', N'Nguyễn Thị Hà', 123456788)

--INSERT INTO TACGIA(MaTacGia, HoTenTG)
--VALUES ('TG1', N'Trần Cường'),
--('TG2', N'Trần Hạ')

--INSERT INTO TheLoaiSach(MATHELOAI, TENTHETHOAI)
--VALUES ('TL1', N'Truyện'),
--('TL2', N'Khoa học')

--INSERT INTO Sach(MaSach, TenSach, NamXuatBan, MaNXB, MaTheLoai, MaTacGia)
--VALUES ('S1', N'Lịch sử', '1900', 'NXB1', 'TL1', 'TG1')

--INSERT INTO TheThuVien(MaTheThuVien, HoTenDocGia, NgaySinh, GioiTinh, MaSach,MaNhanVien)
--VALUES('TV1', N'Nguyễn A', '2-2-1998', 'Nam', 'S1','NV1')

------- NHA XUAT BAN -------
create Proc layNXB
as Begin
	select * from NhaXuatBan
end
go
-- DROP PROCEDURE IF EXISTS layNXB;
CREATE PROC ThemNXB(@MaNXB nvarchar(20), @TenNXB nvarchar(30), @SoDienThoai int)
AS
INSERT INTO NhaXuatBan(MaNXB, TenNXB, SoDienThoai)
VALUES(@MaNXB, @TenNXB, @SoDienThoai)
GO

CREATE PROC SuaNXB (@MaNXB nvarchar(20), @TenNXB nvarchar(30), @SoDienThoai int)
AS
UPDATE NhaXuatBan
SET TenNXB=@TenNXB,SoDienThoai=@SoDienThoai
WHERE MaNXB=@MaNXB
GO

CREATE PROC XoaNXB(@MaNXB nvarchar(20))
AS
DELETE 
FROM NhaXuatBan
Where MaNXB=@MaNXB
GO
-- CHECK TON TAI NHA XUAT BAN -- 
CREATE PROC checkTonTaiNXB(@MaNXB nvarchar(20))
AS
SELECT *
FROM NhaXuatBan
Where MaNXB = @MaNXB
GO
------- TAC GIA -------
create Proc hienThiTacGia
as Begin
	select * from TacGia
end;
GO

CREATE PROC ThemTacGia(@MaTacGia nvarchar(20), @HoTenTG nvarchar(30))
AS
INSERT INTO TacGia(MaTacGia, HoTenTG)
VALUES(@MaTacGia, @HoTenTG)
GO

CREATE PROC SuaTacGia(@MaTacGia nvarchar(20), @HoTenTG nvarchar(30))
AS
UPDATE TacGia
SET HoTenTG=@HoTenTG
WHERE MaTacGia= @MaTacGia
GO

CREATE PROC XoaTacGia(@MaTacGia nvarchar(20))
AS
DELETE 
FROM TacGia
Where MaTacGia= @MaTacGia
GO

-- CHECK TON TAI TAC GIA -- 
CREATE PROC checkTonTaiTacGia(@MaTacGia nvarchar(20))
AS
SELECT *
FROM TacGia
Where MaTacGia = @MaTacGia
GO
------- THE LOAI -------
create Proc hienThiTheLoai
as Begin
	select * from TheLoaiSach 
end;
GO

CREATE PROC ThemTheLoai(@MaTheLoai nvarchar(20), @TenTheThoai nvarchar(20))
AS
INSERT INTO TheLoaiSach(MaTheLoai, TenTheThoai)
VALUES(@MaTheLoai, @TenTheThoai)
GO

CREATE PROC SuaTheLoai(@MaTheLoai nvarchar(20), @TenTheThoai nvarchar(20))
AS
UPDATE TheLoaiSach
SET TenTheThoai=@TenTheThoai
WHERE MaTheLoai= @MaTheLoai
GO

CREATE PROC XoaTheLoai(@MaTheLoai nvarchar(20))
AS
DELETE 
FROM TheLoaiSach
Where MaTheLoai= @MaTheLoai
GO

-- CHECK TON TAI THE LOAI -- 
CREATE PROC checkTonTai(@MaTheLoai nvarchar(20))
AS
SELECT *
FROM TheLoaiSach
Where MaTheLoai= @MaTheLoai
GO

------- SACH -------
create Proc hienThiSach
as Begin
	select * from Sach 
end;
GO
-- check ton tai sach -- 
CREATE PROC checkTonTaiSach(@MaSach nvarchar(20))
AS
SELECT *
FROM Sach
Where MaSach = @MaSach
GO

CREATE PROC SuaSach(@MaSach nvarchar(20), @TenSach nvarchar(50), @NamXuatBan int, @MaNXB nvarchar (20), @MaTheLoai nvarchar (20), @MaTacGia nvarchar (20))
AS
UPDATE Sach
SET TenSach = @TenSach, NamXuatBan = @NamXuatBan, MaNXB= @MaNXB, MaTheLoai = @MaTheLoai, MaTacGia= @MaTacGia
WHERE MaSach= @MaSach
GO

CREATE PROC ThemSach (@MaSach nvarchar(20), @TenSach nvarchar(50), @NamXuatBan int, @MaNXB nvarchar (20), @MaTheLoai nvarchar (20), @MaTacGia nvarchar (20))
AS
INSERT INTO Sach(MaSach, TenSach, NamXuatBan, MaNXB, MaTheLoai, MaTacGia)
VALUES(@MaSach, @TenSach,@NamXuatBan,@MaNXB,@MaTheLoai,@MaTacGia)
GO
CREATE PROC XoaSach(@MaSach nvarchar(20))
AS
DELETE 
FROM Sach
Where MaSach= @MaSach
GO
-- Tìm sách
CREATE PROC TimSach(@TenSach nvarchar(20))
AS
SELECT *
FROM Sach
Where  LOWER(TenSach) LIKE '%' + LOWER(TRIM(@TenSach)) + '%'
GO

--------- NHAN VIEN ---------
create Proc hienThiNhanVien
as Begin
	select * from NhanVien 
end;
GO

CREATE PROC checkTonTaiNhanVien(@MaNhanVien nvarchar(20))
AS
SELECT *
FROM NhanVien
Where MaNhanVien = @MaNhanVien
GO

CREATE PROC ThemNhanVien(@MaNhanVien nvarchar(20), @HoTenNV nvarchar (20), @NgaySinh date, @GioiTinh nvarchar (10), @DienThoai varchar(20))
AS
INSERT INTO NhanVien(MaNhanVien, HoTenNV,NgaySinh,GioiTinh,DienThoai)
VALUES(@MaNhanVien, @HoTenNV,@NgaySinh,@GioiTinh,@DienThoai)
GO

CREATE PROC SuaNhanVien(@MaNhanVien nvarchar(20), @HoTenNV nvarchar (20), @NgaySinh date, @GioiTinh nvarchar (10), @DienThoai varchar(20))
AS
UPDATE NhanVien
SET HoTenNV = @HoTenNV, NgaySinh = @NgaySinh, GioiTinh= @GioiTinh, DienThoai = @DienThoai
WHERE MaNhanVien= @MaNhanVien
GO

CREATE PROC XoaNhanVien(@MaNhanVien nvarchar(20))
AS
DELETE 
FROM NhanVien
Where MaNhanVien= @MaNhanVien
GO

---- THE THU VIEN ------
create Proc hienThiTheThuVien
as Begin
	select * from TheThuVien
end;
GO

CREATE PROC checkTonTaiTheThuVien(@MaTheThuVien nvarchar(20))
AS
SELECT *
FROM TheThuVien
Where MaTheThuVien = @MaTheThuVien
GO

CREATE PROC ThemTheThuVien(@MaTheThuVien nvarchar(20), @HoTenDocGia nvarchar (30), @NgaySinh date, @GioiTinh nvarchar (10), @MaSach nvarchar (20), @MaNhanVien nvarchar(20))
AS
INSERT INTO TheThuVien (MaTheThuVien, HoTenDocGia, NgaySinh, GioiTinh, MaSach, MaNhanVien)
VALUES(@MaTheThuVien, @HoTenDocGia, @NgaySinh, @GioiTinh, @MaSach, @MaNhanVien)
GO

CREATE PROC SuaTheThuVien(@MaTheThuVien nvarchar(20), @HoTenDocGia nvarchar (30), @NgaySinh date, @GioiTinh nvarchar (10), @MaSach nvarchar (20), @MaNhanVien nvarchar(20))
AS
UPDATE TheThuVien
SET HoTenDocGia = @HoTenDocGia, NgaySinh = @NgaySinh, GioiTinh= @GioiTinh, MaSach = @MaSach, MaNhanVien=  @MaNhanVien
WHERE MaTheThuVien= @MaTheThuVien
GO

CREATE PROC XoaTheThuVien(@MaTheThuVien nvarchar(20))
AS
DELETE 
FROM TheThuVien
Where MaTheThuVien= @MaTheThuVien
GO

------ MUON SACH -------
create Proc hienThiMuonSach
as Begin
	select * from MuonSach
end;
GO

CREATE PROC checkTonTaiMuonSach(@MaMuonSach nvarchar(20))
AS
SELECT *
FROM MuonSach
Where MaMuonSach = @MaMuonSach and  TrangThai = N'Đang mượn'
GO


CREATE PROC ThemMuonSach(@MaMuonSach nvarchar (20), @MaTheThuVien nvarchar (20), @HoTenDocGia nvarchar (30),
@MaSach nvarchar (20), @MaNhanVien nvarchar (20), @NgayMuon date, @NgayTra date, @TrangThai nvarchar (20))
AS
INSERT INTO MuonSach (MaMuonSach , MaTheThuVien , HoTenDocGia , MaSach , MaNhanVien , NgayMuon, NgayTra, TrangThai)
VALUES(@MaMuonSach, @MaTheThuVien, @HoTenDocGia, @MaSach, @MaNhanVien, @NgayMuon, @NgayTra, @TrangThai)
GO

CREATE PROC LayTenDocGia (@MaTheThuVien nvarchar (20))
AS
select MaTheThuVien, HoTenDocGia from TheThuVien
where MaTheThuVien = @MaTheThuVien
GO


------ TRA SACH -------

create Proc hienThiTraSach
as Begin
	select * from TraSach
end;
GO

CREATE PROC checkTonTaiTraSach(@MaTraSach  nvarchar(20))
AS
SELECT *
FROM TraSach
Where MaTraSach  = @MaTraSach
GO

CREATE PROC ThemTraSach(@MaTraSach nvarchar (20), @MaMuonSach nvarchar (20), @MaTheThuVien nvarchar (20), @HoTenDocGia nvarchar (30),
@MaSach nvarchar (20), @MaNhanVien nvarchar (20), @NgayDuTra date, @NgayThucTra date, @SoNgayQuaHan int, @TienPhat int)
AS
INSERT INTO TraSach (MaTraSach  , MaMuonSach  , MaTheThuVien  , HoTenDocGia  , MaSach  , MaNhanVien , NgayDuTra , NgayThucTra, SoNgayQuaHan, TienPhat)
VALUES(@MaTraSach, @MaMuonSach, @MaTheThuVien, @HoTenDocGia, @MaSach, @MaNhanVien, @NgayDuTra, @NgayThucTra, @SoNgayQuaHan, @TienPhat)
GO

CREATE PROC layTenMuonSach (@MaMuonSach nvarchar (20))
AS
select * from MuonSach
where MaMuonSach = @MaMuonSach and TrangThai = N'Đang mượn'
GO

CREATE PROC SuaTrangThai(@MaMuonSach nvarchar (20))
AS
UPDATE MuonSach
SET TrangThai = N'Đã trả'
WHERE MaMuonSach = @MaMuonSach
GO

------ THONG KE --------

CREATE PROC SachDangDuocMuon
AS
select MuonSach.HoTenDocGia, MuonSach.MaSach, Sach.TenSach, Sach.NamXuatBan,TacGia.HoTenTG
from MuonSach, Sach , TacGia
where MuonSach.MaSach = Sach.MaSach and Sach.MaTacGia = TacGia.MaTacGia and TrangThai = N'Đang mượn'
GO

CREATE PROC DocGiaQuaHanTraSach
AS
select MuonSach.HoTenDocGia, MuonSach.MaSach, Sach.TenSach, MuonSach.NgayTra, DATEDIFF(day,MuonSach.NgayTra,GetDate()) as 'Số ngày quá hạn'
from MuonSach, Sach , TacGia
where MuonSach.MaSach = Sach.MaSach and Sach.MaTacGia = TacGia.MaTacGia and MuonSach.NgayTra < GETDATE() and TrangThai = N'Đang mượn'
GO
drop PROC DocGiaQuaHanTraSach

CREATE PROC ReportSach
AS
select * from Sach
GO