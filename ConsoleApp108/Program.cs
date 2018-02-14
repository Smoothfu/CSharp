using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Versioning;
using System.Globalization;

[assembly: TargetFramework(".NETFramework,Version=v4.6")]
namespace ConsoleApp108
{
   
    class Program
    {
        static void Main(string[] args)
        {

            decimal[] values = { 163025412.32m, 18905365.59m };
            string formatString = "C2";

            Func<string> formatDelegate = () =>
            {
                string output = string.Format("Formatting using the {0} culture on thread {1}.\n",
                    CultureInfo.CurrentCulture.Name, Thread.CurrentThread.ManagedThreadId);

                foreach (var val in values)
                {
                    output += string.Format("{0}  ", val.ToString(formatString));
                }

                output += Environment.NewLine;
                return output;
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

            Console.WriteLine("Changed the current culture to {0}.\n", CultureInfo.CurrentCulture.Name);

            //Execute the delegate synchronously.

            Console.WriteLine("Executing the delegate synchronously;");
            Console.WriteLine(formatDelegate());

            //Call an async delegate to format the values using one format string.
            Console.WriteLine("Executing a task asynchronouly:");
            var t1 = Task.Run(formatDelegate);
            Console.WriteLine(t1.Result);

            Console.WriteLine("Executing a task synchronously:");

            var t2 = new Task<string>(formatDelegate);
            t2.RunSynchronously();
            Console.WriteLine(t2.Result);

            Console.ReadLine();
        }

        private static Double DoComputation(Double start)
        {
            Double sum = 0;
            for(var value=start;value<=start+100000;value+=0.1)
            {
                sum += value;
            }
            return sum;
        }
    }

    class CustomData
    {
        public long CreationTime;
        public string Name;
        public int ThreadNum;
    }
}
