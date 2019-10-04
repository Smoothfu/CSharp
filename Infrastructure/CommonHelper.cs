using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class CommonHelper
    {
        public static string GetMD5(string input)
        {
            if(!string.IsNullOrWhiteSpace(input))
            {
                using(MD5 md5Hash = MD5.Create())
                {
                    byte[] rawBytes = Encoding.UTF8.GetBytes(input);
                    byte[] md5Array = md5Hash.ComputeHash(rawBytes);
                    StringBuilder pwdBuilder = new StringBuilder();
                    for(int i=0;i<md5Array.Length;i++)
                    {
                        pwdBuilder.Append(md5Array[i].ToString("x2"));
                    }
                    return pwdBuilder.ToString();    
                }
            }
            return null;
        }
    }
}
