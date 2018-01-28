using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp95
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = Task.Run(() => {
                //Just loop.
                int ctr = 0;
                for (ctr=0;ctr<=100000000;ctr++)
                {
                     
                }

                Console.WriteLine("Finished {0} loop iteration.\n", ctr);
            });
            t.Wait();
            Console.ReadLine();
        }
    }
}
