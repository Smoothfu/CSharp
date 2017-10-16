using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp75
{
    public delegate void ShowMsgHandler(string str);    

    class Program
    {
        public static event ShowMsgHandler ShowMsg;

        public static void ShowName(string name)
        {
            Console.WriteLine("My name is :{0}", name);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(ShowMsg == null);
            ShowMsg += ShowName;
            ShowMsg("Fred");
            Console.WriteLine(ShowMsg == null);
            ShowMsg -= ShowName;
            Console.WriteLine(ShowMsg == null);
            Console.ReadLine();
        }
    }
}
