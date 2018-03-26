using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp145
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<Int32> task = new Task<Int32>(x => Sum((Int32)x), 100);
            task.Start();
            Console.WriteLine("Now the status: {0}\n", task.Status);

            task.Wait();

            //Get the result the Result property internally calls wait.
            Console.WriteLine("The sum is : " + task.Result);
            
            Console.ReadLine();
        }

        static void Add(int x,int y,int z)
        {
            Console.WriteLine("{0}+{1}+{2}={3}\n", x, y, z, x + y + z);
        }

        private static void PrintMessage()
        {
            Console.WriteLine("The world is fair!\n");
        }

        private static Int32 Sum(Int32 n)
        {
            Int32 sum = 0;
            for(int i=0;i<n;i++)
            {
                checked
                {
                    sum += n;
                }                
            }

            return sum;
        }
    }
}
