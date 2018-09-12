using System.Security.Cryptography;
using System.Text;

namespace SchoolExpress.WebService.Utils
{
    public static class Md5Tool
    {
        public static string CreateUtf8Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = md5Hash.ComputeHash(inputBytes);            
                StringBuilder sb = new StringBuilder();                
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }


        public static string CreateAsciiHash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }

        }
    }
}