using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanGymChuot.Library.SqlServer
{
    public static class Account
    {
        public static class CurrentAccount
        {
            private static string userName = null;
            private static string passwordMD5 = null;

            /// <summary>
            /// Nhan ten nguoi dung hien tai.
            /// </summary>
            public static string UserName
            {
                get { return userName; }
                set
                {
                    if (userName != value)
                        userName = value;
                }
            }

            /// <summary>
            /// Dat thong tin dang nhap hien tai.
            /// </summary>
            /// <param name="userName">Ten dang nhap</param>
            /// <param name="pwdMD5">Mat khau</param>
            public static void Set(string userName, string pwdMD5)
            {
                CurrentAccount.userName = userName;
                CurrentAccount.passwordMD5 = pwdMD5;
            }

            /// <summary>
            /// Kiem tra tai khoan hien tai.
            /// </summary>
            /// <returns></returns>
            public static Result Check()
            {
                if (LogIn(userName, passwordMD5).Completed)
                    return new Result() { Completed = true };
                else
                    return new Result() { Completed = false, Message = "Current Account information has expired and can't be used." };
            }

            /// <summary>
            /// Xoa thong tin dang nhap hien tai.
            /// </summary>
            public static void Clear()
            {
                userName = null;
                passwordMD5 = null;
            }
        }

        /// <summary>
        /// Doi mat khau.
        /// </summary>
        /// <param name="userName">Ten dang nhap muon doi.</param>
        /// <param name="oldPasswordMD5">Mat khau cu (ma hoa bang MD5).</param>
        /// <param name="newPasswordMD5">Mat khau moi (ma hoa bang MD5).</param>
        public static Result ChangePassword(string userName, string oldPasswordMD5, string newPasswordMD5)
        {
            var cmd = new SqlCommand(String.Format("USE QuanGymChuot SELECT Password FROM ThongTinDangNhap WHERE Username = \'{0}\'", userName),
                                     Library.SqlServer.Connection.SqlConnect);

            try
            {
                string pwdMD5Ex = (string)cmd.ExecuteScalar();
                cmd.Dispose();
                if (pwdMD5Ex == null)
                    return new Result() { Completed = false, Message = String.Format("{0} was not exist! Check your login and try again.", userName) };
                if (pwdMD5Ex == oldPasswordMD5)
                {
                    cmd = new SqlCommand(String.Format("USE QuanGymChuot UPDATE ThongTinDangNhap SET Password = '{0}' WHERE Username = '{1}'", newPasswordMD5, userName),
                                         Library.SqlServer.Connection.SqlConnect);
                    int i = cmd.ExecuteNonQuery();
                    if (i == 1)
                        return new Result() { Completed = true };
                    else
                        throw new ApplicationException("Error while changing your password!");
                }
                else
                    return new Result() { Completed = false, Message = String.Format("Old password was incorrent! Check password you typed and try again.") };
            }
            catch
            {
                MessageBox.Show("Error while changing your password!\n" +
                                "Check your connection and try again.\n" +
                                "If you are connected, this error occurs while you change your password. Please wait a few minutes.",
                                "Quán Gym Chuột",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                cmd.Dispose();
                return new Result() { Completed = false, Message = "Error while changing your password!" };
            }
        }

        /// <summary>
        /// Dang nhap tai khoan.
        /// </summary>
        /// <param name="userName">Ten nguoi dung</param>
        /// <param name="passwordMD5">Mat khau</param>
        public static Result LogIn(string userName, string passwordMD5)
        {
            var cmd = new SqlCommand(String.Format("USE QuanGymChuot SELECT Password FROM ThongTinDangNhap WHERE Username = \'{0}\'", userName),
                                     Library.SqlServer.Connection.SqlConnect);
            try
            {
                string pwdMD5Ex = (string)cmd.ExecuteScalar();
                cmd.Dispose();

                if (pwdMD5Ex == null)
                    return new Result() { Completed = false, Message = String.Format("{0} was not exist!\nCheck your login and try again.", userName) };
                if (pwdMD5Ex == passwordMD5)
                {
                    CurrentAccount.Set(userName, passwordMD5);
                    return new Result() { Completed = true };
                }
                else
                    return new Result() { Completed = false, Message = String.Format("Password was incorrent!\nCheck your login and try again.") };

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error while logging in your account!\nTry again after few minutes or check log below.\n\nMessage:\n{0}", ex.Message),
                                "Quán Gym Chuột",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                cmd.Dispose();
                return new Result() { Completed = false, Message = "Error while logging in your account!\nTry again after few minutes." };
            }
        }

        /// <summary>
        /// Dang xuat tai khoan.
        /// </summary>
        public static Result LogOut()
        {
            try
            {
                CurrentAccount.Clear();
                return new Result() { Completed = true };
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error while logging out your account!\nTry again after few minutes or check log below.\n\nMessage:\n{0}", ex.Message),
                                "Quán Gym Chuột",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return new Result()
                {
                    Completed = false,
                    Message = String.Format("Error while logging out your account!\nTry again after few minutes.\n\nMessage:\n{0}", ex.Message)
                };
            }
        }
    }
}
