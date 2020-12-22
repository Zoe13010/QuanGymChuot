using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanGymChuot.Library.SqlServer.DataFromTable
{
    public class UserInfo
    {
        /// <summary>
        /// Lấy tất cả dữ liệu từ bảng UserInfo.
        /// </summary>
        public static List<UserInfoItem> GetAll()
        {
            List<UserInfoItem> result = null;

            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand("USE QuanGymChuot SELECT * FROM ThongTinNguoiDung", Connection.SqlConnect);
                SqlDataReader data = null;

                try
                {
                    data = cmd.ExecuteReader();
                    result = new List<UserInfoItem>();

                    while (data.Read())
                    {
                        var dataPart = new UserInfoItem();
                        dataPart.ID = data.GetInt32(0);
                        dataPart.Name = data.GetString(1);
                        dataPart.Gender = data.GetBoolean(2);
                        dataPart.Phone = data.GetString(3);
                        dataPart.RegDate = data.GetDateTime(4);

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
        /// TODO: Comment here!
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static UserInfoItem GetFirstObject(Dictionary<string, string> query)
        {
            UserInfoItem uiitem = new UserInfoItem();

            if (Account.CurrentAccount.Check().Completed)
            {
                bool first = false;
                string whereString = "";
                SqlDataReader data = null;

                foreach (KeyValuePair<string, string> kvp in query)
                {
                    if (!first)
                        first = true;
                    else whereString += ", ";

                    whereString += String.Format("{0} = {1}", kvp.Key, kvp.Value);
                }

                string queryString = String.Format("USE QuanGymChuot SELECT * FROM ThongTinNguoiDung WHERE {0}", whereString);

                var cmd = new SqlCommand(queryString, Connection.SqlConnect);

                try
                {
                    data = cmd.ExecuteReader();

                    while (data.Read())
                    {
                        uiitem.ID = data.GetInt32(0);
                        uiitem.Name = data.IsDBNull(1) ? null : data.GetString(1);
                        uiitem.Gender = data.GetBoolean(2);
                        uiitem.Phone = data.GetString(3);
                        uiitem.RegDate = data.GetDateTime(4);
                        break;
                    }

                    data.Close();
                }
                catch
                {
                    if (data != null)
                        data.Close();
                    uiitem = new UserInfoItem();
                }
            }

            return uiitem;
        }

        /// <summary>
        /// Thay đổi thuộc tính của thông tin người dùng từ bảng UserInfo theo truy vấn.
        /// </summary>
        /// <param name="query">Các truy vấn để tìm kiếm</param>
        /// <param name="newUserInfo">Giá trị sẽ thay đổi vào thông tin người dùng tìm được trong truy vấn đó</param>
        public static void Change(Dictionary<string, string> query, UserInfoItem newUserInfo)
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

                string value = String.Format("{0}, {1}, {2}",
                             "Name = " + (newUserInfo.Name != null ? "N\'" + newUserInfo.Name + "\'" : "NULL"),
                             "Gender = " + (newUserInfo.Gender == true ? '1' : '0'),
                             "Phone = " + (newUserInfo.Phone != null ? "N\'" + newUserInfo.Phone + "\'" : "NULL"));

                string queryString = String.Format("USE QuanGymChuot UPDATE ThongTinNguoiDung SET {0} WHERE {1}", value, whereString);

                var cmd = new SqlCommand(queryString, Connection.SqlConnect);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    MessageBox.Show("Error while changing selected user information.\nPlease check and try again.\n\nError message: \n" + ex.Message,
                                    "Quán Gym Chuột",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Tạo một người dùng mới vào bảng UserInfo.
        /// </summary>
        /// <param name="newUserInfo">Thông tin người dùng mới</param>
        public static void Create(UserInfoItem newUserInfo)
        {
            if (Account.CurrentAccount.Check().Completed)
            {
                string value = String.Format("{0}, {1}, {2}",
                             newUserInfo.Name == null ? "NULL" : '\'' + newUserInfo.Name + '\'',
                             newUserInfo.Gender ? 1 : 0,
                             newUserInfo.Phone == null ? "NULL" : '\'' + newUserInfo.Phone + '\'');

                var cmd = new SqlCommand(String.Format("USE QuanGymChuot INSERT INTO ThongTinNguoiDung (Name, Gender, Phone) VALUES({0})", value),
                                         Connection.SqlConnect);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    MessageBox.Show("Error while creating new user.\nPlease check and try again.\n\nError message: \n" + ex.Message,
                                    "Quán Gym Chuột",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Xóa dữ liệu từ bảng UserInfo theo kết quả truy vấn tìm kiếm.
        /// </summary>
        /// <param name="query">Các truy vấn để tìm kiếm</param>
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

                string queryString = String.Format("USE QuanGymChuot DELETE FROM ThongTinNguoiDung WHERE {0}", whereString);

                var cmd = new SqlCommand(queryString, Connection.SqlConnect);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    MessageBox.Show("Error while deleting selected combo pack.\nThis error may be occur when the selected combo pack is used in another users.\nPlease check and try again.\n\nError message: \n" + ex.Message,
                                    "Quán Gym Chuột",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }
    }
}
