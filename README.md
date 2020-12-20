# QuanGymChuot - Đồ án lập trình DUT 2020 - 19.Nh12B

## Về ngôn ngữ truy vấn có cấu trúc (SQL)
Hãy xem nội dung này trên Wikipedia (tiếng Anh): https://en.wikipedia.org/wiki/SQL
## Về đồ án
Đồ án này sẽ sử dụng các kiến thức của cơ sở dữ liệu kết hợp với các lệnh truy vấn trong SQL và lập trình trên C# (dotNET Framework), Java, C++,...
- Ứng dụng vào trình quản lý của một phòng Gym cơ bản.
## Sử dụng các ngôn ngữ, phần mềm hỗ trợ
- C# (.NET Framework)
- Thư viện ADO.NET
- Microsoft Visual Studio 2019 Community
- Microsoft SQL Server Express 2018
## Lưu ý trước khi sử dụng repo này
- Đảm bảo rằng bạn đã mở cổng TCP 1433 trên máy tính đang chạy repo này để chương trình hoạt động. Nếu bạn muốn kết nối SQL Server sử dụng chuỗi kết nối (Connection String) của bạn, hãy tìm và sửa giá trị tại login1.SqlConnectionString trong project QuanGymChuot.
## Tạo các bảng cần thiết trong SQL
Về nội dung và đường dẫn tải xuống 3 file về lệnh truy vấn trong SQL, hãy xem tại commit này:
- https://github.com/Zoe13010/QuanGymChuot/tree/experiment/SqlQuery
Thứ tự chạy file:
- Lưu ý: Lệnh chạy truy vấn trong Microsoft SQL Server Express là Execute (phím tắt mặc định là F5)
1. Tạo bảng sử dụng SqlQuery_CreateSource.sql: bôi đen toàn bộ và chạy lệnh truy vấn.
2. Tạo dữ liệu mẫu sử dụng SqlQuery_CreateData.sql: bôi đen phần INSERT rồi chạy lệnh truy vấn.
   - Trong khi đó phần DELETE sẽ xóa toàn bộ dữ liệu trong các bảng tương ứng.
3. [Tùy chọn] Xuất dữ liệu mẫu theo yêu cầu tương ứng với file SqlQuery_SelectData.sql: bôi đen toàn bộ hoặc một phần các lệnh cần dùng rồi chạy lệnh truy vấn.
## Tiến độ công việc trong Project QuanGymChuot
- Cơ bản:
  - [x] Control đăng nhập
  - [x] ListView xem danh sách
- Bảng:
  - ComboPack: Các gói dịch vụ mà khách hàng có thể mua
    - [x] Thêm
    - [x] Sửa
    - [x] Xóa
    - [ ] Tìm kiếm
    - [x] Làm mới
  - UserInfo: Thông tin khách hàng đã đăng ký tại quán
    - [x] Thêm
    - [x] Sửa
    - [x] Xóa
    - [ ] Tìm kiếm
    - [x] Làm mới
  - UserPurchasedPack: Thông tin các gói mà khách hàng đã mua hoặc gia hạn
    - [ ] Thêm
    - [x] Sửa
    - [x] Xóa
    - [ ] Tìm kiếm
    - [x] Làm mới
- Tài khoản:
  - [x] Đổi mật khẩu
  - [x] Đăng xuất
  - Quyền hạn xem tài khoản
    - [x] Full quyền (admin)
    - [x] ~~Chỉ xem (user) - Project này chỉ được tạo để cho chủ quán dễ quản lý và không muốn người dùng xem dữ liệu đó.~~
- [x] ~~Bộ cài đặt: Tạo bộ cài đặt/gỡ bỏ phần mềm (bỏ gạch ngang để thêm tính năng nếu cần thiết)~~
## Tài liệu đã sử dụng
- Mã hóa chuỗi ký tự sử dụng MD5: https://coderwall.com/p/4puszg/c-convert-string-to-md5-hash
