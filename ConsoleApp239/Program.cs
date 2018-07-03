using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp239
{
    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program();
            ParameterizedThreadStart pts = new ParameterizedThreadStart(GetObjectHashCode);
            Thread thread = new Thread(pts);
            thread.Start(obj);
            Console.ReadLine();
        }

        static void GetObjectHashCode(object obj)
        {
            Console.WriteLine(obj.GetHashCode());
        }
    }
}
