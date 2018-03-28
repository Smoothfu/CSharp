using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp147
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Fun with Binary Writers/Readers******\n");

            //Open a binary writer for a file.
            FileInfo fi = new FileInfo("BinaryFile.dat");
            using (BinaryWriter bw = new BinaryWriter(fi.OpenWrite()))
            {
                //Print out the type of BaseStream.
                Console.WriteLine("Base stream is:{0}\n", bw.BaseStream);

                //Create some data to save in the file.
                double aDouble = 1234.67;
                int anInt = 34567;
                string aString = "A,B,C";

                //Write the data.
                bw.Write(aDouble);
                bw.Write(anInt);
                bw.Write(aString);
            }


            //Read the binary data from the stream.
            using (BinaryReader br = new BinaryReader(fi.OpenRead()))
            {
                Console.WriteLine(br.ReadDouble());
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadString());
            }
                Console.WriteLine("Done!\n");
            Console.ReadLine();
        }
    }
}
