using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ConsoleApp336
{
    class Program
    {
        static void Main(string[] args)
        {
            string dtNow = $"Now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")}";
            Console.WriteLine(dtNow);
            bool isCreatedNew;
            Mutex mutex = new Mutex(true, "ConsoleApp335", out isCreatedNew);
            if (!isCreatedNew)
            {
                MessageBox.Show("ConsoleApp335.exe is always running!");
                return;
            }
            Console.ReadLine();
        }
    }
}
