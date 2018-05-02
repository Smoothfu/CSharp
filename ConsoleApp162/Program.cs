using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Net.Sockets;

namespace ConsoleApp162
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with StreamWriter/ StreamReader *****\n");

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string filePath = path + "\\NewText4.dat";

            //Get a StreamWriter and write string data.
            using (StreamWriter writer = File.CreateText(filePath))
            {
                writer.WriteLine("The world is fair and wonderful" + Environment.NewLine);
                writer.WriteLine("Cherish the present moment and make every second count" + Environment.NewLine);
                writer.WriteLine("Make a difference" + Environment.NewLine);
            }



                Console.ReadLine();
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
