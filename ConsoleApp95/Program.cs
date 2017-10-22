using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp95
{
    class Program
    {
        static void Main(string[] args)
        {
            //new a thread with parameter by parameterizedThreadStart
            Thread thread = new Thread(new ParameterizedThreadStart(NewThread));

            //given a value to the method
            thread.Start("new ParameterizedThreadStart");
            Console.ReadLine();
        }


        ///<summary>
        ///new a method with parameter
        /// </summary>
        static void NewThread(object msg)
        {
            Console.WriteLine(msg.ToString());
        }
        
    }
}
