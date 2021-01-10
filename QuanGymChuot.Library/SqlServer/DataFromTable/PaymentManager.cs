using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanGymChuot.Library.SqlServer.DataFromTable
{
    public class PaymentManager
    {
        /// <summary>
        /// Xuất toàn bộ dữ liệu từ bảng QuanLyGiaoDich.
        /// (có dùng 2 bảng GoiDichVu và ThongTinNguoiDung để tải nội dung tương ứng)
        /// </summary>
        /// <returns></returns>
        public static List<PaymentItem> GetAll()
        {
            List<PaymentItem> result = null;

            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand("USE QuanGymChuot " +
                                         "SELECT B3.ID AS PaymentID, B2.ID AS UserID, B2.Name AS UserName, B1.ID AS PackageID, B1.Name AS PackageName, B3.PackRegDate AS PackRegDate, B3.PackExpDate AS PackExpDate, B3.Note AS Note " +
                                         "FROM dbo.QuanLyGiaoDich AS B3 " +
                                         "INNER JOIN dbo.ThongTinNguoiDung AS B2 ON B3.UserID = B2.ID " +
                                         "INNER JOIN dbo.GoiDichVu AS B1 ON B3.PackID = B1.ID " +
                                         "ORDER BY B3.PackRegDate DESC",
                                         Connection.SqlConnect);
                SqlDataReader data = null;

                try
                {
                    data = cmd.ExecuteReader();
                    result = new List<PaymentItem>();

                    while (data.Read())
                    {
                        var dataPart = new PaymentItem();
                        dataPart.ID = data.IsDBNull(0) ? 0 :data.GetInt32(0);
                        dataPart.UserID = data.IsDBNull(1) ? 0 :data.GetInt32(1);
                        dataPart.UserName = data.IsDBNull(2) ? null :data.GetString(2);
                        dataPart.PackID = data.IsDBNull(3) ? 0 :data.GetInt32(3);
                        dataPart.PackName = data.IsDBNull(4) ? null :data.GetString(4);
                        dataPart.PackRegDate = data.IsDBNull(5) ? new DateTime() :data.GetDateTime(5);
                        dataPart.PackExpDate = data.IsDBNull(6) ? new DateTime() :data.GetDateTime(6);
                        dataPart.Note = data.IsDBNull(7) ? null : data.GetString(7);
                        result.Add(dataPart);
                    }

                    data.Close();
                }
                catch
                {
                    if (data != null)
                        data.Close();
                    result = null;
                }
            }

            return result;
        }

        /// <summary>
        /// Lấy các đối tượng từ bảng QuanLyGiaoDich từ các truy vấn mang tính tuyệt đối.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<PaymentItem> GetObjects(Dictionary<string, string> query)
        {
            List<PaymentItem> upiItem = new List<PaymentItem>();

            if (Account.CurrentAccount.Check().Completed)
            {
                SqlDataReader data = null;

                bool first = false;
                string whereString = "";
                foreach (KeyValuePair<string, string> kvp in query)
                {
                    if (!first)
                        first = true;
                    else whereString += ", ";

                    whereString += String.Format("{0} = {1}", kvp.Key, kvp.Value);
                }

                string queryString = String.Format("USE QuanGymChuot " +
                                                   "SELECT B3.ID AS PaymentID, B2.ID AS UserID, B2.Name AS UserName, B1.ID AS PackID, B1.Name AS PackName, B3.PackRegDate AS PackRegDate, B3.PackExpDate AS PackExpDate, B3.Note AS Note " +
                                                   "FROM dbo.QuanLyGiaoDich AS B3 " +
                                                   "INNER JOIN dbo.ThongTinNguoiDung AS B2 ON B3.UserID = B2.ID " +
                                                   "INNER JOIN dbo.GoiDichVu AS B1 ON B3.PackID = B1.ID " +
                                                   "WHERE {0}", whereString);

                SqlCommand sqlCommand = new SqlCommand(queryString, Connection.SqlConnect);

                try
                {
                    data = sqlCommand.ExecuteReader();

                    while (data.Read())
                    {
                        var dataPart = new PaymentItem();
                        dataPart.ID = data.IsDBNull(0) ? 0 : data.GetInt32(0);
                        dataPart.UserID = data.IsDBNull(1) ? 0 : data.GetInt32(1);
                        dataPart.UserName = data.IsDBNull(2) ? null : data.GetString(2);
                        dataPart.PackID = data.IsDBNull(3) ? 0 : data.GetInt32(3);
                        dataPart.PackName = data.IsDBNull(4) ? null : data.GetString(4);
                        dataPart.PackRegDate = data.IsDBNull(5) ? new DateTime() : data.GetDateTime(5);
                        dataPart.PackExpDate = data.IsDBNull(6) ? new DateTime() : data.GetDateTime(6);
                        dataPart.Note = data.IsDBNull(7) ? null : data.GetString(7);
                        upiItem.Add(dataPart);
                    }

                    data.Close();
                }
                catch
                {
                    if (data != null)
                        data.Close();
                    upiItem = new List<PaymentItem>();
                }
            }

            return upiItem;
        }

        /// <summary>
        /// Lấy duy nhất một đối tượng từ bảng QuanLyGiaoDich từ các truy vấn mang tính tuyệt đối.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static PaymentItem GetFirstObject(Dictionary<string, string> query)
        {
            return GetObjects(query)[0];
        }

        /// <summary>
        /// Tìm các đối tượng theo tên.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<PaymentItem> FindObjectsByName(string name)
        {
            List<PaymentItem> upiItem = new List<PaymentItem>();

            if (Account.CurrentAccount.Check().Completed)
            {
                SqlDataReader data = null;

                string queryString = String.Format("USE QuanGymChuot " +
                                                   "SELECT B3.ID AS PaymentID, B2.ID AS UserID, B2.Name AS UserName, B1.ID AS PackID, B1.Name AS PackName, B3.PackRegDate AS PackRegDate, B3.PackExpDate AS PackExpDate, B3.Note AS Note " +
                                                   "FROM dbo.QuanLyGiaoDich AS B3 " +
                                                   "INNER JOIN dbo.ThongTinNguoiDung AS B2 ON B3.UserID = B2.ID " +
                                                   "INNER JOIN dbo.GoiDichVu AS B1 ON B3.PackID = B1.ID " +
                                                   "WHERE B2.Name LIKE N\'%{0}%\' " +
                                                   "ORDER BY B3.PackRegDate DESC", name);

                SqlCommand sqlCommand = new SqlCommand(queryString, Connection.SqlConnect);

                try
                {
                    data = sqlCommand.ExecuteReader();

                    while (data.Read())
                    {
                        var dataPart = new PaymentItem();
                        dataPart.ID = data.IsDBNull(0) ? 0 : data.GetInt32(0);
                        dataPart.UserID = data.IsDBNull(1) ? 0 : data.GetInt32(1);
                        dataPart.UserName = data.IsDBNull(2) ? null : data.GetString(2);
                        dataPart.PackID = data.IsDBNull(3) ? 0 : data.GetInt32(3);
                        dataPart.PackName = data.IsDBNull(4) ? null : data.GetString(4);
                        dataPart.PackRegDate = data.IsDBNull(5) ? new DateTime() : data.GetDateTime(5);
                        dataPart.PackExpDate = data.IsDBNull(6) ? new DateTime() : data.GetDateTime(6);
                        dataPart.Note = data.IsDBNull(7) ? null : data.GetString(7);
                        upiItem.Add(dataPart);
                    }

                    data.Close();
                }
                catch
                {
                    if (data != null)
                        data.Close();
                    upiItem = new List<PaymentItem>();
                }
            }

            return upiItem;
        }

        /// <summary>
        /// Lấy số giao dịch còn hiệu lực của đối tượng theo UserID.
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static List<int> GetRemainPaymentByUserID(int UserID)
        {
            List<int> result = new List<int>();

            if (Account.CurrentAccount.Check().Completed)
            {
                SqlDataReader data = null;
                string queryString = String.Format("USE QuanGymChuot SELECT ID FROM QuanLyGiaoDich WHERE UserID = {0} AND PackExpDate > GETDATE()", UserID);
                var cmd = new SqlCommand(queryString, Connection.SqlConnect);

                try
                {
                    data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        result.Add(data.GetInt32(0));
                    }
                    data.Close();
                }
                catch (Exception ex)
                {
                    if (!data.IsClosed)
                        data.Close();
                    cmd.Dispose();
                    MessageBox.Show("Error while modifying selected registration.\nThis error may be occur when the selected combo pack is used in another users.\nPlease check and try again.\n\nError message: \n" + ex.Message,
                                    "Quán Gym Chuột",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }

            return result;
        }

        /// <summary>
        /// Đặt toàn bộ giao dịch của UserID thành hết hạn.
        /// </summary>
        /// <param name="UserID"></param>
        public static void SetRemainPaymentToExpiredByUserID(int UserID)
        {
            if (Account.CurrentAccount.Check().Completed)
            {
                string queryString = String.Format("USE QuanGymChuot UPDATE QuanLyGiaoDich SET PackExpDate = GETDATE(), Note = N\'User has renew package.\' WHERE UserID = {0} AND PackExpDate > GETDATE()", UserID);
                SqlCommand cmd = new SqlCommand(queryString, Connection.SqlConnect);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    MessageBox.Show("Error while modifying selected registration.\nThis error may be occur when the selected combo pack is used in another users.\nPlease check and try again.\n\nError message: \n" + ex.Message,
                                    "Quán Gym Chuột",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Tạo một giao dịch.
        /// </summary>
        /// <param name="upiItem"></param>
        public static void Create(PaymentItem upiItem)
        {
            if (Account.CurrentAccount.Check().Completed)
            {
                string value = String.Format("{0}, {1}, {2}, {3}, {4}",
                             upiItem.UserID,
                             upiItem.PackID,
                             '\'' + upiItem.PackRegDate.ToString("yyyy-MM-dd HH:mm:ss") + '\'',
                             '\'' + upiItem.PackExpDate.ToString("yyyy-MM-dd HH:mm:ss") + '\'',
                             upiItem.Note == null ? "NULL" : String.Format("N\'{0}\'", upiItem.Note));
        
                var cmd = new SqlCommand(String.Format("USE QuanGymChuot INSERT INTO QuanLyGiaoDich(UserID, PackID, PackRegDate, PackExpDate, Note) VALUES({0})", value),
                                         Connection.SqlConnect);
        
                try
                {
                    int result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    MessageBox.Show("Error while creating new registration.\nPlease check and try again.\n\nError message: \n" + ex.Message,
                                    "Quán Gym Chuột",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Xóa các giao dịch theo truy vấn tìm kiếm.
        /// </summary>
        /// <param name="query"></param>
        public static void Delete(Dictionary<string, string> query)
        {
            if (Account.CurrentAccount.Check().Completed)
            {
                bool first = false;
                string whereString = "";

                foreach (KeyValuePair<string, string> kvp in query)
                {
                    if (!first)
                        first = true;
                    else whereString += ", ";

                    whereString += String.Format("{0} = {1}", kvp.Key, kvp.Value);
                }

                string queryString = String.Format("USE QuanGymChuot DELETE FROM QuanLyGiaoDich WHERE {0}", whereString);
                var cmd = new SqlCommand(queryString, Connection.SqlConnect);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    MessageBox.Show("Error while deleting selected registration.\nThis error may be occur when the selected combo pack is used in another users.\nPlease check and try again.\n\nError message: \n" + ex.Message,
                                    "Quán Gym Chuột",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Cập nhật các giao dịch theo truy vấn tìm kiếm.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="upiItem"></param>
        public static void Update(Dictionary<string, string> query, PaymentItem upiItem)
        {
            if (Account.CurrentAccount.Check().Completed)
            {
                bool first = false;
                string whereString = "";

                foreach (KeyValuePair<string, string> kvp in query)
                {
                    if (!first)
                        first = true;
                    else whereString += ", ";

                    whereString += String.Format("{0} = {1}", kvp.Key, kvp.Value);
                }

                PackItem comboPack = PackManager.GetFirstObject(new Dictionary<string, string>() { { "Name", String.Format("N\'{0}\'", upiItem.PackName) } });
                int userID = upiItem.UserID;
                int packID = upiItem.PackID;
                string packRegDate = upiItem.PackRegDate.ToString("yyyy-MM-dd HH:mm:ss");
                string packExpDate = upiItem.PackExpDate.ToString("yyyy-MM-dd HH:mm:ss");

                string queryString = String.Format("USE QuanGymChuot UPDATE QuanLyGiaoDich SET UserID = {0}, PackID = {1}, PackRegDate = '{2}', PackExpDate = '{3}', Note = {4} WHERE {5}",
                                                   userID, packID, packRegDate, packExpDate, upiItem.Note == null ? "NULL" : String.Format("N\'{0}\'", upiItem.Note), whereString);

                var sqlCommand = new SqlCommand(queryString, Connection.SqlConnect);

                try
                {
                    int result = sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    sqlCommand.Dispose();
                    MessageBox.Show("Error while updating selected registration.\nThis error may be occur when the selected combo pack is used in another users.\nPlease check and try again.\n\nError message: \n" + ex.Message,
                                    "Quán Gym Chuột",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }
    }
}
