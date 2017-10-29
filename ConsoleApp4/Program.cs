using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        bool done = false;
        static void Main(string[] args)
        {
            Program obj = new Program();
            new Thread(obj.Go).Start();

            obj.Go();
            
            Console.ReadLine();
        }

        void Go()
        {
            if(!done)
            {
               
                Console.WriteLine("Done");
            }
        }
         
    }
}
