using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp163
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo fi6 = new FileInfo("FileInfo6.txt");
            using (StreamWriter streamWriter = fi6.CreateText())
            {

            }

            FileInfo fi7 = new FileInfo("FileInfo7.txt");
            using (StreamWriter streamWriter = fi7.AppendText())
            {

            }
            Console.ReadLine();
        }
    }
}
