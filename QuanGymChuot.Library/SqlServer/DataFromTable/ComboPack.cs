﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanGymChuot.Library.SqlServer.DataFromTable
{
    public class ComboPack
    {
        /// <summary>
        /// Lấy tất cả dữ liệu từ bảng ComboPack.
        /// </summary>
        public static List<ComboPackItem> GetAll()
        {
            List<ComboPackItem> result = null;

            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand(String.Format("USE QuanGymChuot SELECT * FROM GoiDichVu"),
                         Connection.SqlConnect);
                SqlDataReader data = null;

                try
                {
                    data = cmd.ExecuteReader();
                    result = new List<ComboPackItem>();

                    while (data.Read())
                    {
                        var dataPart = new ComboPackItem();
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
        /// Xóa dữ liệu từ bảng ComboPack theo truy vấn tìm kiếm.
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
        /// Thay đổi thuộc tính của gói dịch vụ từ bảng ComboPack theo ID.
        /// </summary>
        /// <param name="ID">ID của gói dịch vụ cần thay đổi</param>
        /// <param name="newComboInfo">Giá trị sẽ thay đổi vào gói dịch vụ có trùng ID đó</param>
        public static void Change(long ID, ComboPackItem newComboInfo)
        {
            if (Account.CurrentAccount.Check().Completed)
            {
                string value = String.Format("{0} {1} {2} {3} {4}",
                                             "Name = " + (newComboInfo.Name != null ? "N\'" + newComboInfo.Name + "\'" : "NULL") + ',',
                                             "Price = " + newComboInfo.Price + ',',
                                             "DayCount = " + newComboInfo.DayCount + ',',
                                             "Info = " + (newComboInfo.Info != null ? "N\'" + newComboInfo.Info + "\'" : "NULL") + ',',
                                             "CanUse = " + (newComboInfo.CanUse ? 1 : 0));

                var cmd = new SqlCommand(String.Format("USE QuanGymChuot UPDATE GoiDichVu SET {0} WHERE ID = {1}", value, ID),
                                         Connection.SqlConnect);

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
        /// Lấy gói dịch vụ đầu tiên của bảng ComboPack theo ID.
        /// </summary>
        /// <param name="id">ID của gói dịch vụ cần lấy</param>
        public static ComboPackItem FindFirstObjectById(int id)
        {
            ComboPackItem cpitem = new ComboPackItem();

            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand(String.Format("USE QuanGymChuot SELECT * FROM GoiDichVu WHERE ID = \'{0}\'", id),
                         Connection.SqlConnect);
                SqlDataReader data = null;

                try
                {
                    data = cmd.ExecuteReader();

                    while (data.Read())
                    {
                        cpitem.ID = data.GetInt32(0);
                        cpitem.Name = data.IsDBNull(1) ? null : data.GetString(1);
                        cpitem.Price = data.GetInt64(2);
                        cpitem.DayCount = data.GetInt64(3);
                        cpitem.Info = data.IsDBNull(4) ? null : data.GetString(4);
                        cpitem.CanUse = data.GetBoolean(5);
                        cpitem.AddedDate = data.GetDateTime(6);
                        break;
                    }

                    data.Close();
                }
                catch
                {
                    if (data != null)
                        data.Close();
                    cpitem = new ComboPackItem();
                }
            }

            return cpitem;
        }
        
        public static ComboPackItem FindFirstObjectByName(string comboName)
        {
            ComboPackItem cpitem = new ComboPackItem();

            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand(String.Format("USE QuanGymChuot SELECT * FROM GoiDichVu WHERE Name = N\'{0}\'", comboName),
                         Connection.SqlConnect);
                SqlDataReader data = null;

                try
                {
                    data = cmd.ExecuteReader();

                    while (data.Read())
                    {
                        cpitem.ID = data.GetInt32(0);
                        cpitem.Name = data.IsDBNull(1) ? null : data.GetString(1);
                        cpitem.Price = data.GetInt64(2);
                        cpitem.DayCount = data.GetInt64(3);
                        cpitem.Info = data.IsDBNull(4) ? null : data.GetString(4);
                        cpitem.CanUse = data.GetBoolean(5);
                        cpitem.AddedDate = data.GetDateTime(6);
                        break;
                    }

                    data.Close();
                }
                catch
                {
                    if (data != null)
                        data.Close();
                    cpitem = new ComboPackItem();
                }
            }

            return cpitem;
        }

        /// <summary>
        /// Tạo một gói dịch vụ mới vào bảng ComboPack.
        /// </summary>
        /// <param name="cpitem">Gói dịch vụ sẽ được tạo</param>
        public static void Create(ComboPackItem cpitem)
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
