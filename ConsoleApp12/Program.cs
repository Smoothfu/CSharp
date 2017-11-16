using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleClass obj = new SampleClass();
            var attrs = obj.GetType().GetCustomAttributes(true);

            foreach(Attribute att in attrs)
            {
                var sc = att as AuthorAttribute;
                Console.WriteLine(sc.name);
                Console.WriteLine(sc.version);
            }
            Console.ReadLine();
        }
    }
}
