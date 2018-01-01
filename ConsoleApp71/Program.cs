using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp71
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with System.GC*****\n");

            //print out estimated number of bytes on heap.
            Console.WriteLine("Estimated number of bytes on heap:{0}\n", GC.GetTotalMemory(false));


            //MaxGeneration is zero based,so add 1 for display purposes.
            Console.WriteLine("This OS has {0} object genertions.\n", (GC.MaxGeneration + 1));

            Car refToMyCar = new Car("BMW", 50);
            Console.WriteLine(refToMyCar.ToString());

            //Print out generation of refToMyCar object.
            Console.WriteLine("Generation of refToMyCar is :{0}\n", GC.GetGeneration(refToMyCar));

            refToMyCar.SpeedUp();

            //Print out the generation of refToMyCar object.
            Console.WriteLine("Generation of refToMyCar after invoke is :{0}\n", GC.GetGeneration(refToMyCar));

            refToMyCar.SpeedUp();
            Console.ReadLine();
        }
    }

    //Car.cs
    public class Car
    {
        public int CurrentSpeed { get; set;}
        public string PetName { get; set;}

        public Car()
        {

        }

        public Car(string name,int speed)
        {
            PetName = name;
            CurrentSpeed = speed;
        }

        public override string ToString()
        {
            return string.Format("{0} is going {1} MPH\n", PetName, CurrentSpeed);
        }

        public void SpeedUp()
        {
            Console.WriteLine("Speed up to less than 60!\n");
        }

    }
}
