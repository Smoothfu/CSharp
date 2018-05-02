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

            string filePath = path + "\\NewText.txt";

            FileInfo fi = new FileInfo(filePath);

            using (FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                
            }
             
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
