using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp132
{
    class Program
    {
        static void Main(string[] args)
        {
            AddAsync();
            Console.ReadLine();
        }

        private static async Task AddAsync()
        {
            Console.WriteLine("*****Adding with Thread objects*****");
            Console.WriteLine("ID of thread in Main():{0} \n", Thread.CurrentThread.ManagedThreadId);

            AddParam ap = new AddParam(10, 10);
            await Sum(ap);

            Console.WriteLine("Other thread is done!");
        }
        static async Task Sum(object data)
        {
            await Task.Run(() =>
            {
                if (data is AddParam)
                {
                    Console.WriteLine("ID of thread in Add():{0}\n", Thread.CurrentThread.ManagedThreadId);
                    AddParam ap = (AddParam)data;
                    Console.WriteLine("{0}+{1} is {2}\n", ap.num1, ap.num2, ap.num1 + ap.num2);
                }
            });
        }
    }

    public class AddParam
    {
        public int num1 { get; set; }
        public int num2 { get; set; }
        public AddParam(int a,int b)
        {
            num1 = a;
            num2 = b;
        }
    }
}
