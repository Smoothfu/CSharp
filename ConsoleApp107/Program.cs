using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp107
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start a thread that calls a parameterized static method.
            Thread newThread = new Thread(DoWork);
            newThread.Start("This is embeded data in thread.");

            //Start a thread that calls a parameterized instance method.

            Program obj = new Program();
            newThread = new Thread(obj.DoMoreWork);
            newThread.Start("This is not a static method parameter!");
            Console.ReadLine();
        }

        public static void DoWork(object data)
        {
            Console.WriteLine("Static thread procedure,data ='{0}'.", data);
        }

        public void DoMoreWork(object data)
        {
            Console.WriteLine("Instance thread procedure.data='{0}'.", data);
        }
    }
}
