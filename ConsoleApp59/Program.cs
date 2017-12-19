using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp59
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Method Group Conversion*****\n");
            Car c1 = new Car();

            //Register the simple method name.
            c1.RegisterWithCarEngine(CallMeHere);

            Console.WriteLine("*****Speeding up*****");
            for(int i=0;i<10;i++)
            {
                c1.Accelerate(20);
            }

            //Unregister the simple method name.
            c1.UnRegisterWithCarEngine(CallMeHere);

            //No more notifications!

            for(int i=0;i<10;i++)
            {
                c1.Accelerate(20);
            }
            Console.ReadLine();
        }

        static void CallMeHere(string msg)
        {
            Console.WriteLine("=>Message from Car:{0}", msg);
        }

        private static void OnCarEngineEvent2(string msgForCaller)
        {
            Console.WriteLine("=>{0}", msgForCaller.ToUpper());
        }

        private static void OnCarEngineEvent(string msgForCaller)
        {
            Console.WriteLine("\n*****Message From Car Object*****");
            Console.WriteLine("=>{0}", msgForCaller);
            Console.WriteLine("*************************************************\n");
        }

        static void DisplayDelegateInfo(Delegate delObj)
        {
            //Print the names of each member in the delegate's invocation list.
            foreach(Delegate del in delObj.GetInvocationList())
            {
                Console.WriteLine("Method Name:{0}", del.Method);
                Console.WriteLine("Type Name:{0}", del.Target);
            }
        }
    }

    //This delegate can point to any method,
    //taking two integers and returning an integer.

    public delegate int BinaryOp(int x, int y);

    //This class contains methods BinaryOp will point to.

    public class SimpleMath
    {
        public static int Add(int x,int y)
        {
            return x + y;
        }

        public static int Subtract(int x,int y)
        {
            return x - y;
        }

        public static int SquareNumber(int a)
        {
            return a * a;
        }
    }

    public class Car
    {
        //internal state data.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }

        //Is the car alive or dead?
        private bool carIsDead;

        //class constructors.
        public Car()
        {

        }

        public Car(string name,int maxSp,int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }

        //1) Define a delegate type.
        public delegate void CarEngineHandler(string msgForCaller);

        //2)Define a member variable of this delegate.
        private CarEngineHandler listOfHandlers;

        //3)Add registration function for the caller.
        //Now with multicasting support!
        //Note we are now using the+=operator,not the assignment operator=.
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {            
            listOfHandlers += methodToCall;
        }

        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;
        }

        //4)Implement the Accelerate() method to invoke the delegate's invocation list under the correct circumstances.

        public void Accelerate(int delta)
        {
            //If this car is "dead",send dead message.
            if(carIsDead)
            {
                if(listOfHandlers!=null)
                {
                    listOfHandlers("Sorry,this car is dead...");
                }
            }

            else
            {
                CurrentSpeed += delta;

                //Is this car "almost dead"?
                if(10==(MaxSpeed-CurrentSpeed) && listOfHandlers != null)
                {
                    listOfHandlers("Careful buddy!Gonna blow!");
                }

                if(CurrentSpeed>=MaxSpeed)
                {
                    carIsDead = true;
                }
                else
                {
                    Console.WriteLine("CurrentSpeed={0}", CurrentSpeed);
                }
            }
        }

    }
}
