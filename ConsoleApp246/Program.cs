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
            Car myCar = new Car("GE", "Huge");

            //Now save the car to a specfic file in a binary format.
            SaveAsBinaryFormat(myCar, ".\\CarData.dat");

            LoadFromBinaryFile(".\\CarData.dat");
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

        static void LoadFromBinaryFile(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            //Read the car from the binary file.
            using(Stream fStream=File.OpenRead(fileName))
            {
                Car myC = (Car)binFormat.Deserialize(fStream);
                Console.WriteLine(myC.Engine);
            }
        }
    }

    [Serializable]
    public class Car
    {
        public string Engine { get; set; }
        public string Power { get; set; }

        public Car(string engine,string power)
        {
            Engine = engine;
            Power = power;
        }
    }
}
