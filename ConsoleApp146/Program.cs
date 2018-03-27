using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ConsoleApp146
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Fun with StringWriter/StringReader******\n");

            //Create a StringWriter and emit character data to memory.
            using (StringWriter stringWriter = new StringWriter())
            {
                stringWriter.WriteLine("Don't forget Mother's Day this year...\n");
                //Get a copy of the contents stored in a string and dump to console.
                Console.WriteLine("Contents of StringWriter:\n{0}", stringWriter);

                //Get the internal StringBuilder.
                StringBuilder stringBuilder = stringWriter.GetStringBuilder();
                stringBuilder.Insert(0, "Hey!!!");
                Console.WriteLine("->{0}\n", stringBuilder.ToString());
                stringBuilder.Remove(0, "Hey!!".Length);
                Console.WriteLine("->{0}\n", stringBuilder.ToString());
            }

            Console.ReadLine();
        }
    }
}
