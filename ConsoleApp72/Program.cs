using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp72
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****GC Basics*****\n");

            //Create a new Car object on the managed heap.we are returned a reference to this object.

            Car refToMyCar=new Car("BMW",50);

            //The C# dot operator(.) is used to invoke members on the object using our reference variable.
            Console.WriteLine(refToMyCar.ToString());
            Console.ReadLine();
        }

        static void MakeCar()
        {
            //If myCar is the only reference to the Car object,it may be destoryed when this method returns.
            Car myCar = new Car();

        }
    }

    public class Car
    {
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }

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
    }
}
