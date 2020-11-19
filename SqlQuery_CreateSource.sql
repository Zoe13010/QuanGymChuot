-- Tạo database - Nếu chưa có thì tạo, nếu đã có thì bỏ qua.
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'QuanGymChuot')
	CREATE DATABASE QuanGymChuot
ELSE
BEGIN
	PRINT(N'Đã có database QuanGymChuot.')
	PRINT(N'(bỏ qua thông báo này nếu muốn sử dụng database đã có sẵn)')
	PRINT(N'')
END
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
        WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'ComboPack'
	)
)
BEGIN
	PRINT(N'Đã có bảng ComboPack.')
	PRINT(N'(bỏ qua thông báo này nếu muốn sử dụng table đã có sẵn)')
	PRINT(N'')
END
ELSE
---- [Code chính] Nếu không có thì tạo mới.
CREATE TABLE ComboPack (
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
	CanUse bit NOT NULL DEFAULT 1
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
        WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'UserInfo'
	)
)
BEGIN
	PRINT(N'Đã có bảng UserInfo.')
	PRINT(N'(bỏ qua thông báo này nếu muốn sử dụng table đã có sẵn)')
	PRINT(N'')
END
ELSE
---- [Code chính] Nếu không có thì tạo mới.
CREATE TABLE UserInfo (
	-- ID
	ID int primary key NOT NULL IDENTITY(1,1),
	-- Tên người dùng
	Name nvarchar(max) NOT NULL,
	-- Giới tính người dùng
	Gender bit NOT NULL,
	-- SĐT người dùng
	Phone nvarchar(11),
	-- Ngày đăng ký
	RegDate date NOT NULL DEFAULT GETDATE()
)
GO

-- [Trigger] Kiểm tra SĐT
----  + Nếu không có Trigger, tạo Trigger mới.
----  + Nếu đã có Trigger này, xóa Trigger cũ và tạo mới.
----  + Nội dung: Nếu SĐT đã nhập nằm trong các trường hợp này thì hoàn tác:
----    - Ít hơn 10 số hay nhiều hơn 11 số.
----    - Không có số 0 ở đầu chuỗi SĐT.
DROP TRIGGER IF EXISTS dbo.UserInfo_Check_Add
GO
CREATE TRIGGER dbo.UserInfo_Check_Add
ON dbo.UserInfo
FOR INSERT
AS
BEGIN
	DECLARE @Phone nvarchar(11)
	SELECT @Phone = Phone FROM INSERTED
	IF (LEN(@Phone) < 10 OR SUBSTRING(@Phone, 1, 1) != N'0')
		ROLLBACK TRANSACTION
END
GO

-- [Bảng] Quản lý người dùng
-- Dữ liệu gồm các gói mà mỗi khách hàng đã mua.
---- [Thông báo - Không cần xem ở đây] Kiểm tra bảng. Nếu có thì thông báo.
IF (
	EXISTS(
		SELECT * 
		FROM INFORMATION_SCHEMA.TABLES 
        WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'UserPurchasedPack'
	)
)
BEGIN
	PRINT(N'Đã có bảng UserPurchasedPack.')
	PRINT(N'(bỏ qua thông báo này nếu muốn sử dụng table đã có sẵn)')
	PRINT(N'')
END
ELSE
---- [Code chính] Nếu không có thì tạo mới.
CREATE TABLE UserPurchasedPack (
	-- ID
	ID int primary key NOT NULL IDENTITY(1,1),
	-- ID người dùng
	UserID int NOT NULL,
	-- ID gói đã mua
	ComboID int NOT NULL,
	-- Ngày đăng ký gói
	ComboRegDate datetime NOT NULL DEFAULT GETDATE(),
	-- Ngày hết hạn gói
	ComboExpDate datetime,
	-- Liên kết cột UserID với cột ID của bảng UserInfo
	FOREIGN KEY (UserID) REFERENCES UserInfo(ID),
	-- Liên kết cột ComboID với cột ID của bảng ComboPack
	FOREIGN KEY (ComboID) REFERENCES ComboPack(ID)
)
GO

-- [Trigger] Tính ngày hết hạn
--    + Nếu không có Trigger, tạo Trigger mới.
--    + Nếu đã có Trigger này, xóa Trigger cũ và tạo mới.
--    + Nội dung: Tính ngày hết hạn từ gói đã đăng ký
DROP TRIGGER IF EXISTS dbo.PurchasedPack_Exec_ExpiredDate
GO
CREATE TRIGGER PurchasedPack_Exec_ExpiredDate
ON dbo.UserPurchasedPack
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @UserID int
	DECLARE @ComboID int
	DECLARE @ComboRegDate datetime
	DECLARE @DayCount bigint
	SELECT @UserID = UserID, @ComboID = ComboID, @ComboRegDate = ComboRegDate FROM inserted
	SELECT @DayCount=DayCount FROM ComboPack WHERE ID=@ComboID
	INSERT INTO dbo.UserPurchasedPack(UserID, ComboID, ComboRegDate, ComboExpDate)
	VALUES (@UserID, @ComboID, @ComboRegDate, DATEADD(day, @DayCount, GETDATE()))
	-- UPDATE dbo.UserPurchasedPack SET ComboExpDate = DATEADD(day, @DayCount, GETDATE()) WHERE (UserID = @UserID AND @ComboID = @ComboID)
END
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
        WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'LoginManager'
	)
)
BEGIN
	PRINT(N'Đã có bảng LoginManager.')
	PRINT(N'(bỏ qua thông báo này nếu muốn sử dụng table đã có sẵn)')
	PRINT(N'')
END
ELSE
---- [Code chính] Nếu không có thì tạo mới.
CREATE TABLE LoginManager (
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
DROP TRIGGER IF EXISTS dbo.LoginManager_Check_Add
GO
CREATE TRIGGER LoginManager_Check_Add
ON dbo.LoginManager
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @Username nvarchar(max)
	DECLARE @Password nvarchar(max)
	SELECT @Username = Username, @Password = Password FROM inserted
	IF (EXISTS(SELECT ID FROM dbo.LoginManager WHERE Username = @Username))
	-- SELECT * FROM dbo.LoginManager WHERE Username = N'admin'
		ROLLBACK TRANSACTION
	-- UPDATE dbo.UserPurchasedPack SET ComboExpDate = DATEADD(day, @DayCount, GETDATE()) WHERE (UserID = @UserID AND @ComboID = @ComboID)
	ELSE 
	INSERT INTO dbo.LoginManager(Username, Password)
	VALUES (@Username, @Password)
END
GO
