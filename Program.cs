using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp355
{
    class Program
    {
        static DateTime dt = DateTime.Now;
        static DateTime dtEnd = dt.AddSeconds(5);
        static Timer timer;
        static void Main(string[] args)
        {
            try
            {
                TimeSpan ts = TimeSpan.FromMilliseconds(500);
                TimeSpan dueTS = TimeSpan.FromSeconds(0);
                timer = new Timer(NewTimerCallback, "This is object state", dueTS, ts);
            }
            finally
            {
                if (timer != null && DateTime.Now >= dtEnd)
                {
                    timer.Dispose();
                }
            } 
            
            Console.ReadLine();
        }        

        private static void NewTimerCallback(object state)
        {
            if (DateTime.Now > dtEnd)
            {
                timer.Dispose();
                return;
            }
            Console.WriteLine($"Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
        }

        static void NewCancellationTokenSourceTimeSpan()
        {
            IEnumerable<int> intList = Enumerable.Range(1, 1000000000);
            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(1000));
            CancellationToken ctsToken = cts.Token;

            Task.Run(() =>
            {
                try
                {
                    foreach (int i in intList)
                    {
                        if (i % 10000000 == 0)
                        {
                            if (i % 100000000 == 0)
                            {
                                cts.Cancel();
                            }
                            Console.WriteLine(i);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }, ctsToken);
        }
        static void TaskCancellationTokenSource()
        {
            //Define the cancellation token.
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ctsToken = cts.Token;

            Random rnd = new Random();
            object lockObj = new object();

            List<Task<int[]>> tasks = new List<Task<int[]>>();
            TaskFactory factory = new TaskFactory(ctsToken);

            for (int taskCtr = 0; taskCtr <= 10; taskCtr++)
            {
                int iteration = taskCtr + 1;
                tasks.Add(factory.StartNew(() =>
                {
                    int value;
                    int[] values = new int[10];
                    for (int ctr = 1; ctr <= 10; ctr++)
                    {
                        lock (lockObj)
                        {
                            value = rnd.Next(0, 101);
                        }
                        if (value == 0)
                        {
                            cts.Cancel();
                            Console.WriteLine($"Cancelling at task{iteration}");
                            break;
                        }
                        values[ctr - 1] = value;
                    }
                    return values;
                }, ctsToken));
            }

            try
            {
                Task<double> fTask = factory.ContinueWhenAll(tasks.ToArray(),
                    (results) =>
                    {
                        Console.WriteLine("Calculating overall mean...");
                        long sum = 0;
                        int n = 0;
                        foreach (var t in results)
                        {
                            foreach (var r in t.Result)
                            {
                                sum += r;
                                n++;
                            }
                        }
                        return sum / (double)n;
                    }, ctsToken);
                Console.WriteLine($"The mean is {fTask.Result}");
            }
            catch (AggregateException ae)
            {
                foreach (Exception ex in ae.InnerExceptions)
                {
                    if (ex is TaskCanceledException)
                    {
                        Console.WriteLine($"Unable to compute mean:{((TaskCanceledException)ex).Message}");
                    }
                    else
                    {
                        Console.WriteLine($"Exception :{ex.GetType().Name}");
                    }
                }
            }

            finally
            {
                cts.Dispose();
            }
        }
    }
}
