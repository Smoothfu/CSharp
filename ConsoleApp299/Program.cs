using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp299
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(x=>
            {
                OutputTime();
            },null,0,1000);
            Console.ReadLine();
        }

        static void OutputTime()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
        }
    }
}
