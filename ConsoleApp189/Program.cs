using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp189
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = paramsDemo();
            Console.WriteLine(arr.Length);

            foreach(int a in arr)
            {
                Console.WriteLine(a);
            }
            Console.ReadLine();
        }

        public static int[] paramsDemo(params int[] arr)
        {
            return arr;
        }
    }
}
