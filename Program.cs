using ConsoleApp390.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp390
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializationDemo(); 
        }
        static void SerializationDemo()
        {
            List<SalesOrderDetail> dataList = GetList();
            bool IsBusy = false;
            for(int i=0;i<10;i++)
            {
                if(!IsBusy)
                {
                    IsBusy = true;                   

                    Task task = Task.Run(() => 
                    {
                        TestCostDemo(dataList);
                    });
                    task.Wait();

                    Console.WriteLine($"Task {i} has finished!");
                    IsBusy = false;
                }
            }            
        }
        static void TestCostDemo(List<SalesOrderDetail> dataList)
        {
            StringBuilder msgBuilder = new StringBuilder();
            Stopwatch sw = new Stopwatch();

            sw.Start();
            Console.WriteLine($"BinaryFormatterDemo started at {DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            BinaryFormatterDemo<SalesOrderDetail>(dataList);
            sw.Stop();
            Console.WriteLine($"BinaryFormatterDemo stopped at {DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            msgBuilder.Append($"In  .net 4.8,now {DateTime.Now.ToString("yyyyMMddHHmmssffff")} BinaryFormatterDemo cost {sw.ElapsedMilliseconds} milliseconds.");

            sw.Restart();
            Console.WriteLine($"NewtonJsonDemo started at {DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            NewtonJsonDemo<SalesOrderDetail>(dataList);
            sw.Stop();
            Console.WriteLine($"NewtonJsonDemo stopped at {DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            msgBuilder.Append($"NewtonJsonDemo cost {sw.ElapsedMilliseconds} milliseconds.");

            sw.Restart();
            Console.WriteLine($"JsonSerializerDemo started at {DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            JsonSerializerDemo<SalesOrderDetail>(dataList);
            sw.Stop();
            Console.WriteLine($"JsonSerializerDemo stopped at {DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            msgBuilder.AppendLine($"JsonSerializerDemo cost {sw.ElapsedMilliseconds} milliseconds.\n\n");
            string msg = msgBuilder.ToString();
            PrintMsg(msg);
        }
        private static void PrintMsg(string msg)
        {
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
            LogResult(msg);
        }
        static List<SalesOrderDetail> GetList()
        {
            using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
            {
                List<SalesOrderDetail> dataList = new List<SalesOrderDetail>(db.SalesOrderDetails);
                return dataList;
            }
        }
        static void BinaryFormatterDemo<T>(List<T> dataList)
        {
            using (FileStream fs = new FileStream($"{Guid.NewGuid().ToString().Substring(0, 6)}BinFormatter.dat", FileMode.Create))
            {
                BinaryFormatter binFormatter = new BinaryFormatter();
                try
                {
                    binFormatter.Serialize(fs, dataList);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine($"BinaryFormatter serialize ex:{e.StackTrace}");
                }
            }
        }
        static void NewtonJsonDemo<T>(List<T> dataList)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(dataList);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine($"NewtonJson serialization ex :{ex.StackTrace}");
            }
        }
        static void JsonSerializerDemo<T>(List<T> dataList)
        {
            try
            {
                string msJsonSerializerString = System.Text.Json.JsonSerializer.Serialize(dataList);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine($"System.Text.Json.JsonSerializer ex:{ex.StackTrace}");
            }
        }
        static void LogResult(string msg)
        {
            string logPath = @"log.txt";
            using (StreamWriter logWriter = new StreamWriter(logPath, true, Encoding.UTF8))
            {
                logWriter.WriteLine(msg);
            }
        }          
    }
}
