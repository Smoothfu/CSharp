using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp61
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> funcTarget = new Func<int, int, int>(Add);
            int result = funcTarget(40, 40);
            Console.WriteLine("40+40={0}", result);

            Console.WriteLine("\n\nBelow is return string method!\n");

            Func<int, int, string> stringFuncTarget = new Func<int, int, string>(SumToString);
            string strResult = stringFuncTarget(10, 100);
            Console.WriteLine("The result of Func<int,int,string> is :{0}", strResult);

            Console.ReadLine();
        }

        //This is a target for the Action<> delegate.
        static void DisplayMessage(string msg,ConsoleColor txtColor,int printCount)
        {
            //Set color of console text.
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;

            for(int i=0;i<printCount;i++)
            {
                Console.WriteLine(msg+"\n\n");
            }

            //Restore color.
            Console.ForegroundColor = previous;
 
        }

        //Target for the Func<> delegate.
        static int Add(int x,int y)
        {
            return x + y;
        }

        static string SumToString(int x,int y)
        {
            return (x + y).ToString();
        }
    }
}
