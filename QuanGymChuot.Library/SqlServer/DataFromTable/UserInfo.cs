using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanGymChuot.Library.SqlServer.DataFromTable
{
    public class UserInfo
    {
        public struct UserInfoItem
        {
            public long ID;
            public string Name;
            public bool Gender;
            public string Phone;
            public DateTime RegDate;
        }

        /// <summary>
        /// Lấy tất cả dữ liệu từ bảng UserInfo.
        /// </summary>
        public static List<UserInfoItem> GetAll()
        {
            List<UserInfoItem> result = null;

            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand("USE QuanGymChuot SELECT * FROM UserInfo", Connection.SqlConnect);
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

        public static UserInfoItem FindFirstObjectById(int id)
        {
            UserInfoItem uiitem = new UserInfoItem();

            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand(String.Format("USE QuanGymChuot SELECT * FROM UserInfo WHERE ID = \'{0}\'", id),
                         Connection.SqlConnect);
                SqlDataReader data = null;

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
        
        public static UserInfoItem FindFirstObjectByName(string userName)
        {
            UserInfoItem uiitem = new UserInfoItem();

            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand(String.Format("USE QuanGymChuot SELECT * FROM UserInfo WHERE Name = \'{0}\'", userName),
                         Connection.SqlConnect);
                SqlDataReader data = null;

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
        /// Thay đổi thuộc tính của thông tin người dùng từ bảng UserInfo theo ID.
        /// </summary>
        /// <param name="ID">ID của thông tin người dùng cần thay đổi</param>
        /// <param name="newObj">Giá trị sẽ thay đổi vào thông tin người dùng có trùng ID đó</param>
        public static void ChangeObject(long ID, UserInfoItem newObj)
        {
            if (Account.CurrentAccount.Check().Completed)
            {
                string value = String.Format("{0}, {1}, {2}",
                                             "Name = " + (newObj.Name != null ? "N\'" + newObj.Name + "\'" : "NULL"),
                                             "Gender = " + (newObj.Gender == true ? '1' : '0'),
                                             "Phone = " + (newObj.Phone != null ? "N\'" + newObj.Phone + "\'" : "NULL"));

                var cmd = new SqlCommand(String.Format("USE QuanGymChuot UPDATE UserInfo SET {0} WHERE ID = {1}", value, ID),
                                         Connection.SqlConnect);

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
        /// <param name="uiitem">Người dùng mới sẽ được tạo</param>
        public static void Create(UserInfoItem uiitem)
        {
            if (Account.CurrentAccount.Check().Completed)
            {
                string value = String.Format("{0}, {1}, {2}",
                             uiitem.Name == null ? "NULL" : '\'' + uiitem.Name + '\'',
                             uiitem.Gender ? 1 : 0,
                             uiitem.Phone == null ? "NULL" : '\'' + uiitem.Phone + '\'');

                var cmd = new SqlCommand(String.Format("USE QuanGymChuot INSERT INTO UserInfo (Name, Gender, Phone) VALUES({0})", value),
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
        /// Xóa dữ liệu từ bảng UserInfo theo ID.
        /// </summary>
        /// <param name="ID">ID của người dùng cần xóa</param>
        public static void DeleteObject(long ID)
        {
            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand(String.Format("USE QuanGymChuot DELETE FROM UserInfo WHERE ID = {0}", ID),
                                         Connection.SqlConnect);

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
