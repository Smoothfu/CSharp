using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp100
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread th = Thread.CurrentThread;
            th.Name = "Main Thread";
            Console.WriteLine("This is {0}\n", th.Name);
            Console.WriteLine("CurrentUICulture: {0}\n", th.CurrentUICulture);
            Console.ReadLine();
        }
    }
}
