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
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                DateTime dtNow = DateTime.Now;
                DateTime dtEnd = dtNow.AddSeconds(30);

                while (DateTime.Now < dtEnd)
                {
                    strBuilder.Append($"Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
                }

                Console.WriteLine($"First Message size: {strBuilder.ToString().Length},memory:{Process.GetCurrentProcess().PrivateMemorySize64}");
                              
                //FileStreamWriter(strBuilder.ToString());
                for(int i=0;i<100;i++)
                {
                    StreamWriterWriter(strBuilder.ToString());
                }
                
                //StreamWriterWriter(strBuilder.ToString());
                Console.WriteLine("Finished");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"datetime exception,Message size: {strBuilder.ToString().Length},memory:{Process.GetCurrentProcess().PrivateMemorySize64},exception:{ex.Message}");
            }
            Console.ReadLine();
        }
        static void StreamWriterWriter(string msg)
        {
            try
            {
                Console.WriteLine($"StreamWriterWriter Message size: {msg.Length},memory:{Process.GetCurrentProcess().PrivateMemorySize64}");
                using (StreamWriter logStreamWriter = new StreamWriter(fullLogName, true))
                {
                    logStreamWriter.WriteLine(msg);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"StreamWriterWriter exception memory:{Process.GetCurrentProcess().PrivateMemorySize64},{ex.Message}");
            }           
        }

        static void FileStreamWriter(string msg)
        {
            try
            {               
                using (FileStream writerStream = File.OpenWrite(fullLogName))
                {
                    Console.WriteLine($"Message size: {msg.Length},memory:{Process.GetCurrentProcess().PrivateMemorySize64}");
                    byte[] byteArr = ASCIIEncoding.UTF8.GetBytes(msg);
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
