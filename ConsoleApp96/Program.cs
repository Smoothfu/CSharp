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
            Name obj = new Name("Fred");
            ShowValue showMethod = obj.DisplayToWindow;
            showMethod();
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
