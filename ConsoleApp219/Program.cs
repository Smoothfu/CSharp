using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp219
{
    class Program
    {
        static void Main(string[] args)
        {
            AddAsync();
            Console.ReadLine();
        }

        static async Task Sum(object obj)
        {
            await Task.Run(() =>
            {
                var objAP = obj as AddParams;
                if (objAP != null)
                {
                    Console.WriteLine("ID of thread in Add():{0}\n", Thread.CurrentThread.ManagedThreadId);

                    Console.WriteLine("{0}+{1}={2}\n", objAP.PA, objAP.PB, objAP.PA + objAP.PB);
                }
            });
        }

        private static async Task AddAsync()
        {
            Console.WriteLine("******Adding with Thread objects******");
            Console.WriteLine("ID of thread in Main():{0}\n", Thread.CurrentThread.ManagedThreadId);

            AddParams ap = new AddParams(1000000, 463674567);
            await Sum(ap);
            Console.WriteLine("Other thread is done!");
        }
    }

    public class AddParams
    {
        public int PA { get; set; }
        public int PB { get; set; }

        public AddParams(int pA,int pB)
        {
            PA = pA;
            PB = pB;
        }
    }
}
