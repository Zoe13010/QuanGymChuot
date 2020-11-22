using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanGymChuot.Library.SqlServer.DataFromTable
{
    public class UserPurchasedPack
    {
        public struct UserPurchasedPackItem
        {
            public long ID;
            public long UserID;
            public string UserName;
            public long PackageID;
            public string PackageName;
            public DateTime PackageRegDate;
            public DateTime PackageExpDate;
        }

        public static List<UserPurchasedPackItem> GetAll()
        {
            List<UserPurchasedPackItem> result = null;

            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand("USE QuanGymChuot " +
                                         "SELECT B3.ID, B2.ID, B2.Name, B1.ID, B1.Name, B3.ComboRegDate, B3.ComboExpDate " +
                                         "FROM dbo.UserPurchasedPack AS B3 " +
                                         "INNER JOIN dbo.UserInfo AS B2 ON B3.UserID = B2.ID " +
                                         "INNER JOIN dbo.ComboPack AS B1 ON B3.ComboID = B1.ID",
                                         Connection.SqlConnect);
                SqlDataReader data = null;

                try
                {
                    data = cmd.ExecuteReader();
                    result = new List<UserPurchasedPackItem>();

                    while (data.Read())
                    {
                        var dataPart = new UserPurchasedPackItem();
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

        public static UserPurchasedPackItem FindFirstObjectById(int id)
        {
            UserPurchasedPackItem upiItem = new UserPurchasedPackItem();

            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand(String.Format("USE QuanGymChuot " +
                                         "SELECT B3.ID, B2.ID, B2.Name, B1.ID, B1.Name, B3.ComboRegDate, B3.ComboExpDate " +
                                         "FROM dbo.UserPurchasedPack AS B3 " +
                                         "INNER JOIN dbo.UserInfo AS B2 ON B3.UserID = B2.ID " +
                                         "INNER JOIN dbo.ComboPack AS B1 ON B3.ComboID = B1.ID " +
                                         "WHERE B3.ID = \'{0}\'", id),
                         Connection.SqlConnect);
                SqlDataReader data = null;

                try
                {
                    data = cmd.ExecuteReader();

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
                    upiItem = new UserPurchasedPackItem();
                }
            }

            return upiItem;
        }

        public static void DeleteObject(long ID)
        {
            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand(String.Format("USE QuanGymChuot DELETE FROM UserPurchasedPack WHERE ID = {0}", ID),
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
    }
}
