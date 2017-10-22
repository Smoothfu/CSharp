using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp93
{
    class Program
    {
        static void Main(string[] args)
        {
            //new an instance of class ThreadTest
            ThreadTest obj = new ThreadTest();

            //Invoke the method in the instance
            Thread thread = new Thread(new ThreadStart(obj.MyMethod));

            //start the thread
            thread.Start();
            Console.ReadLine();
            
        }
    }

    class ThreadTest
    {
        public void MyMethod()
        {
            Console.WriteLine("This is a instance method!");
        }
    }
}
