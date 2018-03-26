using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp145
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> task = new Task<string>(x => PrintMessage((string)x),"Wonderful and fair");

            task.Start();
            task.Wait();
            string result = task.Result;
            Console.WriteLine(result);
            
            Console.ReadLine();
        } 

        private static string PrintMessage(string msg)
        {
            string str=string.Format("The msg is {0}, and now is {1}\n", msg, DateTime.Now.ToString("yyyyMMdd:HHmmssfff"));
            return str;
        }
    }
}
