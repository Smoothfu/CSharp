using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp190
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            string result = client.addMethod(100, 200);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
