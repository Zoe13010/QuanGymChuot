using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanGymChuot.Library.SqlServer.DataFromTable
{
    public class PaymentHistory
    {
        public static List<PaymentHistoryItem> GetAll()
        {
            List<PaymentHistoryItem> result = null;

            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand("USE QuanGymChuot " +
                                         "SELECT B3.ID, B2.ID, B2.Name, B1.ID, B1.Name, B3.ComboRegDate, B3.ComboExpDate " +
                                         "FROM dbo.LichSuGiaoDich AS B3 " +
                                         "INNER JOIN dbo.ThongTinNguoiDung AS B2 ON B3.UserID = B2.ID " +
                                         "INNER JOIN dbo.GoiDichVu AS B1 ON B3.ComboID = B1.ID",
                                         Connection.SqlConnect);
                SqlDataReader data = null;

                try
                {
                    data = cmd.ExecuteReader();
                    result = new List<PaymentHistoryItem>();

                    while (data.Read())
                    {
                        var dataPart = new PaymentHistoryItem();
                        dataPart.ID = data.GetInt32(0);
                        dataPart.UserID = data.GetInt32(1);
                        dataPart.UserName = data.GetString(2);
                        dataPart.PackageID = data.GetInt32(3);
                        dataPart.PackageName = data.GetString(4);
                        dataPart.PackageRegDate = data.GetDateTime(5);
                        dataPart.PackageExpDate = data.GetDateTime(6);

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

        public static PaymentHistoryItem GetFirstObject(Dictionary<string, string> query)
        {
            PaymentHistoryItem upiItem = new PaymentHistoryItem();

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

                string queryString = String.Format("USE QuanGymChuot " +
                                                   "SELECT B3.ID, B2.ID, B2.Name, B1.ID, B1.Name, B3.ComboRegDate, B3.ComboExpDate " +
                                                   "FROM dbo.LichSuGiaoDich AS B3 " +
                                                   "INNER JOIN dbo.ThongTinNguoiDung AS B2 ON B3.UserID = B2.ID " +
                                                   "INNER JOIN dbo.GoiDichVu AS B1 ON B3.ComboID = B1.ID " +
                                                   "WHERE {0}", whereString);

                var sqlCommand = new SqlCommand(queryString, Connection.SqlConnect);

                try
                {
                    data = sqlCommand.ExecuteReader();

                    while (data.Read())
                    {
                        upiItem.ID = data.GetInt32(0);
                        upiItem.UserID = data.GetInt32(1);
                        upiItem.UserName = data.GetString(2);
                        upiItem.PackageID = data.GetInt32(3);
                        upiItem.PackageName = data.GetString(4);
                        upiItem.PackageRegDate = data.GetDateTime(5);
                        upiItem.PackageExpDate = data.GetDateTime(6);
                        break;
                    }

                    data.Close();
                }
                catch
                {
                    if (data != null)
                        data.Close();
                    upiItem = new PaymentHistoryItem();
                }
            }

            return upiItem;
        }

        // public static void Create(UserPurchasedPackItem upiItem, long quality)
        // {
        //     if (Account.CurrentAccount.Check().Completed)
        //     {
        //         string value = String.Format("{0}, {1}, {2}",
        //                      upiItem.Name == null ? "NULL" : '\'' + uiitem.Name + '\'',
        //                      uiitem.Gender ? 1 : 0,
        //                      uiitem.Phone == null ? "NULL" : '\'' + uiitem.Phone + '\'');
        // 
        //         var cmd = new SqlCommand(String.Format("USE QuanGymChuot INSERT INTO UserInfo (Name, Gender, Phone) VALUES({0})", value),
        //                                  Connection.SqlConnect);
        // 
        //         try
        //         {
        //             int result = cmd.ExecuteNonQuery();
        //         }
        //         catch (Exception ex)
        //         {
        //             cmd.Dispose();
        //             MessageBox.Show("Error while creating new registration.\nPlease check and try again.\n\nError message: \n" + ex.Message,
        //                             "Quán Gym Chuột",
        //                             MessageBoxButtons.OK,
        //                             MessageBoxIcon.Warning);
        //         }
        //     }
        // }

        public static void Delete(long ID)
        {
            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand(String.Format("USE QuanGymChuot DELETE FROM LichSuGiaoDich WHERE ID = {0}", ID),
                                         Connection.SqlConnect);

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

        public static void Update(long ID, string packageName)
        {
            if (Account.CurrentAccount.Check().Completed)
            {
                var comboPack = ComboPack.GetFirstObject(new Dictionary<string, string>() { { "Name", String.Format("N\'{0}\'", packageName) } });
                var comboRegDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                var comboExpDate = DateTime.Now.AddDays(comboPack.DayCount).ToString("yyyy-MM-dd HH:mm:ss");

                string command = String.Format("USE QuanGymChuot UPDATE LichSuGiaoDich SET ComboID = {0}, ComboRegDate = '{1}', ComboExpDate = '{2}' WHERE ID = {3}",
                                               comboPack.ID, comboRegDate, comboExpDate, ID);
                Console.WriteLine(command);

                var cmd = new SqlCommand(command, Connection.SqlConnect);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    MessageBox.Show("Error while updating selected registration.\nThis error may be occur when the selected combo pack is used in another users.\nPlease check and try again.\n\nError message: \n" + ex.Message,
                                    "Quán Gym Chuột",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }
    }
}
