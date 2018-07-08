using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp242
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with object Serialization*****\n");
            LoadFromBinaryFile("CarData.dat");

            ////Make a JamesBondCar and set state.
            //JamesBondCar jbc = new JamesBondCar();
            //jbc.canFly = true;
            //jbc.canSubmerge = false;
            //jbc.theRadio.stationPresets = new double[] { 89.3, 105.1, 97.1 };
            //jbc.theRadio.hasTweeters = true;

            ////Now save the car to a specific file in a binary format.
            //SaveAsBinaryFormat(jbc, "CarData.dat");
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
            Console.WriteLine("=>Saved car in binary format!");
        }

        static void LoadFromBinaryFile(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            //Read the JamesBondCar from the binary file.
            using (Stream fStream = File.OpenRead(fileName))
            {
                JamesBondCar carFromDisk = (JamesBondCar)binFormat.Deserialize(fStream);
                Console.WriteLine("Can this car fly?:{0}\n", carFromDisk.canFly);
            }
        }
        static void AddMethod(int x,int y)
        {
            Console.WriteLine("The managedthreadIs in AddMethod is :{0}\n", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("{0}+{1}={2}", x, y, x + y);
        }
    }

    [Serializable]
    public class UserPrefs
    {
        public string WindowColor;
        public int FontSize;
    }

    [Serializable]
    public class Radio
    {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public double[] stationPresets;

        [NonSerialized]
        public string radioID = "XF-552RR6";
    }

    [Serializable]
    public class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
    }

    [Serializable]
    public class JamesBondCar : Car
    {
        public bool canFly;
        public bool canSubmerge;
    }

    [Serializable]
    public class Person
    {
        //A public field
        public bool isAlive = true;

        //A private field
        private int personAge = 21;

        //public property/private data.
        private string fName = string.Empty;
        public string FirstName
        {
            get
            {
                return fName;
            }
            set
            {
                fName = value;
            }
        }
    }
}
