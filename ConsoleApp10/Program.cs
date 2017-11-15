using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp10
{
    public class MyClass
    {
        [Conditional("DEBUG")]
        public static void Message(string msg)
        {
            Console.WriteLine(msg);
        }
    }
    class Program
    {
        static void function1()
        {
            MyClass.Message("In Function 1.");
            function2();
        }

        static void function2()
        {
            MyClass.Message("In Function 2.");
        }
        static void Main(string[] args)
        {
            MyClass.Message("In Main function");
            function1();
            Console.ReadLine();
        }
    }
}
