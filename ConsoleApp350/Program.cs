using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp350.LogServerService;
using ConsoleApp350.MathServerService;

namespace ConsoleApp350
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10, y = 0;
            var logInstance = new ConsoleApp350.LogServerService.LogServiceClient();
            if (logInstance != null)
            {
                MathServiceClient mathInstance = new MathServiceClient();  

                string divideResult = mathInstance.Divide(x, y);
                Console.WriteLine(divideResult);
            }
            Console.ReadLine();
        }
    }
}
