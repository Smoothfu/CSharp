using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

namespace ConsoleApp333
{
    class Program
    {
        static string tempString = "Test temporary";
        static string costMsg = string.Empty;
        static ConcurrentDictionary<int, string> concurrentDic = new ConcurrentDictionary<int, string>();
        static Stopwatch stopWatch = new Stopwatch();
        static ConcurrentDictionary<int, string> countTimeDic = new ConcurrentDictionary<int, string>();
        static ConcurrentQueue<int> concurrentQueue = new ConcurrentQueue<int>();
        static void Main(string[] args)
        {
            int x = 100000, y = 2000000;
            int intResult = GetAddTaskAsync(x, y).Result;
            Console.WriteLine(intResult);
        }

        static  async Task<int> GetAddTaskAsync(int x,int y)
        {
            var intResult=await Task.Run<int>(() =>
            {
                return x + y;
            });
            Console.WriteLine(intResult.GetType().Name);
            return intResult;
        }
        static async Task GetPageSizeAsync(string url)
        {
            var client = new HttpClient();
            var uri = new Uri(Uri.EscapeUriString(url));
            byte[] urlContents = await client.GetByteArrayAsync(uri);
            Console.WriteLine($"{url}:{urlContents.Length / 2:N0} characters");
        }

        static void TestAsyncAwait()
        {
            stopWatch.Start();
            Task testTask = Task.Run(() =>
            {
                TestAsyncAwaitCost(47);
            });
            testTask.Wait();

            //foreach (var dic in concurrentDic)
            //{
            //    Console.Write(dic.Key+"\t");
            //}
            stopWatch.Stop();
            costMsg = $"cost:{stopWatch.ElapsedMilliseconds} milliseconds,memory: {Process.GetCurrentProcess().PrivateMemorySize64} bytes,now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")}";
            Logger.WriteLog(costMsg);

            var intList = (from i in concurrentQueue
                           select i).ToList();
            Console.WriteLine($"Total count:{intList.Count}");

            var uniqueList = intList.Distinct().ToList();
            Console.WriteLine($"Unique count:{uniqueList.Count}");
            System.Windows.Forms.MessageBox.Show(costMsg);
        }
        static void TestAsyncAwaitCost(int tasksCount)
        {
            Task<string>[] tasksArr = new Task<string>[tasksCount];
            for (int i = 1; i <= tasksCount; i++)
            {
                tasksArr[i-1] = GetUrlContent(i);
            }
            Task startTask = Task.WhenAll(tasksArr);
            startTask.Wait();
        }

        static async Task<string> GetUrlContent(int i)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var stringTask = httpClient.GetStringAsync("https://docs.microsoft.com/en-us/dotnet/standard/async-in-depth");
                    concurrentQueue.Enqueue(i);
                    tempString = await stringTask;
                    //string dtMsg = $"now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")}";
                    //if (!countTimeDic.ContainsKey(i))
                    //{
                    //    countTimeDic[i] = dtMsg;
                    //}
                   
                    Console.WriteLine($"i={i},now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
                    //if (!concurrentDic.ContainsKey(i))
                    //{
                    //    concurrentDic[i] = tempString;
                    //}
                    return tempString;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception :{i}");
                Logger.WriteLog($"i={i},now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")}, {ex.StackTrace.ToString()}");
            }
            return string.Empty;
        }
    }

    public static class Logger
    {
        private static string lockString = "lockString";
        private static string logFullPath = Directory.GetCurrentDirectory() + "\\"
            + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".txt";

        public static void WriteLog(string logMessage)
        {
            lock (lockString)
            {
                using (StreamWriter logWriter = new StreamWriter(logFullPath, true, Encoding.UTF8))
                {
                    logWriter.WriteLine(logMessage);
                }
            }
        }
    }
}
