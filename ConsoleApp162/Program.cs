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
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string filePath = path + "\\NewText3.txt";

            Console.WriteLine("*****Simple I/O with the File Type*****\n");
            string[] allStrings = { "This world is fair", "Everything depend on myself","Cherish the present moment","Make every second count","Make a difference"};

            //Write out all data to file on C drive.
            File.WriteAllLines(filePath, allStrings);

            //Read it all back and print out.
            foreach(string str in File.ReadAllLines(filePath))
            {
                Console.WriteLine(str);
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
