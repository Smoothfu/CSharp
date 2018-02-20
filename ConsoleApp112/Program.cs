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
            Method(out value);
            Console.WriteLine(value);
            Console.ReadLine();
        }     
        
        static void Method(out int i)
        {
            i = 44;
        }
    }         
}
