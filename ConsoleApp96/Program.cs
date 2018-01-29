using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ConsoleApp96
{
    public delegate void ShowValue();
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            //Wait on a single task with no timeout specified.
            Task taskA = Task.Run(() => Thread.Sleep(2000));

            Console.WriteLine("taskA status: {0}\n", taskA.Status);
            try
            {
                taskA.Wait();
                Console.WriteLine("taskA Status:{0}\n", taskA.Status);
            }
            catch(AggregateException ex)
            {
                Console.WriteLine("Exception in taskA!\n");
            }
             
            Console.ReadLine();
        }

        private static void PrintNames(string str)
        {
            Console.WriteLine(str);
        }
    }

    public class Name
    {
        private string instanceName;

        public Name(string name)
        {
            this.instanceName = name;
        }

        public void DisplayToConsole()
        {
            Console.WriteLine(this.instanceName);
        }
        public void DisplayToWindow()
        {
            MessageBox.Show(this.instanceName);
        }
    }
}
