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
            Console.WriteLine("*****Fun with Events*****\n");

            Car c1 = new Car("Mercedes Benz", 100, 10);

            //Register event handlers
            c1.CarEngineHandlerWithCustomized += new Car.CarEngineHandlerWithCustomizedEventArgs(CarAboutToBlow);

            Car.CarEngineHandlerWithCustomizedEventArgs d = new Car.CarEngineHandlerWithCustomizedEventArgs(CarExploded);
            c1.CarEngineHandlerExploded += d;

            Console.WriteLine("*****Speeding up*****");
            for (int i = 0; i < 10; i++)
            {
                c1.Accelerate(20);
            }

            //remove CarExploded method from invocation list.
            c1.CarEngineHandlerExploded -= d;

            Console.WriteLine("\n*****Speeding up******");

            for (int i = 0; i < 10; i++)
            {
                c1.Accelerate(20);
            }

            Console.ReadLine();
        }

        private static void CarExploded(string msgForCaller)
        {
            Console.WriteLine("This is from CarExploded: " + msgForCaller);
        }

        private static void CarExploded(object sender,CarEventArgs e)
        {
            Console.WriteLine("With the CarEventArgs e in CarExploded,{0} says:{1}", sender, e.msg);
        }

        private static void CarAboutToBlow(string msgForCaller)
        {
            Console.WriteLine("This is from CarAboutToBlow :" + msgForCaller);
        }

        private static void CarAboutToBlow(object sender,CarEventArgs e)
        {

            //Just to be safe,perform a runtime check before casting.
            Car c = sender as Car;
            if(c!=null)
            {
                Console.WriteLine("With the CarEventArgs e in CarAboutToBlow,{0} says:{1}", sender, e.msg);
            }
            
        }

        private static void CarIsAlmostDoomed(string msgForCaller)
        {
            Console.WriteLine("This is CarIsAlmostDoomed: " + msgForCaller);
        }

        private static void C1_AboutToBlow(string msgForCaller)
        {
            throw new NotImplementedException();
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
        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            //Set color of console text.
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;

            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg + "\n\n");
            }

            //restore color.
            Console.ForegroundColor = previous;
        }

        static void AddMethod(int x, int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }

        static void SubtractMethod(int x, int y, int z)
        {
            Console.WriteLine("{0}-{1}-{2}={3}\n", x, y, z, x - y - z);
        }

        //Target for the Func<> delegate.
        static int Add(int x, int y)
        {
            return x + y;
        }

        static string SumToString(int x, int y)
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
        private bool carIsDead { get; set; }

        public int CurrentSpeed { get; private set; }
        public int MaxSpeed { get; private set; } = 100;

        public string CarName { get; private set; }

        public int Delta { get; private set; }

        public Car(string name, int maxSpeed, int deltaValue)
        {
            CarName = name;
            MaxSpeed = maxSpeed;
            Delta = deltaValue;
        }

        //Define the delegate  with customzied CarEventArgs

        public delegate void CarEngineHandlerWithCustomizedEventArgs(object sender, CarEventArgs e);
        public event CarEngineHandlerWithCustomizedEventArgs CarEngineHandlerWithCustomized;
        public event CarEngineHandlerWithCustomizedEventArgs CarEngineHandlerExploded;

        //Just fire out the Exploded notification.


        public void Accelerate(int delta)
        {
           
            //Id the car is dead,fire exploded event,
            if (carIsDead)
            {
                CarEngineHandlerExploded?.Invoke(this, new CarEventArgs("Sorry,this car is dead..."));
            }

            //If the car is active
            else
            {
                CurrentSpeed += delta;

                //Almost dead?

                if (10 == MaxSpeed - CurrentSpeed)
                {
                    AboutToBlow?.Invoke("Carefully buddy!Gonna blow!\n");
                }

                //Still OK!
                if (CurrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                }
                else
                {
                    Console.WriteLine("CurrentSpeed={0}\n", CurrentSpeed);
                }
            }
        }
    }

    public class CarEventArgs : EventArgs
    {
        public readonly string msg;
        public CarEventArgs(string message)
        {
            msg = message;
        }
    }

}

