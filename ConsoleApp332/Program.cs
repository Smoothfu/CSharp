using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

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
        static void Main(string[] args)
        {
            TimeSpan ts = endTime.Subtract(startTime);
            Console.WriteLine($"Seconds: {ts.Seconds}");
            Console.WriteLine($"Milliseconds:{ts.Seconds*1000}");
            Console.WriteLine($"Microseconds:{ts.Ticks / 10}");
            Console.WriteLine($"NanoSeconds:{ts.Ticks * 100}");
            Console.ReadLine();
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
            + DateTime.Now.ToString("yyyyMMdd");
        
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
