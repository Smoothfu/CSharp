using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp153
{
    class Program
    {
        static DateTime dt = DateTime.Now;
        static DateTime dtNew = dt.AddSeconds(10);
        static int x = 1000, y = 1000;
        static int count = 0;
       
        static void Main(string[] args)
        {

            var task = Task.Run(() => 10000000).ContinueWith(x => x.Result * 10);
            Console.WriteLine(task.Result);

            Console.ReadLine();            
        }

        static void AddMethod(ref int x,ref int y)
        {
           Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
            x += 1000;
            y += 1000;
        }
    }   
}
