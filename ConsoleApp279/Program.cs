﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp279
{
    class Program
    {
        delegate void MathDel(int x, int y);
        static void Main(string[] args)
        {
            int x = 10, y = 20;
            MathDel addDel = AddMethod;
            addDel(x, y);
            Console.ReadLine();
        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }
}
