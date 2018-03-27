using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ConsoleApp146
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Fun with Binary Writers/Readers******\n");

            //Open a binary writer for a file.
            FileInfo fi = new FileInfo("BinFile.dat");
            using (BinaryWriter bw = new BinaryWriter(fi.OpenWrite()))
            {
                //Print out the type of BaseStream.
                //System.IO.FileStream in this case.
                Console.WriteLine("Base stream is :{0}\n", bw.BaseStream);

                //Create some data to save in the file.
                double aDouble = 1234.67;
                int anInt = 34567;
                string aString = "A,B,C";

                //Write the data.
                bw.Write(aDouble);
                bw.Write(anInt);
                bw.Write(aString);
            }

            Console.WriteLine("Done!");


            Console.ReadLine();
        }
    }
}
