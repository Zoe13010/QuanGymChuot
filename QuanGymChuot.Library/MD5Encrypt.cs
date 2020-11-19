using System.Security.Cryptography;
using System.Text;

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
