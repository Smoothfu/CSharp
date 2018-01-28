using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp94
{
    delegate void DisplayMessageDel(string msg);
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            names.Add("Fred");
            names.Add("Floomberg");
            names.Add("Alexander");
            names.Add("Franklin");
            names.Add("Bill Gates");
            names.Add("Jeff Bezos");
            names.Add("Larry Page");
            names.Add("Mark Zuckerberg");
            names.Add("Larry Ellison");
            names.Add("Michael Bloomberg\n");

            //Display the contens of the list using the Print method.
            names.ForEach(Print);

            //The following demonstrates the anonymous method feature of C# to display the contents of the list to console.
            names.ForEach(delegate(string name)
            {
                Console.WriteLine(name);
            });
            
               
            Console.ReadLine();
        }

        private static void ShowWindowsMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        private static void Print(string str)
        {
            Console.WriteLine(str);
        }
    }
}
