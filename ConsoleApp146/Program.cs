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
                stringWriter.WriteLine("The world is wonderful and fair,and everything depend on myself.\n");
                //Get a copy of the contents stored in a string and dump to console.
                Console.WriteLine("Contents of StringWriter:\n{0}", stringWriter);

                //Read data from the StringBuilder
                using (StringReader stringReader = new StringReader(stringWriter.ToString()))
                {
                    string input = null;
                    while((input=stringReader.ReadLine())!=null)
                    {
                        Console.WriteLine(input);
                    }
                }                    
            }

            Console.ReadLine();
        }
    }
}
