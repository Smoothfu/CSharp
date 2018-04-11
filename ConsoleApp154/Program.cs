﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ConsoleApp154
{
    class Program
    {
        static int x = 1000, y = 10000;
        static DateTime dt = DateTime.Now;
        static DateTime dtNew = dt.AddSeconds(30);
        static int count = 0;

        static void Main(string[] args)
        {
            var task=Task.Run<int>(() =>
            {
                while (DateTime.Now.Subtract(dtNew).Seconds < 0)
                {
                    AddMethod(ref x, ref y);
                    count++;
                }
                return count;
            });


            Console.WriteLine("Result: {0}\n", task.Result);
            Console.ReadLine();
        }

        static void AddMethod(ref int x,ref int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
            x = x + 1000;
            y = y + 1000;
        }
    }
}
