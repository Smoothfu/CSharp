using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Runtime.Versioning;

[assembly:TargetFramework(".NETFramework,Version=v4.7")]

namespace ConsoleApp121
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] values = { 163025412.32m, 18905365.59m };
            string formatString = "C2";
            Func<string> formatDelegate = () =>
            {
                string outPut = string.Format("Formatting using the {0} culture on thread {1}\n",
                    CultureInfo.CurrentCulture.Name,
                    Thread.CurrentThread.ManagedThreadId);

                foreach (var value in values)
                {
                    outPut += string.Format("{0}  ", value.ToString(formatString));
                    outPut += Environment.NewLine;
                }
                return outPut;
            };

            Console.WriteLine("The example is running on thread {0}\n", Thread.CurrentThread.ManagedThreadId);

            //Make the current culture different from the system culture.
            Console.WriteLine("The current culture is {0}\n", CultureInfo.CurrentCulture.Name);

            if(CultureInfo.CurrentCulture.Name=="fr-FR")
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            }

            //Execute the delegate synchronously.
            Console.WriteLine("Executing the delegate synchronously!\n");
            Console.WriteLine(formatDelegate());

            //Call an async delegate to format the values using one format string.
            Console.WriteLine("Executing a task asynchronously!\n");

            var t1 = Task.Run(formatDelegate);
            Console.WriteLine(t1.Result);

            Console.WriteLine("Executing a task synchronously!\n");

            var t2 = new Task<string>(formatDelegate);
            t2.RunSynchronously();
            Console.WriteLine(t2.Result);

            Console.ReadLine();
        } 

        
    }

    class CustomData
    {
        public long CreationTime;
        public int Name;
        public int ThreadNum;
    }
}
