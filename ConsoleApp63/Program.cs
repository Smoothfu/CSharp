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
            //NameOfObject.NameOfEvent +=new RelatedDelegate(fucnctionToCall);

            Car myCar = new Car();
            Car.CarEngineHandler d = new Car.CarEngineHandler(CarExplodedEventHandler);
            myCar.Exploded += d;

            //When you want to detach from a source of events,use the -=operator,using the following pattern:
            //Name of object.NameOfEvent-=new RelatedDelegate(functionToCall);

            myCar.Exploded -= d;

            Console.ReadLine();
        }

        private static void CarExplodedEventHandler(string msgForCaller)
        {
            Console.WriteLine("This is the NameOfObject.NameOfEvent+=new RelatedDelegate(functionToCall)");
        }

        private static void CallWhenExploded(string msgForCaller)
        {
            Console.WriteLine(msgForCaller + "\n\n");
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

        static void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }

        static void SubtractMethod(int x,int y,int z)
        {
            Console.WriteLine("{0}-{1}-{2}={3}\n", x, y, z, x - y - z);
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

    public class Car
    {
        //Car's events
        public delegate void CarEngineHandler(string msgForCaller);

        //This car car send these events.
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;

        //Now a public member!
        public CarEngineHandler listOfHandlers;
        private bool carIsDead;

        public int CurrentSpeed { get; private set; }
        public int MaxSpeed { get; private set; } = 100;

        //Just fire out the Exploded notification.


        public void Accelerate(int delta)
        {
            //Id the car is dead,fire exploded event,
            if(carIsDead)
            {
                if(Exploded!=null)
                {
                    Exploded("Sorry,this car is dead...");
                }
                else
                {
                    CurrentSpeed += delta;

                    //Almost dead?

                    if(10==MaxSpeed-CurrentSpeed && AboutToBlow!=null)
                    {
                        AboutToBlow("Carefully buddy!Gonna blow!");
                    }

                    //Still OK!
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
}
