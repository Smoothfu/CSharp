using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp334
{
    class Program
    {
        static string fullLogName = Directory.GetCurrentDirectory() + "//" + DateTime.Now.ToString("yyyyMMddHHMMssffff")+".txt";
        static void Main(string[] args)
        {
            DateTime dtNow = DateTime.Now;
            DateTime dtEnd = dtNow.AddSeconds(40);
            StringBuilder strBuilder = new StringBuilder();
            while (DateTime.Now < dtEnd)
            {
                strBuilder.Append($"Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            }

            Console.WriteLine($"Message size: {strBuilder.ToString().Length},memory:{Process.GetCurrentProcess().PrivateMemorySize64}");
            //FileStreamWriter(strBuilder.ToString());
            StreamWriterWriter(strBuilder.ToString());
            Console.WriteLine("Finished");
            Console.ReadLine();
        }
        static void StreamWriterWriter(string msg)
        {
            try
            {
                Console.WriteLine($"Message size: {msg.Length},memory:{Process.GetCurrentProcess().PrivateMemorySize64}");
                using (StreamWriter logStreamWriter = new StreamWriter(fullLogName, true))
                {
                    logStreamWriter.WriteLine(msg);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"memory:{Process.GetCurrentProcess().PrivateMemorySize64},{ex.Message}");
            }           
        }

        static void FileStreamWriter(string msg)
        {
            try
            {
                Console.WriteLine($"Message size: {msg.Length},memory:{Process.GetCurrentProcess().PrivateMemorySize64}");
                byte[] byteArr = ASCIIEncoding.UTF8.GetBytes(msg);
                using (FileStream writerStream = File.OpenWrite(fullLogName))
                {
                    writerStream.Write(byteArr, 0, byteArr.Length);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"memory:{Process.GetCurrentProcess().PrivateMemorySize64},{ex.Message}");
            }
        }
    }
}
