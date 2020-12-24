-- Tạo database - Nếu chưa có thì tạo, nếu đã có xóa database cũ tạo lại.
IF EXISTS(SELECT * FROM sys.databases WHERE name = 'QuanGymChuot')
BEGIN
	USE master;
	ALTER DATABASE QuanGymChuot SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE QuanGymChuot
END
GO
CREATE DATABASE QuanGymChuot
GO

-- Sử dụng database QuanGymChuot cho các câu lệnh truy vấn ở dưới đây.
USE QuanGymChuot
GO

-- [Bảng] Gói ưu đãi
-- Gồm các gói mua theo ngày, tháng hoặc năm.
-- (và mặc định - không mua gói - chỉ tập vài lần)
-- Lưu ý: Nếu muốn xóa bảng này, hãy xóa bảng UserManager trước. Sao lưu dữ liệu trước khi xóa.
---- [Thông báo - Không cần xem ở đây] Kiểm tra bảng. Nếu có thì thông báo.
IF (
	EXISTS(
		SELECT * 
		FROM INFORMATION_SCHEMA.TABLES 
        WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'GoiDichVu'
	)
)
BEGIN
	PRINT(N'Đã có bảng GoiDichVu.')
	PRINT(N'(bỏ qua thông báo này nếu muốn sử dụng table đã có sẵn)')
	PRINT(N'')
END
ELSE
---- [Code chính] Nếu không có thì tạo mới.
CREATE TABLE GoiDichVu (
	-- ID
	ID int primary key NOT NULL IDENTITY(1,1),
	-- Tên gói
	Name nvarchar(max) NOT NULL,
	-- Giá gói
	Price bigint check(Price > 0),
	-- Số ngày (hạn sử dụng) của gói
	DayCount bigint check(DayCount > 0),
	-- Thông tin ưu đãi gói (mô tả)
	Info nvarchar(max),
	-- Được dùng gói này để mua?
	-- (trong trường hợp muốn tắt gói nhưng không ảnh hưởng
	--  đến những người đã mua gói này, và khi hết hạn sẽ
	--  không thể gia hạn thêm).
	CanUse bit NOT NULL DEFAULT 1,
	-- Ngày tạo gói
	AddDate datetime NOT NULL DEFAULT GETDATE()
)
GO

-- [Bảng] Thông tin người dùng
-- Gồm thông tin của người dùng khi đến tập để liên lạc nếu cần thiết.
-- Lưu ý: Nếu muốn xóa bảng này, hãy xóa bảng UserManager trước. Sao lưu dữ liệu trước khi xóa.
---- [Thông báo - Không cần xem ở đây] Kiểm tra bảng. Nếu có thì thông báo.
IF (
	EXISTS(
		SELECT * 
		FROM INFORMATION_SCHEMA.TABLES 
        WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'ThongTinNguoiDung'
	)
)
BEGIN
	PRINT(N'Đã có bảng ThongTinNguoiDung.')
	PRINT(N'(bỏ qua thông báo này nếu muốn sử dụng table đã có sẵn)')
	PRINT(N'')
END
ELSE
---- [Code chính] Nếu không có thì tạo mới.
CREATE TABLE ThongTinNguoiDung (
	-- ID
	ID int primary key NOT NULL IDENTITY(1,1),
	-- Tên người dùng
	Name nvarchar(max) NOT NULL,
	-- Giới tính người dùng
	Gender bit NOT NULL,
	-- SĐT người dùng
	Phone nvarchar(11),
	-- Ngày đăng ký
	RegDate datetime NOT NULL DEFAULT GETDATE()
)
GO

-- [Trigger] Kiểm tra SĐT
----  + Nếu không có Trigger, tạo Trigger mới.
----  + Nếu đã có Trigger này, xóa Trigger cũ và tạo mới.
----  + Nội dung: Nếu SĐT đã nhập nằm trong các trường hợp này thì hoàn tác:
----    - Ít hơn 10 số hay nhiều hơn 11 số.
----    - Không có số 0 ở đầu chuỗi SĐT.
DROP TRIGGER IF EXISTS dbo.ThongTinNguoiDung_Check_Add
GO
CREATE TRIGGER dbo.ThongTinNguoiDung_Check_Add
ON dbo.ThongTinNguoiDung
FOR INSERT
AS
BEGIN
	DECLARE @Phone nvarchar(11)
	SELECT @Phone = Phone FROM INSERTED
	IF (LEN(@Phone) < 10 OR SUBSTRING(@Phone, 1, 1) != N'0')
		ROLLBACK TRANSACTION
END
GO

-- [Bảng] Quản lý lịch sử giao dịch
-- Dữ liệu gồm các gói mà mỗi khách hàng đã mua.
---- [Thông báo - Không cần xem ở đây] Kiểm tra bảng. Nếu có thì thông báo.
IF (
	EXISTS(
		SELECT * 
		FROM INFORMATION_SCHEMA.TABLES 
        WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'QuanLyGiaoDich'
	)
)
BEGIN
	PRINT(N'Đã có bảng QuanLyGiaoDich.')
	PRINT(N'(bỏ qua thông báo này nếu muốn sử dụng table đã có sẵn)')
	PRINT(N'')
END
ELSE
---- [Code chính] Nếu không có thì tạo mới.
CREATE TABLE QuanLyGiaoDich (
	-- ID
	ID int primary key NOT NULL IDENTITY(1,1),
	-- ID người dùng
	UserID int NOT NULL,
	-- ID gói đã mua
	PackID int NOT NULL,
	-- Ngày đăng ký gói
	PackRegDate datetime NOT NULL DEFAULT GETDATE(),
	-- Ngày hết hạn gói
	PackExpDate datetime NOT NULL DEFAULT GETDATE(),
	-- Ghi chú (nếu có)
	Note nvarchar(max),
	-- Liên kết cột UserID với cột ID của bảng ThongTinNguoiDung
	FOREIGN KEY (UserID) REFERENCES ThongTinNguoiDung(ID),
	-- Liên kết cột PackID với cột ID của bảng GoiDichVu
	FOREIGN KEY (PackID) REFERENCES GoiDichVu(ID)
)
GO

-- [Bảng] Thông tin đăng nhập
-- Gồm các thông số kỹ thuật của tài khoản để quản lý.
-- Lưu ý: Hãy đảm bảo bạn đã tạo bảng mới và thêm tài khoản mặc định sau khi xóa bảng này.
--        Nếu không, bạn sẽ không thể đăng nhập.
---- [Thông báo - Không cần xem ở đây] Kiểm tra bảng. Nếu có thì thông báo.
IF (
	EXISTS(
		SELECT * 
		FROM INFORMATION_SCHEMA.TABLES 
        WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'ThongTinDangNhap'
	)
)
BEGIN
	PRINT(N'Đã có bảng ThongTinDangNhap.')
	PRINT(N'(bỏ qua thông báo này nếu muốn sử dụng table đã có sẵn)')
	PRINT(N'')
END
ELSE
---- [Code chính] Nếu không có thì tạo mới.
CREATE TABLE ThongTinDangNhap (
	ID bigint primary key NOT NULL IDENTITY(1,1),
	Username nvarchar(max) NOT NULL,
	Password nvarchar(max) NOT NULL,
	Enabled bit NOT NULL DEFAULT 1,
	DateCreated date NOT NULL DEFAULT GETDATE()
)
GO

-- [Trigger] Kiểm tra tồn tại tài khoản
--    + Nếu không có Trigger, tạo Trigger mới.
--    + Nếu đã có Trigger này, xóa Trigger cũ và tạo mới.
--    + Nội dung: Kiểm tra tồn tại tên đăng nhập
--      - Nếu đã có tài khoản, hủy bỏ quá trình.
DROP TRIGGER IF EXISTS dbo.ThongTinDangNhap_Check_Add
GO
CREATE TRIGGER ThongTinDangNhap_Check_Add
ON dbo.ThongTinDangNhap
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @Username nvarchar(max)
	DECLARE @Password nvarchar(max)
	SELECT @Username = Username, @Password = Password FROM inserted
	IF (EXISTS(SELECT ID FROM dbo.ThongTinDangNhap WHERE Username = @Username))
	-- SELECT * FROM dbo.ThongTinDangNhap WHERE Username = N'admin'
		ROLLBACK TRANSACTION
	ELSE 
	INSERT INTO dbo.ThongTinDangNhap(Username, Password)
	VALUES (@Username, @Password)
END
GO

-- =============================================================================================

-- Tạo dữ liệu mẫu từ bảng GoiDichVu
-- (các gói có thể mua)
DELETE FROM GoiDichVu
GO
INSERT INTO GoiDichVu (Name, Price, DayCount, Info)
VALUES ('Gói 3 ngày', 5000, 3, '(no more information)')
GO
INSERT INTO GoiDichVu (Name, Price, DayCount, Info)
VALUES ('Gói 7 ngày', 15000, 7, '(no more information)')
GO
INSERT INTO GoiDichVu (Name, Price, DayCount, Info)
VALUES ('Gói 1 tháng (30 ngày)', 50000, 30, '(no more information)')
GO
INSERT INTO GoiDichVu (Name, Price, DayCount, Info)
VALUES ('Gói 3 tháng (90 ngày)', 150000, 90, '(no more information)')
GO

-- Tạo dữ liệu mẫu từ bảng ThongTinNguoiDung
-- (người dùng đã đăng ký)
DELETE FROM ThongTinNguoiDung
GO
INSERT INTO ThongTinNguoiDung (Name, Gender, Phone)
VALUES ('Name 1', 1, '0123456789')
GO
INSERT INTO ThongTinNguoiDung (Name, Gender, Phone)
VALUES ('Name 2', 0, '0321323219')
GO
INSERT INTO ThongTinNguoiDung (Name, Gender, Phone)
VALUES ('Name 3', 1, '0382858284')
GO

-- Tạo dữ liệu mẫu từ bảng QuanLyGiaoDich
-- (các gói mà khách hàng đã mua)
-- Lưu ý: Kiểm tra lại UserID, PackID để sửa lại truy vấn mẫu này nếu lỗi.
DELETE FROM QuanLyGiaoDich
GO
INSERT INTO QuanLyGiaoDich (UserID, PackID)
VALUES (1, 1)
GO
INSERT INTO QuanLyGiaoDich (UserID, PackID)
VALUES (2, 2)
GO
INSERT INTO QuanLyGiaoDich (UserID, PackID)
VALUES (3, 3)
GO

-- Tạo dữ liệu mẫu từ bảng ThongTinDangNhap
-- (tài khoản đăng nhập)
INSERT INTO ThongTinDangNhap (Username, Password)
-- Tài khoản: admin, mật khẩu: admin
VALUES (N'admin', '21232f297a57a5a743894a0e4a801fc3')
GO

INSERT INTO ThongTinDangNhap (Username, Password)
-- Tài khoản: Zoe13010, mật khẩu: cloney1301
VALUES (N'Zoe13010', '201dd8aa46f36287fe71f1149425efa0')
GO

-- =============================================================================================
