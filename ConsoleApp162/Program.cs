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


            //Obtain FileStream object via File.Create().
            using (FileStream fs = File.Create(filePath))
            {

            }

            //Obtain FileStream object via File.Open().
            using (FileStream fs2 = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {

            }

            //Get a FileStream object with read-only permissions.
            using (FileStream readOnlyStream = File.OpenRead(filePath))
            {

            }

            //Get a FileStream object with write-only permissions.
            using (FileStream writeOnlyStream = File.OpenWrite(filePath))
            {

            }

            //Get a StreamReader object.
            using (StreamReader streamReader = File.OpenText(filePath))
            {

            }

            //Get some StreamWriters.
            using (StreamWriter streamWriter = File.CreateText(filePath))
            {

            }

            using (StreamWriter streamWriter = File.AppendText(filePath))
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
