using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApp324
{
    class Program
    {
        static object lockObj = new object();
        static void Main(string[] args)
        {
            ThreadPoolSample();
            Console.ReadLine();
        }

        static void ThreadPoolSample()
        {
            ThreadPool.QueueUserWorkItem(ShowThreadInformation);
            //var th1 = new Thread(ShowThreadInformation);
            //th1.Name = "th1";
            //th1.Start();
            //var th2 = new Thread(ShowThreadInformation);
            //th2.IsBackground = true;
            //th2.Name = "th2";
            //th2.Start();

            //Thread.Sleep(500);
            //ShowThreadInformation(null);
        }
        static void ShowThreadInformation(object state)
        {
            lock(lockObj)
            {
                var th = Thread.CurrentThread;
                Console.WriteLine($"Thread name:{th.Name}");
                Console.WriteLine($"Managed thread #{th.ManagedThreadId}");
                Console.WriteLine($"Background thread:{th.IsBackground}");
                Console.WriteLine($"Thread pool thread:{th.IsThreadPoolThread}");
                Console.WriteLine($"Priority:{th.Priority}");
                Console.WriteLine($"Culture:{th.CurrentCulture.Name}");
                Console.WriteLine($"UI culture:{th.CurrentUICulture.Name}");
                Console.WriteLine("\n");
            }
        }
        static void ThreadParamterizedStart()
        {
            var th = new Thread(ParameterizedSample);
            th.Start(4500);
            Thread.Sleep(1000);
            Console.WriteLine($"Main thread {Thread.CurrentThread.ManagedThreadId}");
        }
        static void ParameterizedSample(object obj)
        {
            int interval;
            try
            {
                interval = (int)obj;
            }
            catch(InvalidCastException)
            {
                interval = 5000;
            }

            DateTime startTime = DateTime.Now;
            var sw = Stopwatch.StartNew();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId},{Thread.CurrentThread.ThreadState}," +
                $"{Thread.CurrentThread.Priority}");
            do
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}," +
                    $"{sw.ElapsedMilliseconds} seconds");
                Thread.Sleep(500);
            } while (sw.ElapsedMilliseconds <= interval);
        }
        static void ExecuteInForeground()
        {
            DateTime startDt = DateTime.Now;
            var sw = Stopwatch.StartNew();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId},{Thread.CurrentThread.ThreadState}," +
                $"{Thread.CurrentThread.Priority}");
            do
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}," +
                    $"elapsed {sw.ElapsedMilliseconds}");
            } while (sw.ElapsedMilliseconds <= 5000);
            sw.Stop();
        }
        static void ActionTSample()
        {
            Action<int> intAction = x => { Console.WriteLine($"The cubic of {x} is {x * x * x}"); };
            intAction(1000);

            Action<string> stringAction = str =>
            {
                Console.WriteLine($"Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")}, str is {str}");
            };

            stringAction("Work hard!");
        }
        static void ThreadStartSample()
        {
            Console.WriteLine("Main thread:Start a second thread.");
            Thread thread = new Thread(new ThreadStart(ThreadProc));
            thread.Start();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Main thread:Do some work.");
                Thread.Sleep(0);
            }

            Console.WriteLine("Main thread:Call Join(),to wait until ThreadProc ends.");
            thread.Join();
            Console.WriteLine("Main thread:ThreadProc.Join has returned.");
        }
        public static void ThreadProc()
        {
            for(int i=0;i<10;i++)
            {
                Console.WriteLine($"ThreadProc:{i}");
                Thread.Sleep(0);
            }
        }
    }
}
