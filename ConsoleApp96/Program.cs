using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp96
{
    public delegate void ShowValue();
    class Program
    {
        static void Main(string[] args)
        {
            Task t = Task.Factory.StartNew(() =>
            {
                //Just loop
                int ctr = 0;
                for(ctr=0;ctr<=1000000000;ctr++)
                {

                }
                Console.WriteLine("Finished {0} loop iterations.\n", ctr);
            });
            t.Wait();
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
