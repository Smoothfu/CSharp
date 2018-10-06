using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp272.MathService;

namespace ConsoleApp272
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 3564556, y = 256346745;
            MathService.MathClient client = new MathClient();
            ServiceReference1.MathClient mathClient = new ServiceReference1.MathClient();
            int sum = client.AddMethod(x, y);
            Console.WriteLine(sum);

            int add = mathClient.AddMethod(x, y);
            Console.WriteLine(add);
            Console.ReadLine();
        }
    }
}
