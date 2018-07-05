using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace ConsoleApp240
{
    class Program
    {
        static TokenKey tokenKeyObj = new TokenKey();
        static void Main(string[] args)
        {
            GetTokenAndKey();
            GetInfoFromServer();
            Console.ReadLine();
        }

        static void GetTokenAndKey()
        {
            string loginUrl = "http://crmtest.zjlhhs.com.cn/zex-crm-rest/auth?userName=104&password=sj123@";
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(loginUrl);
            req.Method = "GET";
            req.ContentType = "application/json;charset=UTF-8";
            HttpWebResponse res;
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                using (Stream stream = res.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string result = reader.ReadToEnd();
                        string[] arr = result.Split(new string[] { ":", ",", ";", "{", "}" }, StringSplitOptions.RemoveEmptyEntries);
                        tokenKeyObj.ServerToken = "Bearer "+arr[1];
                        tokenKeyObj.ServerKey = arr[3];
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        static void GetInfoFromServer()
        {
            string serverUrl = "http://crmtest.zjlhhs.com.cn/zex-crm-rest/member/query?access_token =" + tokenKeyObj.ServerToken;
            HttpWebRequest postReq = (HttpWebRequest)HttpWebRequest.Create(serverUrl);
            postReq.Method = "POST";
            postReq.ContentType = "application/x-sign;charset=UTF-8";
            var rawPostObjectData = "{\"timeStamp\":" +"\""+((DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds).ToString() +"\",";
            rawPostObjectData += "\"tranTime\":"+"\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\",";
            rawPostObjectData += "\"terminal\":" + "\" \"" + ",";
            rawPostObjectData += "\"storeCode\":" + "\"3355\""+ ",";
            rawPostObjectData += "\"accountType\":" + "\"2\""+ ",";
            rawPostObjectData += "\"accountCode\":" + "\"021215009281\"}";
            byte[] arrBytes = Encoding.ASCII.GetBytes(rawPostObjectData);
            var base64PostObjectEncodeString = Convert.ToBase64String(arrBytes,Base64FormattingOptions.InsertLineBreaks);

            MD5 md5 = MD5Encode(tokenKeyObj.ServerKey);            
            byte[] md5Result = md5.Hash;
            string md5String = "";
            foreach(var md in md5Result)
            {
                md5String += md;
            }
            

            var postData = "{\"sign\":\""+ md5String + "\","+"\"device\":"+"\"{}\","+"\"object\":"+"\""+base64PostObjectEncodeString+"\"}";

            var postDataBytes = Encoding.ASCII.GetBytes(postData);
            using (var stream = postReq.GetRequestStream())
            {
                stream.Write(postDataBytes, 0, postData.Length);
            }

            var response = (HttpWebResponse)postReq.GetResponse();
            using (Stream   stream = response.GetResponseStream())
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    string result = streamReader.ReadToEnd();
                    Console.WriteLine(result);
                }
            }
        }
            
        static MD5 MD5Encode(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            return md5;

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
