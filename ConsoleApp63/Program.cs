using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp63
{
    //This generic delegate can represent any method returning void and taking a single parameter of type T.
    public delegate void MyGenericDelegate<T>(T arg);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Fun with Action and Func*****");

            //Use the Action<> delegate to point to DisplayMessage.
            Action<string, ConsoleColor, int> actionTarget = new Action<string, ConsoleColor, int>(DisplayMessage);
            actionTarget("Action Message!", ConsoleColor.Yellow, 10);
            Console.ReadLine();
        }

        static void StringTarget(string arg)
        {
            Console.WriteLine("arg in uppercase is :{0}\n\n", arg.ToUpperInvariant());
        }

        static void IntTarget(int arg)
        {
            Console.WriteLine("++arg is :{0}", ++arg);
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

            //restore color.
            Console.ForegroundColor = previous;
        }
    }
}
