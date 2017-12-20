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

            Console.WriteLine("*****Agh!No Encapsulation!*****\n");

            //Make a Car.
            Car myCar = new Car();

            //We have direct access to the delegate!
            myCar.listOfHandlers = new Car.CarEngineHandler(CallWhenExploded);

            myCar.Accelerate(10);

            //We can now assign to a whole new object... confusing at best.
            myCar.listOfHandlers = new Car.CarEngineHandler(CallHereToo);
            myCar.Accelerate(10);


            //The caller can also directly invoke the delegate!
            myCar.listOfHandlers.Invoke("Hee,hee,hee...");

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

        static void CallWhenExploded(string msg)
        {
            Console.WriteLine(msg);
        }

        static void CallHereToo(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public class Car
    {
        public delegate void CarEngineHandler(string msgForCaller);


        //Now a public member!
        public CarEngineHandler listOfHandlers;


        //Just fire out the Exploded notification.

        public void Accelerate(int delta)
        {
            if(listOfHandlers!=null)
            {
                listOfHandlers("Sorry, this car is dead...");
            }
        }
    }
}
