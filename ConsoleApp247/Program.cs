using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ConsoleApp247
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****A first look at Interfaces*****\n");
            Console.WriteLine(byte.MaxValue);
            Console.WriteLine(byte.MinValue);
            Console.ReadLine();
        }

        private static void CloneMe(ICloneable c)
        {
            //Clone whatever we get and print out the name.
            object theClone = c.Clone();
            Console.WriteLine("Your clone is a:{0}\n", theClone.GetType().Name);
        }
    }
}
