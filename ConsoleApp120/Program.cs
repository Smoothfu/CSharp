using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp120
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = Task.Factory.StartNew(() =>
            {
                //Just loop
                int ctr = 0;
                for(ctr=0;ctr<=1000000000;ctr++)
                {

                }
                Console.WriteLine("Finished {0} loop iterations", ctr);

            });

            t.Wait();
            Console.ReadLine();
        }
    }
}
