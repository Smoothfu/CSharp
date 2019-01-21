using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp319
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> intTask = AddTask(10, 20);
            Console.WriteLine($"Id:{intTask.Id},Status:{intTask.Status},Result:{intTask.Result}");
            Console.WriteLine(intTask.Status);
            Console.ReadLine();
        }

        static Task<int> AddTask(int x,int y)
        {
            return Task<int>.Run(() =>
            {
                return x + y;
            });
        }
        static void Divide(int x,int y)
        {
            try
            {
                Console.WriteLine($"{x}/{y}={x / y}");
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message+"In DivideByZeroException");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + "In Exception");
            }

            finally
            {
                Console.WriteLine("This is the finally block!");
            }          

        }

        static void TaskRun()
        {
            Task.Run(() =>
            {
                TimerCallback tcb = new TimerCallback(PrintTime);
                Timer timer = new Timer(tcb, null, 0, 300);

            });
        }
        static void PrintTime(object obj)
        {
            Console.WriteLine($"Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")}");
        }
    }
}
