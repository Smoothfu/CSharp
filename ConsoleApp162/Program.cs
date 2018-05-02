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

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = path + "\\NewText7.txt";

            FileInfo fi = new FileInfo(filePath);

            using (StreamWriter streamWriter = fi.CreateText())
            {
                if (streamWriter != null)
                {
                    streamWriter.WriteLine("The world is fair and wonderful!" + Environment.NewLine);
                    streamWriter.WriteLine("Cherish the present moment and make every second count!" + Environment.NewLine);
                    streamWriter.WriteLine("Make a difference!\n");
                }
            }

            using (StreamReader streamReader = File.OpenText(filePath))
            {
                string str;
                while ((str = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(str);
                }
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
