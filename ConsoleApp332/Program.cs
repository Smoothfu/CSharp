using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp332
{
    class Program
    {
        static int i = 0;
        static CancellationTokenSource cts = new CancellationTokenSource();
        static void Main(string[] args)
        {
            Task.Run((()=>
            {
                Add(i);
            }),cts.Token);
           
            Console.ReadLine();
        }
        static void Add(object obj)
        {
            while (i < 100)
            {
                while(i==90)
                {
                    cts.Cancel();
                }
                Console.WriteLine($"Guid:{Guid.NewGuid()}, i {i}");
                i++;
            }            
        }
    }
}
