using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ConsoleApp417
{
    class UtilityHelper
    {
        public static string GetStringMD5(string str)
        {
            StringBuilder md5Builder = new StringBuilder();
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                byte[] rawDataBytes = Encoding.UTF8.GetBytes(str);
                byte[] md5Bytes = md5.ComputeHash(rawDataBytes);
                for (int i = 0; i < md5Bytes.Length; i++)
                {
                    md5Builder.Append(md5Bytes[i].ToString());
                }
            }
            return md5Builder.ToString();
        }
    }
}
