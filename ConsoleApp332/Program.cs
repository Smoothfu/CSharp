﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;
using System.Net.Http;

namespace ConsoleApp332
{
    class Program
    {
        static int i = 0;
        static CancellationTokenSource cts = new CancellationTokenSource();
        delegate void AddDel(int x, int y);
        delegate int MathDel(int x, int y);
        delegate string GetTimeNowDel();
        static DateTime startTime = DateTime.Now;
        static DateTime endTime = startTime.AddSeconds(10);
        static string connString = "Server=FRED;Database=mydb;Integrated Security=true";
        static int insertCount = 0;
        static string selectCountSQL = "select count(*) from InsertTB";
        delegate int AddXYDel(int x, int y);
        
        static void Main(string[] args)
        {
            string result = TaskAsync().Result;
            Console.WriteLine(result);
            Logger.WriteLog(result);
            Console.ReadLine();
        }

        static async Task<string> TaskAsync()
        {
            HttpClient httpClient = new HttpClient();
            var  page = await httpClient.GetStringAsync("https://docs.microsoft.com/en-us/dotnet/standard/async-in-depth");
            return page;
        }

        static async void AsyncAwait(int x,int y)
        {
             
        }

        static int ReturnXAddY(int x,int y)
        {
            Thread.Sleep(1000);
            return x + y;
        }
        static void NewXYCallBack(IAsyncResult ar)
        {
            Console.WriteLine($"{ar.AsyncState}");
            Console.WriteLine("This is the AsyncCallback method,public interface IAsyncResult,public interface IAsyncResult");
        }

        static int AddXY(int x,int y)
        {
            Console.WriteLine($"{x}+{y}={x + y}");
            return x + y;
        }

        static void WaitCallback(object obj)
        {
            Console.WriteLine(obj.ToString());
            Console.WriteLine($"Now is {DateTime.Now.ToString("yyyyMMddHHmmssfff")}");
        }
        static void PrintNumbersWords()
        {
            List<string> strList = new List<string>();
            for(int i=1;i<=52;i++)
            {
                strList.Add(i.ToString());
            }

            string words = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] charArr = words.ToCharArray();
            for(int i=1;i<=26;i++)
            {
                strList.Insert(3*i-1, charArr[i-1].ToString());
            }

           
            foreach(string str in strList)
            {
                Console.Write(str);
            }
        }
        static void MissException()
        {
            try
            {
                for (int i = -10; i < 10; i++)
                {
                    Console.WriteLine(10 / i);
                }
            }
            catch(OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Logger.WriteLog(ex.Message);
            }

            //finally
            //{
            //    MissException();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

        }
        static void ContinueExample()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 3 == 0)
                {
                    continue;
                }
                Console.WriteLine(i);
            }
        }

        static void ThreadRunSpecifiedTimespan()
        {
            try
            {
                Thread thread = new Thread(() =>
                {
                    PrintTimeIn10Seconds();
                });
                Console.WriteLine(thread.ThreadState);
                thread.Start();
                Console.WriteLine(thread.ThreadState);
                if (thread != null && thread.IsAlive)
                {
                    if (!thread.Join(5000))
                    {
                       
                        thread.Abort();
                    }
                }              
                
                thread.Join();                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        static void PrintTimeIn10Seconds()
        {
            DateTime nowTime = DateTime.Now;
            DateTime endTime = nowTime.AddSeconds(10);
            while(DateTime.Now<endTime)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
            }
        }
        private static void NewTimerCallBack(object state)
        {
            Console.WriteLine($"Now is {DateTime.Now.ToString("yyyyMMddHHmmssfff")}");
        }
        static void TaskRun1()
        {
            Console.WriteLine("TaskRun1()");
        }
        static void TaskRun2()
        {
            Console.WriteLine("TaskRun2()");
        }
        static void TaskRun3()
        {
            Console.WriteLine("TaskRun3()");
        }
        static void TestMultiWriteDB()
        {
            Task.Run(() =>
            {
                InsertDataIntoTB();
            },cts.Token);

            Task.Run(() =>
            {
                while (DateTime.Now > endTime)
                {
                    Console.WriteLine(DateTime.Now.ToString());
                }
                if (DateTime.Now > endTime)
                {
                    cts.Cancel();
                }
            });
        }
        static void QueryInsertCount()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }


                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = selectCountSQL;

                    using (SqlDataAdapter selectAdaper = new SqlDataAdapter())
                    {
                        selectAdaper.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        selectAdaper.Fill(ds);
                        insertCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    } 
                }

                string msg = $"MultiThread insert data in to db,cost " +
               $"{endTime.Subtract(startTime).Milliseconds} milliseconds. Insert rows {insertCount}" +
               $"memory:{Process.GetCurrentProcess().PrivateMemorySize64} bytes,Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")}";
                Logger.WriteLog(msg);
            }
        }
        static void InsertDataIntoTB()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if(conn.State!=ConnectionState.Open)
                {
                    conn.Open();
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000000;
                    cmd.CommandText = "spInsertTB";
                    cmd.ExecuteNonQuery();
                }
            }
        }
        static void TestTimeCallback()
        {
            while (DateTime.Now < endTime)
            {
                Timer timer = new Timer(GetTimerCallback, "Test call back",TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
            };
        }
        private static void GetTimerCallback(object state)
        {
            if (DateTime.Now > endTime)
            {
                cts.Cancel();
            }
            Thread.Sleep(1000);
            Console.WriteLine("Now is " + DateTime.Now.ToString("yyyyMMddHHmmssffff"));
        }
        private static void NowCallBack(IAsyncResult ar)
        {
            Console.WriteLine($"The async state is {ar.AsyncState.ToString()}");
        }
        static string GetNow()
        {
            return "Now is " + DateTime.Now.ToString("yyyyMMddHHmmssffff");
        }
        static int Add(int x, int y)
        {
            return x + y;
        }
        private static void AddCallBack(IAsyncResult ar)
        {
            Console.WriteLine(ar.AsyncState.ToString());
        }
        static void Add(object obj)
        {
            try
            {
                while (i < 100)
                {
                    while (i == 90)
                    {
                        cts.Cancel();
                    }
                    string msg = $"i {i},Guid:{Guid.NewGuid()}";
                    Console.WriteLine(msg);
                    Logger.WriteLog(msg);
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        static string RetrieveString()
        {
            string msg = $"i {i},Guid:{Guid.NewGuid()}";
            cts.Cancel();
            return msg;
        }
        static long ReturnInt()
        {
            cts.Cancel();
            return Int64.MaxValue;
        }
        static decimal ReturnDecimal()
        {
            return Decimal.MaxValue;
        }
        static double ReturnDouble()
        {

            return double.MaxValue;
        }
    }

    public static class Logger
    {
        private static string lockString = "lockString";
        private static string logFullPath = Directory.GetCurrentDirectory() + "\\"
            + DateTime.Now.ToString("yyyyMMdd")+".txt";
        
        public static void WriteLog(string logMessage)
        {   
            lock(lockString)
            {
                using (StreamWriter logWriter = new StreamWriter(logFullPath, true, Encoding.UTF8))
                {

                    logWriter.WriteLine(logMessage);
                }
            }            
        }
    }
    public class MathBase
    {
        public delegate void MathDel(int x, int y);
    }
    public class MathClass : MathBase
    {
        public void Add(int x, int y)
        {
            Console.WriteLine($"Add,{x}+{y}={x + y}");
        }

        public void Subtract(int x,int y)
        {
            Console.WriteLine($"Subtract:{x}-{y}={x - y}");
        }

        public void Multiply(int x,int y)
        {
            Console.WriteLine($"Multiply:{x}*{y}={x * y}");
        }
    }
}
