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
            Console.WriteLine("*****Fun with Action and Func*****");

            //Use the Action<> delegate to point to DisplayMessage.
            Action<string, ConsoleColor, int> actionTarget = new Action<string, ConsoleColor, int>(DisplayMessage);
            actionTarget("Action Message!", ConsoleColor.Yellow, 15);

            Console.WriteLine("\nThis is the end of the action");
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
    }
}
