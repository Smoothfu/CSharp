using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp74
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with System.GC*****\n");

            //Print out estimated number of bytes on heap.
            Console.WriteLine("Estimated bytes on heap: {0}\n", GC.GetTotalMemory(false));

            //MaxGeneration is zero based,so add 1 for display purposes.
            Console.WriteLine("This OS has {0} object generation.\n", (GC.MaxGeneration + 1));

            Car refToMyCar = new Car("BENZ", 50);
            Console.WriteLine(refToMyCar.ToString());

            //Print out generation of refToMyCar object.
            Console.WriteLine("Generation of refToMyCar is :{0}\n", GC.GetGeneration(refToMyCar));

            Console.WriteLine(GC.GetTotalMemory(false));

            //Force a garbage collection and wait for each object to be finalized.
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.ReadLine();

        }
    }

    public class Car
    {
        public string CarName { get; set; }
        public double CarSpeed { get; set; }

        public Car(string carName,double carSpeed)
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
