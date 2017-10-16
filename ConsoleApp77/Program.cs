using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp77
{

    public delegate void ShowNameHandler(string name);
    class Program
    {
        public static event ShowNameHandler ShowMsg;       
        static void Main(string[] args)
        {
            ShowMsg += Program_ShowMsg;
            ShowMsg("Fred");
            Console.ReadLine();
        }

        private static void Program_ShowMsg(string name)
        {
            Console.WriteLine("This name is " + name);
        }
    }
}
