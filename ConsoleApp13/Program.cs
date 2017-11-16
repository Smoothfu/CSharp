using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(10, 20);
            rect.Display();

            Type type = typeof(Rectangle);

            var attrs = type.GetCustomAttributes(true);
            foreach(var att in attrs)
            {
                DebugInfoAttribute di = att as DebugInfoAttribute;
                if(di!=null)
                {
                    Console.WriteLine("Name: " + di.name);
                    Console.WriteLine("Id :" + di.id);
                }
            }

            Console.ReadLine();
        }
    }
}
