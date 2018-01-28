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
            DisplayMessageDel msgDel;
            if(Environment.GetCommandLineArgs().Length>0)
            {
                msgDel = ShowWindowsMessage;
            }
            else
            {
                msgDel = Console.WriteLine;
            }

            msgDel("This is the delegate method");
            Console.ReadLine();
        }

        private static void ShowWindowsMessage(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
