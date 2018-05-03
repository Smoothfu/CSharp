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
            //Obtain FileStream object via File.Create()
            using (FileStream fs = File.Create("NewFile8.dat"))
            {
            }

            //Obtain FileStream object via File.Open().
            using (FileStream fs2 = File.Open("NewFile8.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {

            }

            //Get a FileStream object with read-only permissions.
            using (FileStream readOnlyStream = File.OpenRead("NewFile8.dat"))
            {

            }

            //Get a FileStream object with write-only permissions.
            using (FileStream writeOnlyStream = File.OpenWrite("NewFile8.dat"))
            {

            }

            //Get a StreamReader object.
            using (StreamReader streamReader = File.OpenText("NewFile8.dat"))
            {

            }

            //Get some StreamWriters.
            using (StreamWriter streamWriter = File.CreateText("NewFile8.dat"))
            {

            }

            using (StreamWriter streamWriter = File.AppendText("NewFile8.dat"))
            {

            }
                Console.ReadLine();
        }
    }
}
