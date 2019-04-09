using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace ConsoleApp335
{
    class Program
    {
        static string logFullName = Directory.GetCurrentDirectory() + "//" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".txt";
        static string popUpMsg = string.Empty;
        static int i = 0;
        static void Main(string[] args)
        {
            popUpMsg = $"i is {i} in main,Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")},memory is" +
                  $" {Process.GetCurrentProcess().PrivateMemorySize64}";
            Console.WriteLine(popUpMsg);
            bool isCreatedNew;
            Mutex mutex = new Mutex(true, "ConsoleApp335", out isCreatedNew);
            if(!isCreatedNew)
            {
                MessageBox.Show("ConsoleApp335.exe is always running!");
                return;
            }
            Console.ReadLine();
        }

        static void StringBuilderDatetime()
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                for (i = 0; i < 100; i++)
                {
                    DateTime startDt = DateTime.Now;
                    DateTime endDt = startDt.AddSeconds(10);
                    while (DateTime.Now < endDt)
                    {
                        stringBuilder.Append(DateTime.Now.ToString("yyyyMMddHHmmssffff"));
                    }
                    StreamWriterLogMessage(stringBuilder.ToString());
                    stringBuilder.Clear();
                }

                popUpMsg = $"i is {i} in main,Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")},memory is" +
                    $" {Process.GetCurrentProcess().PrivateMemorySize64}";
                MessageBox.Show(popUpMsg);
            }
            catch (Exception ex)
            {
                popUpMsg = $"i is {i} in main exception,Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")},memory is " +
                    $"{Process.GetCurrentProcess().PrivateMemorySize64},exception {ex.StackTrace}";
                MessageBox.Show(popUpMsg);
            }
        }
        static void StreamWriterLogMessage(string logMsg)
        {
            try
            {
                popUpMsg = $"i is {i} in main,Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")},memory is" +
                   $" {Process.GetCurrentProcess().PrivateMemorySize64}";
                Console.WriteLine(popUpMsg);
                using (StreamWriter logWriter = new StreamWriter(logFullName, true))
                {
                    logWriter.WriteLine(logMsg);
                }
            }
            catch(Exception ex)
            {
                popUpMsg = $"i is {i} in log exception,Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")},memory is" +
                    $" {Process.GetCurrentProcess().PrivateMemorySize64},exception {ex.StackTrace}";
                MessageBox.Show(popUpMsg);
            }            
        }

        static void FileStreamWriter(string msg)
        {
            try
            {
                using (FileStream writerStream = File.OpenWrite(logFullName))
                {
                    Console.WriteLine($"Message size: {msg.Length},memory:{Process.GetCurrentProcess().PrivateMemorySize64}");
                    byte[] byteArr = ASCIIEncoding.UTF8.GetBytes(msg);
                    writerStream.Write(byteArr, 0, byteArr.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"memory:{Process.GetCurrentProcess().PrivateMemorySize64},{ex.Message}");
            }
        }
    }
}
