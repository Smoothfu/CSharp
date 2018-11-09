using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ConsoleApp279
{
    class Program
    { 
        delegate void StringDel(string str);
        static void Main(string[] args)
        {
            List<int> intList = new List<int>();
            Random rnd = new Random();
            for (int i=0;i<10;i++)
            {                
                int num = rnd.Next(1, 100);
                intList.Add(num);
            }

            Parallel.ForEach(intList, x =>
            {
                Console.WriteLine(x);
                Console.ReadLine();
            });

            Console.ReadLine();
        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
    }
}
