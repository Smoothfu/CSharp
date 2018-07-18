using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp246
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with Object Serialization*****\n");
            string str = @"Assume you have created an instance of JamesBondCar, modified some state data, and want to
persist your spy mobile into a *.dat file. Begin by creating the *.dat file itself. You can achieve this by
creating an instance of the System.IO.FileStream type. At this point, you can create an instance of the
BinaryFormatter and pass in the FileStream and object graph to persist. Consider the following
Main() method:";

            //Now save the car to a specfic file in a binary format.
            SaveAsBinaryFormat(str, ".\\CarData.dat");

            Console.ReadLine();

        }

        static void SaveAsBinaryFormat(object objGraph,string fileName)
        {
            //Save object to a file named CarData.data in binary.
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=>Saved in binary format!\n");
        }
    }
}
