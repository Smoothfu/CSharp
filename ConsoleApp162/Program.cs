using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ConsoleApp162
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with FileStreams*****\n");
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string filePath = path + "\\NewText3.dat";

            //Obtain a FileStream object.
            using (FileStream fs = File.Open(filePath, FileMode.Create))
            {
                //Encode a string as an array of bytes.
                string msg = @"This world is wonderful and fair.Everything depend on myself Cherish the present moment.Make vert second count.Make a difference!";

                byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);

                //Write byte[] to file.
                fs.Write(msgAsByteArray, 0, msgAsByteArray.Length);

                //Reset internal position of stream.
                fs.Position = 0;

                //Read the types from file and display to console.
                Console.WriteLine("Your message as an array of bytes: ");
                byte[] bytesFromFile = new byte[msgAsByteArray.Length];
                for (int i = 0; i < msgAsByteArray.Length; i++)
                {
                    bytesFromFile[i] = (byte)fs.ReadByte();
                    Console.WriteLine(bytesFromFile[i]);
                }

                //Display decoded messages.
                Console.WriteLine("\nDecoded Message:\n");
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
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
