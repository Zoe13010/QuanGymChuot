using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanGymChuot.Library.SqlServer
{
    public static class Connection
    {
        private static string connectionString = null;
        private static SqlConnection sqlConnect = null;

        public static SqlConnection SqlConnect
        {
            get { return sqlConnect; }
        }

        /// <summary>
        /// Thay doi chuoi ky tu de ket noi server.
        /// </summary>
        public static string ConnectionString
        {
            get { return connectionString; }
            set
            {
                if (connectionString != value)
                    connectionString = value;
            }
        }

        /// <summary>
        /// Trang thai ket noi server.
        /// </summary>
        /// <returns></returns>
        public static ConnectionState CheckConnectionStatus()
        {
            if (sqlConnect == null)
                return ConnectionState.Closed;
            return sqlConnect.State;
        }

        /// <summary>
        /// Ket noi den server.
        /// </summary>
        /// <returns></returns>
        public static Result Connect()
        {
            try
            {
                sqlConnect = new SqlConnection(connectionString);
                sqlConnect.Open();
                return new Result() { Completed = true };
            }
            catch (Exception e)
            {
                return new Result() { Completed = false, Message = e };
            }
        }

        /// <summary>
        /// Ngat ket noi khoi server.
        /// </summary>
        /// <returns></returns>
        public static Result Disconnect()
        {
            try
            {
                if (sqlConnect != null)
                {
                    sqlConnect.Close();
                    sqlConnect.Dispose();
                }
                return new Result() { Completed = true };
            }
            catch (Exception e)
            {
                return new Result() { Completed = false, Message = e };
            }
        }
    }
}