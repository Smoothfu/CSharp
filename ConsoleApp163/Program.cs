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
            //Get a FileStream object with read-only permissions.
            FileInfo fi = new FileInfo("NewFile.dat");
            using (FileStream readOnlyStream = fi.OpenRead())
            {

            }

            //Now get a FileStream object with write-only permissions.
            FileInfo fi2 = new FileInfo("NewFile2.dat");
            using (FileStream writeOnlyStream = fi2.OpenWrite())
            {

            }

        }
    }
}
