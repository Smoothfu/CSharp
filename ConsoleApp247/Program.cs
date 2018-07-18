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

            //All of these classes support the ICloneable interface.
            string myStr = "Hello";
            OperatingSystem linuxOs = new OperatingSystem(PlatformID.Unix, new Version());
            System.Data.SqlClient.SqlConnection conn = new SqlConnection();

            //Therefore,they can all be passed into a method taking ICloneable.
            CloneMe(myStr);
            CloneMe(linuxOs);
            CloneMe(conn);
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
