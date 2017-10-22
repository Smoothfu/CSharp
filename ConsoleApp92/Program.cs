using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp92
{
    class Program
    {
        static void Main(string[] args)
        {
            //new a thread without parameter
            Thread newThread = new Thread(new ThreadStart(AnotherMethod));

            //invoke the Start to execute the thread
            newThread.Start();
            Console.ReadLine();
        }

        ///<summary>
        ///new a method without parameters
        /// </summary>
        static void AnotherMethod()
        {
            Console.WriteLine("This method has no parameters！");
        }
    }
}
