using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp58
{
    //This delegate can point to any method,taking two integers and returning an integer.
    public delegate int BinaryOp(int x, int y);

    //This class contains methods BinaryOp will point to.
    public class SimpleMath
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public static int Subtract(int x, int y)
        {
            return x - y;
        }

        public static void DisplayDelegateInfo(Delegate delObj)
        {
            //Print the names of each member in the delegate's invocation list.
            foreach (Delegate del in delObj.GetInvocationList())
            {
                Console.WriteLine("Method Name:{0}", del.Method);
                Console.WriteLine("Type Name:{0}", del.Target);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Delegates as event enablers*****\n");

            //First,make a Car object.
            Car c1 = new Car("SlugBug", 100, 10);

            //Now,tell the car which method to call when it wants to send us messages.
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));

            //Speed up(this will trigger the events).
            Console.WriteLine("*****Speeding up*****");
            for (int i = 0; i < 10; i++)
            {
                c1.Accelerate(20);
            }
            Console.ReadLine();
        }

        //This is the target for incoming events
        private static void OnCarEngineEvent(string msgForCaller)
        {
            Console.WriteLine("\n*****Message from car object*****");
            Console.WriteLine("=>{0}", msgForCaller);
            Console.WriteLine("*********************************************\n");
        }
    }

    public class Car
    {
        //Internal state data
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }

        //Is the car alive or dead?
        private bool carIsDead;

        //Class constructor
        public Car()
        {
        }

        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }

        //define a delegate type.
        public delegate void CarEngineHandler(string msgForCaller);

        //2)Define a member variable of this delegate.

        private CarEngineHandler listOfHandlers;

        //3)Add registration function for the caller.

        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers += methodToCall;
        }

        //4)Implement the Accelerate() method to invoke the delegate's invocation list under the correct circumstances.

        public void Accelerate(int delta)
        {
            //If this car is "dead",send dead message.
            if (carIsDead)
            {
                if (listOfHandlers != null)
                {
                    listOfHandlers("Sorry,this car is dead...");
                }
            }
            else
            {
                CurrentSpeed += delta;

                //Is this car "almost dead"?

                if (10 == (MaxSpeed - CurrentSpeed) && listOfHandlers != null)
                {
                    listOfHandlers("Careful buddy! Gonna blow!");
                }

                if (CurrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                }
                else
                {
                    listOfHandlers("CurrentSpeed= "+CurrentSpeed);
                }
            }
        }
    }
}


