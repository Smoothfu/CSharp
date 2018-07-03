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
            Thread thread = new Thread(() =>
              {
                  GetObjectHashCode(obj);
              });
            thread.Start();
            Console.ReadLine();
        }

        static void GetObjectHashCode(object obj)
        {
            Console.WriteLine(obj.GetHashCode());
        }
    }
}
