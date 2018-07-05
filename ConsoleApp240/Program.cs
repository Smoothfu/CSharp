using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Runtime.Serialization;

namespace ConsoleApp240
{
    class Program
    {
        static TokenKey tokenKeyObj = new TokenKey();
        static void Main(string[] args)
        {
            GetTokenAndKey();
            Console.ReadLine();
        }

        static void GetTokenAndKey()
        {
            string loginUrl = "http://crmtest.zjlhhs.com.cn/zex-crm-rest/auth?userName=104&password=sj123@";
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(loginUrl);
            req.Method = "GET";
            req.ContentType = "application/json;charset=UTF-8";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            using (Stream stream = res.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string result = reader.ReadToEnd();
                    string[] arr = result.Split(new string[] { ":",",",";","{","}" },StringSplitOptions.RemoveEmptyEntries);
                    tokenKeyObj.ServerToken = arr[1];
                    tokenKeyObj.ServerKey = arr[3];
                    //Console.WriteLine("\n\n\n\n\n");
                    Console.WriteLine(result);
                    Console.WriteLine("\n\n\n\n\n");
                    Console.WriteLine(tokenKeyObj.ServerToken);
                    Console.WriteLine("\n\n\n\n\n");
                    Console.WriteLine(tokenKeyObj.ServerKey);
                }
            }
        }
    }

    [DataContract]
    public class TokenKey
    {
        [DataMember]
        public string ServerToken { get; set; }
        
        [DataMember]
        public string ServerKey { get; set; }
    }
}
