using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp301
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList();
            al.Add(1);
            al.Add(true);
            al.Add(1.1);
            al.Add('c');
            al.Add("Seeking truth");


            if (al!=null && al.Count>0)
            {
                foreach(var a in al)
                {
                    Console.WriteLine(a);
                }
            }
            Console.ReadLine();
        }
    }
}
