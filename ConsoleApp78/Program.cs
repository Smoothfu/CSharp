using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp78
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = new List<int>();
            ArrayList al = new ArrayList();

            al.Add("1");
            al.Add("Yes");
            al.Add(true);
            al.Add(10);
            al.Add("HelloWorld");

            foreach(var a in al)
            {
                try
                {
                    int i = Convert.ToInt32(a);
                    intList.Add(i);                     
                }
                catch
                {                     
                }                
            }           
           
            intList.ForEach(x =>
            {
                Console.WriteLine("x={0}", x);
                Console.WriteLine("2*x={0}", 2 * x);
            });

            Console.ReadLine();
        }
    }
}
