using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp92
{
    class Program
    {
        static void Main(string[] args)
        {
            Name instance = new Name("NameInstance");
            Action action = instance.DisplayToWindow;
            action();
            Console.ReadLine();
        }
    }

    public class Name
    {
        private string instanceName;
        public Name(string name)
        {
            this.instanceName = name;
        }

        private void DisplayToConsole()
        {
            Console.WriteLine(instanceName);
        }

        public void DisplayToWindow()
        {
            MessageBox.Show(instanceName);
        }
    }
}
