using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp345
{
    class Program
    {
        static void Main(string[] args)
        {
            DivideNumber();
            Console.ReadLine();
        }

        static void DivideNumber()
        {
            Task.Run(() =>
            {
                try
                {
                    for (int i = 10; i < 100; i++)
                    {
                        for (int j = 10; j >= 0; j--)
                        {
                            Console.WriteLine($"i/j={i / j}");
                        }
                    }

                }

               

                catch (ArithmeticException ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(ex.Message);
                }

                catch (DivideByZeroException ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(ex.Message);
                }
            });
        }
    }
}
