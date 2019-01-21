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
            TimerCallback tcb = new TimerCallback(PrintTime);
            Timer timer = new Timer(tcb, null, 0, 1000);
            Console.ReadLine();
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

        static void PrintTime(object obj)
        {
            Console.WriteLine($"Now is {DateTime.Now.ToString("yyyyMMddHHmmss")}");
        }
    }
}
