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
            int value;
            string str1, str2;
            Method(out value, out str1, out str2);
            Console.WriteLine("Value ={0}\n", value);
            Console.WriteLine("str1={0}\n", str1);
            Console.WriteLine("str2={0}\n", str2);
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
