using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp73
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with System.GC*****\n");

            //Print out estimated number of bytes on heap.
            Console.WriteLine("Estimated bytes on head:{0}\n", GC.GetTotalMemory(true));

            //MaxGeneration is zero based,so add 1 for display purposes.
            Console.WriteLine("This OS has {0} object generations.\n", (GC.MaxGeneration + 1));

            Car refToMyCar = new Car("BMW", 50);

            //Force a garbage collection and wait for each object to be finialized.
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine(refToMyCar.ToString());


            //Print out generations of refToMyCar object.
            Console.WriteLine("Generation of refToMyCar is :{0}\n", GC.GetGeneration(refToMyCar));
            Console.ReadLine();
       
        }
    }

    public class Car
    {
        public string CarName { get; set; }
        public int CarSpeed { get; set; }

        public Car(string carName,int carSpeed)
        {
            CarName = carName;
            CarSpeed = carSpeed;
        }

        public override string ToString()
        {
            return string.Format("{0}'s speed is {1}\n", CarName, CarSpeed);
        }
    }
}
