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

            //Defining a using scope for file I/O type is ideal.
            FileInfo fi = new FileInfo(filePath);

            string str = "This world is fair and everything depend on myself!\n";
            char[] allBytes = str.ToCharArray();

            using (FileStream fs = fi.Create())
            {
                //Use the FileStream object...
                fs.Write(GetBytes(str),0,str.Length*2);                
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
