using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary12;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 3453145, y = 14542645;
            using (MathService service = new MathService())
            {
                string stringResult = service.AddMethod(x,y);
                Console.WriteLine(stringResult);
            }
            Console.ReadLine();
        }
    }
}
