# QuanGymChuot - Đồ án lập trình DUT 2020 - 19.Nh12B

## Về ngôn ngữ truy vấn có cấu trúc (SQL)
Hãy xem nội dung này trên Wikipedia (tiếng Anh): https://en.wikipedia.org/wiki/SQL
## Về đồ án
Đồ án này sẽ sử dụng các kiến thức của cơ sở dữ liệu kết hợp với các lệnh truy vấn trong SQL và lập trình trên C# (dotNET Framework), Java, C++,...
- Ứng dụng vào trình quản lý của một phòng Gym cơ bản.
## Sử dụng các ngôn ngữ, phần mềm hỗ trợ
- C# (.NET Framework)
- Thư viện ADO.NET
- Microsoft Visual Studio 2013/2019 Community
- Microsoft SQL Server Express 2018
## Lưu ý trước khi sử dụng repo này
- Đảm bảo rằng bạn đã mở cổng TCP 1433 trên máy tính đang chạy repo này để chương trình hoạt động. Nếu bạn muốn kết nối SQL Server sử dụng chuỗi kết nối (Connection String) của bạn, hãy tìm và sửa giá trị tại login1.SqlConnectionString trong project QuanGymChuot.
## Tạo các bảng cần thiết trong SQL
Về demo về data sử dụng cho chương trình, hãy xem tại file này:
https://github.com/Zoe13010/QuanGymChuot/blob/experiment/SqlQuery/SqlQuery_CreateTempoaryData.sql
- Chỉ cần mở file và chạy.
  - Nếu chưa có database QuanGymChuot, nó sẽ tự động tạo một cái mới.
  - Nếu đã có database QuanGymChuot, nó sẽ xóa cái cũ và tạo một cái mới.
## Tiến độ công việc trong Project QuanGymChuot
- Cơ bản:
  - [x] Control đăng nhập
  - [x] ListView xem danh sách
- Bảng:
  - GoiDichVu: Các gói dịch vụ tập Gym có trong quán.
    - [x] Thêm
    - [x] Sửa
    - [x] Xóa
    - [x] Tìm kiếm
    - [x] Làm mới
  - ThongTinNguoiDung: Thông tin khách hàng đã đăng ký tại quán.
    - [x] Thêm
    - [x] Sửa
    - [x] Xóa
    - [x] Tìm kiếm
    - [x] Làm mới
  - QuanLyGiaoDich: Quản lý thông tin hoặc lịch sử giao dịch các gói dịch vụ mà khách hàng đã mua mới hoặc gia hạn.
    - [x] Thêm
    - [x] Sửa
    - [x] Xóa
    - [x] Tìm kiếm
    - [x] Làm mới
  - ThongTinTaiKhoan: Lưu trữ thông tin tài khoản dùng để quản lý cơ sở dữ liệu.
- Tài khoản:
  - [x] Đổi mật khẩu
  - [x] Đăng xuất
  - Quyền hạn xem tài khoản
    - [x] Full quyền (admin)
    - [x] ~~Chỉ xem (user) - Project này chỉ được tạo để cho chủ quán dễ quản lý và không muốn người dùng xem dữ liệu đó.~~
- [x] ~~Bộ cài đặt: Tạo bộ cài đặt/gỡ bỏ phần mềm (bỏ gạch ngang để thêm tính năng nếu cần thiết)~~
## Tài liệu đã sử dụng
- Mã hóa chuỗi ký tự sử dụng MD5: https://coderwall.com/p/4puszg/c-convert-string-to-md5-hash
- Tạo control tùy chỉnh trong WinForm (C#): https://stackoverflow.com/questions/6405458/how-do-i-make-custom-controls-in-c
- Event tùy chỉnh trong Event Handler (C#): https://stackoverflow.com/questions/803242/understanding-events-and-event-handlers-in-c-sharp
- Thực hiện lệnh SQL dưới nền sử dụng Background Worker (C#): https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.backgroundworker?view=netframework-2.0
- List<T>: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-2.0
