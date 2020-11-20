using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanGymChuot.Library.SqlServer.DataFromTable
{
    public class ComboPack
    {
        public struct ComboPackItem
        {
            public long ID;
            public string Name;
            public long Price;
            public long DayCount;
            public string Info;
            public bool CanUse;
            public DateTime AddedDate;
        }

        /// <summary>
        /// Doc du lieu tu bang ComboPack.
        /// </summary>
        /// <returns>List gom cac muc trong bang ComboPack.</returns>
        public static List<ComboPackItem> GetAll()
        {
            List<ComboPackItem> result = null;

            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand(String.Format("USE QuanGymChuot SELECT * FROM ComboPack"),
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

        public static void DeleteObject(long ID)
        {
            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand(String.Format("USE QuanGymChuot DELETE FROM ComboPack WHERE ID = {0}", ID),
                                         Connection.SqlConnect);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static void ChangeObject(long ID, ComboPackItem newObj)
        {
            if (Account.CurrentAccount.Check().Completed)
            {
                string value = String.Format("{0} {1} {2} {3} {4}",
                                             "Name = " + (newObj.Name != null ? "N\'" + newObj.Name + "\'" : "NULL") + ',',
                                             "Price = " + newObj.Price + ',',
                                             "DayCount = " + newObj.DayCount + ',',
                                             "Info = " + (newObj.Info != null ? "N\'" + newObj.Info + "\'" : "NULL") + ',',
                                             "CanUse = " + (newObj.CanUse ? 1 : 0));

                var cmd = new SqlCommand(String.Format("UPDATE ComboPack SET {0} WHERE ID = {1}", value, ID),
                                         Connection.SqlConnect);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static ComboPackItem FindObjectByName(string name)
        {
            ComboPackItem cpitem = new ComboPackItem();

            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand(String.Format("USE QuanGymChuot SELECT * FROM ComboPack WHERE Name = \'{0}\'", name),
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

        public static ComboPackItem FindObjectById(int id)
        {
            ComboPackItem cpitem = new ComboPackItem();

            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand(String.Format("USE QuanGymChuot SELECT * FROM ComboPack WHERE ID = \'{0}\'", id),
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

                var cmd = new SqlCommand(String.Format("USE QuanGymChuot INSERT INTO ComboPack (Name, Price, DayCount, Info, CanUse) VALUES({0})", value),
                                         Connection.SqlConnect);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
