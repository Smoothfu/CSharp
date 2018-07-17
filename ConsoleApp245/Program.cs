using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;


namespace ConsoleApp245
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = @"珍惜时间You can use the BinaryFormatter type to illustrate how easy it is to persist an instance of the JamesBondCar
to a physical file. Again, the two key methods of the BinaryFormatter type to be aware of are Serialize()
and Deserialize().• Serialize(): Persists an object graph to a specified stream as a sequence of bytes
• Deserialize(): Converts a persisted sequence of bytes to an object graph";
            
            FileInfo fi = new FileInfo(".\\mydat9.dat");
           
            using (StreamWriter writer = new StreamWriter(fi.FullName,false,Encoding.UTF8))
            {
                writer.Write(str);
            }

            FileStream fStream = File.OpenRead(fi.FullName);
            using (StreamReader streamReader = new StreamReader(fi.FullName, Encoding.UTF8)) 
            {
                string result = streamReader.ReadToEnd();
                Console.WriteLine(result);
            } 
            Console.ReadLine();
        }

       
        static void SaveAsBinaryFormat(object obj,string fileName)
        {
            //Save object to a file named mybin.dat in binary;
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                binFormat.Serialize(fStream, obj);
            }
           
           
           Console.WriteLine("=>Saved in binary format!");
        }
    }
}
