using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp112
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = "1640";

            int number;
            if(Int32.TryParse(value,out number))
            {
                Console.WriteLine($"Converted '{value}' to {number}");
            }
            else
            {
                Console.WriteLine($"Unenable to convert '{value}'");
            }
            Console.ReadLine();
        }     
        
       
        static void Method(out int i,out string s1,out string s2)
        {
            i = 44;
            s1 = "I've been returned";
            s2 = null;
        }
    }         
}
