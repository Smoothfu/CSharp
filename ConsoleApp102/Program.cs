using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp102
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(WriteY);
            //Run WriteY on the new thread
            thread.Start();
            
            while (true)
            {
                Console.WriteLine("X");
            }

            Pause();
           
            Console.ReadLine();
        }
        static void WriteY()
        {
            while (true)
            {
                Console.WriteLine("Y");
            }
           
        }

        static void Pause()
        {
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey(true);
        }
    }
}
