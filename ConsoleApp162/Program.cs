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
            Console.WriteLine("*****Fun with StringWriter/StringReader*****\n");

            //Create a StringWriter and emit character data to memory.
            using (StringWriter stringWriter = new StringWriter())
            {
                stringWriter.WriteLine("The world is fair and wonderful!\n");
                stringWriter.WriteLine("Everything depend on myself!\n");
                stringWriter.WriteLine("Cherish the present moment and make every second count!\n");
                stringWriter.WriteLine("Make a difference!\n");


                //Get the internal StringBuilder
                StringBuilder stringBuilder = stringWriter.GetStringBuilder();
                stringBuilder.Insert(0, "My Motto!\n\n");
                Console.WriteLine("-> {0}\n", stringBuilder.ToString());
                stringBuilder.Remove(0, "My ".Length);
                Console.WriteLine("-> {0}\n", stringBuilder.ToString());
            }

            //Get a copy of the contents and dump to console.
           
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
