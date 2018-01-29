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
            var tasks = new Task[3];
            var rnd = new Random();
            for (int ctr = 0; ctr <= 2; ctr++)
            {
                tasks[ctr] = Task.Run(() => Thread.Sleep(rnd.Next(500, 3000)));
            }
            try
            {
                int index = Task.WaitAny(tasks);
                Console.WriteLine("Task #{0} completed first.\n", tasks[index].Id);
                Console.WriteLine("Status of all tasks:\n");
                foreach (var t in tasks)
                {
                    Console.WriteLine("Task #{0}:{1}", t.Id, t.Status);
                }
            }

            catch (AggregateException ex)
            {
                Console.WriteLine("An exception occured!\n");
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
