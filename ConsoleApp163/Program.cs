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
            //Get a StreamReader object.
            FileInfo fi = new FileInfo("NewFile2.txt");
            
            using (StreamReader streamReader = fi.OpenText())
            {

            }
            Console.ReadLine();
        }
    }
}
