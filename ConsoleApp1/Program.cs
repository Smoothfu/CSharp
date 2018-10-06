using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary7;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 678907678, y = 45678986, z = 567890567;
            WcfServiceLibrary7.MathService mathService = new MathService();
            int sum = mathService.Add(x, y,z);
            Console.WriteLine("{0}+{1}+{2}={3}\n",x,y,z,sum);
            Console.ReadLine();
        }
    }
}
