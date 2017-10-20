using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp79
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList();
            Console.WriteLine("Adding some numbers：");
            al.Add(45);
            al.Add(78);
            al.Add(33);
            al.Add(56);
            al.Add(12);
            al.Add(23);
            al.Add(9);

            Console.WriteLine("Capacity :{0}", al.Capacity);
            Console.WriteLine("Count:{0}\n", al.Count);

            foreach(int i in al)
            {
                Console.Write(i+"\t");
            }

            Console.WriteLine();
            Console.WriteLine("\nSorted Content: ");
            al.Sort();

            foreach(int i in al)
            {
                Console.Write(i+"\t");
            }

            Console.ReadLine();
        }
    }
}
