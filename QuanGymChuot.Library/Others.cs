using System;
using System.Security.Cryptography;
using System.Text;

namespace QuanGymChuot.Library
{
    public struct Result
    {
        /// <summary>
        /// Kiểm tra hàm đã thực hiện thành công hay chưa.
        /// </summary>
        public bool Completed;

        /// <summary>
        /// Tin nhắn truyền vào từ hàm nếu có.
        /// </summary>
        public object Message;

        /// <summary>
        /// Tạo một thông báo mới có nội dung của biến hiện tại truyền vào.
        /// </summary>
        public Result Clone()
        {
            return new Result()
            {
                Completed = this.Completed,
                Message = this.Message
            };
        }
    }

    public class ListViewFindEventArgs : EventArgs
    {
        private string findText = null;

        public ListViewFindEventArgs() { }

        public string FindText
        {
            get { return findText; }
            set
            {
                if (findText != value)
                    findText = value;
            }
        }
    }
}

namespace QuanGymChuot.Library
{
    // Source code: https://coderwall.com/p/4puszg/c-convert-string-to-md5-hash
    public static class MD5Encrypt
    {
        public static string Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}

namespace QuanGymChuot.Library.SqlServer.DataFromTable
{
    public struct PackItem
    {
        public int ID;
        public string Name;
        public long Price;
        public long DayCount;
        public string Info;
        public bool CanUse;
        public DateTime AddedDate;
    }

    public struct UserItem
    {
        public int ID;
        public string Name;
        public bool Gender;
        public string Phone;
        public DateTime RegDate;
    }

    public struct PaymentItem
    {
        public int ID;
        public int UserID;
        public string UserName;
        public int PackID;
        public string PackName;
        public DateTime PackRegDate;
        public DateTime PackExpDate;
        public string Note;
    }
}
