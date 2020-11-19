using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
        /// Doc du lieu tu bang UserInfo.
        /// </summary>
        /// <returns>List gom cac muc trong bang UserInfo.</returns>
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
    }
}
