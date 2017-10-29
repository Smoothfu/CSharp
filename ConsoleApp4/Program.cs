using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        static void Add(int x,int y,int z)
        {
            Console.WriteLine("{0}+{1}+{2}={3}", x, y, z, x + y + z);
        }

        static void Subtract(int x,int y,int z)
        {
            Console.WriteLine("{0}-{1}-{2}={3}", x, y, z, x - y - z);
        }

        static void Multiply(int x,int y,int z,int w)
        {
            Console.WriteLine("{0}*{1}*{2}*{3}={4}", x, y, z, w, x * y * z * w);
        }
        static void Main(string[] args)
        {
            new Thread(WriteY).Start();
            
            Console.ReadLine();
        }

        static void WriteY()
        {
            for(int i=0;i<1000;i++)
            {
                Console.Write("Y");
            }
        }
    }
}
