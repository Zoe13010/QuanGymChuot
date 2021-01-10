using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanGymChuot.Library.SqlServer.DataFromTable
{
    public class PackManager
    {
        /// <summary>
        /// Lấy tất cả dữ liệu.
        /// </summary>
        public static List<PackItem> GetAll()
        {
            List<PackItem> result = null;

            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand(String.Format("USE QuanGymChuot SELECT * FROM GoiDichVu"),
                         Connection.SqlConnect);
                SqlDataReader data = null;

                try
                {
                    data = cmd.ExecuteReader();
                    result = new List<PackItem>();

                    while (data.Read())
                    {
                        var dataPart = new PackItem();
                        dataPart.ID = data.GetInt32(0);
                        dataPart.Name = data.IsDBNull(1) ? null : data.GetString(1);
                        dataPart.Price = data.GetInt64(2);
                        dataPart.DayCount = data.GetInt64(3);
                        dataPart.Info = data.IsDBNull(4) ? null : data.GetString(4);
                        dataPart.CanUse = data.GetBoolean(5);
                        dataPart.AddedDate = data.GetDateTime(6);

                        result.Add(dataPart);
                    }

                    data.Close();
                    return result;
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
        /// Xóa dữ liệu theo truy vấn tìm kiếm.
        /// </summary>
        /// <param name="query">Truy vấn tìm kiếm kết quả cần xóa</param>
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

                string queryString = String.Format("USE QuanGymChuot DELETE FROM GoiDichVu WHERE {0}", whereString);

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

        /// <summary>
        /// Thay đổi thuộc tính của gói dịch vụ theo truy vấn tìm kiếm.
        /// </summary>
        /// <param name="query">Truy vấn tìm kiếm của gói dịch vụ cần thay đổi</param>
        /// <param name="newComboInfo">Giá trị sẽ thay đổi vào gói dịch vụ từ kết quả có được từ truy vấn đó</param>
        public static void Change(Dictionary<string, string> query, PackItem newComboInfo)
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

                string value = String.Format("{0} {1} {2} {3} {4}",
                                             "Name = " + (newComboInfo.Name != null ? "N\'" + newComboInfo.Name + "\'" : "NULL") + ',',
                                             "Price = " + newComboInfo.Price + ',',
                                             "DayCount = " + newComboInfo.DayCount + ',',
                                             "Info = " + (newComboInfo.Info != null ? "N\'" + newComboInfo.Info + "\'" : "NULL") + ',',
                                             "CanUse = " + (newComboInfo.CanUse ? 1 : 0));

                string queryString = String.Format("USE QuanGymChuot UPDATE GoiDichVu SET {0} WHERE {1}", value, whereString);
                var cmd = new SqlCommand(queryString, Connection.SqlConnect);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    MessageBox.Show("Error while changing selected combo pack.\nPlease check and try again.\n\nError message: \n" + ex.Message,
                                    "Quán Gym Chuột",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// TODO: Comment here!
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<PackItem> FindObjectsByName(string name)
        {
            List<PackItem> result = null;

            if (Account.CurrentAccount.Check().Completed)
            {
                SqlDataReader data = null;

                var queryString = String.Format("USE QuanGymChuot SELECT * FROM GoiDichVu WHERE Name LIKE N\'%{0}%\'", name);
                var cmd = new SqlCommand(queryString, Connection.SqlConnect);

                try
                {
                    data = cmd.ExecuteReader();
                    result = new List<PackItem>();

                    while (data.Read())
                    {
                        var dataPart = new PackItem();
                        dataPart.ID = data.IsDBNull(0) ? 0 : data.GetInt32(0);
                        dataPart.Name = data.IsDBNull(1) ? null : data.GetString(1);
                        dataPart.Price = data.IsDBNull(2) ? 0 : data.GetInt64(2);
                        dataPart.DayCount = data.IsDBNull(3) ? 0 : data.GetInt64(3);
                        dataPart.Info = data.IsDBNull(4) ? null : data.GetString(4);
                        dataPart.CanUse = data.IsDBNull(5) ? false : data.GetBoolean(5);
                        dataPart.AddedDate = data.IsDBNull(6) ? new DateTime() : data.GetDateTime(6);

                        result.Add(dataPart);
                    }

                    data.Close();
                    return result;
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
        public static List<PackItem> GetObjects(Dictionary<string,string> query)
        {
            List<PackItem> result = null;

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

                var queryString = String.Format("USE QuanGymChuot SELECT * FROM GoiDichVu WHERE {0}", whereString);
                var cmd = new SqlCommand(queryString, Connection.SqlConnect);

                try
                {
                    data = cmd.ExecuteReader();
                    result = new List<PackItem>();

                    while (data.Read())
                    {
                        var dataPart = new PackItem();
                        dataPart.ID = data.GetInt32(0);
                        dataPart.Name = data.IsDBNull(1) ? null : data.GetString(1);
                        dataPart.Price = data.GetInt64(2);
                        dataPart.DayCount = data.GetInt64(3);
                        dataPart.Info = data.IsDBNull(4) ? null : data.GetString(4);
                        dataPart.CanUse = data.GetBoolean(5);
                        dataPart.AddedDate = data.GetDateTime(6);

                        result.Add(dataPart);
                    }

                    data.Close();
                    return result;
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
        /// Lấy gói dịch vụ đầu tiên theo truy vấn tìm kiếm.
        /// </summary>
        /// <param name="query">Truy vấn tìm kiếm gói dịch vụ cần lấy</param>
        public static PackItem GetFirstObject(Dictionary<string, string> query)
        {
            return GetObjects(query)[0];
        }

        /// <summary>
        /// Tạo một gói dịch vụ mới.
        /// </summary>
        /// <param name="cpitem">Gói dịch vụ sẽ được tạo</param>
        public static void Create(PackItem cpitem)
        {
            if (Account.CurrentAccount.Check().Completed)
            {
                string value = String.Format("{0}, {1}, {2}, {3}, {4}",
                             cpitem.Name == null ? "NULL" : '\'' + cpitem.Name + '\'',
                             cpitem.Price.ToString(),
                             cpitem.DayCount.ToString(),
                             cpitem.Info == null ? "NULL" : '\'' + cpitem.Info + '\'',
                             cpitem.CanUse ? 1 : 0);

                var cmd = new SqlCommand(String.Format("USE QuanGymChuot INSERT INTO GoiDichVu (Name, Price, DayCount, Info, CanUse) VALUES({0})", value),
                                         Connection.SqlConnect);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    MessageBox.Show("Error while creating new combo pack.\nPlease check and try again.\n\nError message: \n" + ex.Message,
                                    "Quán Gym Chuột",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }
    }
}
