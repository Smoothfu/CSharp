using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            MaximizeConsoleWindow(); 
            ConsoleWindowDemo();
            Console.WriteLine("\n\n\n\n\n");
            ShowEnvironmentInfoDemo();
            Console.ReadLine();
        }

        static void MaximizeConsoleWindow()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        }

        static void ConsoleWindowDemo()
        {
            Type type = typeof(Console);
            PropertyInfo[] pis = type.GetProperties();
            if (pis != null && pis.Any())
            {
                Parallel.ForEach(pis, x =>
                {
                    Console.WriteLine($"Name:{x.Name},Value:{x.GetValue(x)}");
                });
            }           
        }

        static void ShowEnvironmentInfoDemo()
        {
            try
            {
                Type type = typeof(Environment);
                PropertyInfo[] pis = type.GetProperties();
                if (pis != null && pis.Any())
                {
                    Parallel.ForEach(pis, x =>
                    {
                        Console.WriteLine($"Name:{x.Name},value:{x.GetValue(x)}");
                    });
                }
            }
            catch
            {

            }
            
        }
    }
}
