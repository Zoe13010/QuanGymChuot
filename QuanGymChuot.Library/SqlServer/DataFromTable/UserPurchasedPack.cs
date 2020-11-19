using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QuanGymChuot.Library.SqlServer.DataFromTable
{
    public class UserPurchasedPack
    {
        public struct UserPurchasedItem
        {
            public long ID;
            public string UserName;
            public string PackageName;
            public DateTime PackageRegDate;
            public DateTime PackageExpDate;
        }

        /// <summary>
        /// Doc du lieu tu bang UserPurchasedPack.
        /// </summary>
        /// <returns>List gom cac muc trong bang UserPurchasedPack.</returns>
        public static List<UserPurchasedItem> GetAll()
        {
            List<UserPurchasedItem> result = null;

            if (Account.CurrentAccount.Check().Completed)
            {
                var cmd = new SqlCommand("USE QuanGymChuot " +
                                         "SELECT B3.ID, B2.Name, B1.Name, B3.ComboRegDate, B3.ComboExpDate " +
                                         "FROM dbo.UserPurchasedPack AS B3 " +
                                         "INNER JOIN dbo.UserInfo AS B2 ON B3.UserID = B2.ID " +
                                         "INNER JOIN dbo.ComboPack AS B1 ON B3.ComboID = B1.ID",
                                         Connection.SqlConnect);
                SqlDataReader data = null;

                try
                {
                    data = cmd.ExecuteReader();
                    result = new List<UserPurchasedItem>();

                    while (data.Read())
                    {
                        var dataPart = new UserPurchasedItem();
                        dataPart.ID = data.GetInt32(0);
                        dataPart.UserName = data.GetString(1);
                        dataPart.PackageName = data.GetString(2);
                        dataPart.PackageRegDate = data.GetDateTime(3);
                        dataPart.PackageExpDate = data.GetDateTime(4);

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
    }
}
