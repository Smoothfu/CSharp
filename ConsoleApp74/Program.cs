﻿using System;
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

            //Print out the estimated number of bytes on heap.
            Console.WriteLine("Estimated bytes on heap:{0}\n", GC.GetTotalMemory(false));

            //MaxGeneration is zero based.
            Console.WriteLine("This OS has {0} object generations.\n", (GC.MaxGeneration + 1));

            Car refToMyCar = new Car("BENZ", 50);
            Console.WriteLine(refToMyCar);

            //Print out generation of refToMyCar.
            Console.WriteLine("\nGeneration of refToMyCar is :{0}\n", GC.GetGeneration(refToMyCar));

            //Make a ton of objects for testing purposes.
            object[] tonsOfObjects = new object[50000];

            for(int i=0;i<50000;i++)
            {
                tonsOfObjects[i] = new object();
            }

            //Collect only gen 0 objects.
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            //Print out generation of the reToMyCar.
            Console.WriteLine("Generation of refToMyCar is :{0}\n", GC.GetGeneration(refToMyCar));


            //See if tonsOfObjects[9000] is still alive.
            if(tonsOfObjects[9000]!=null)
            {
                Console.WriteLine("Generation of tonsOfObjects[9000] is :{0}\n", GC.GetGeneration(tonsOfObjects[9000]));
            }
            else
            {
                Console.WriteLine("tonsOfObjects[9000] is no longer alive.\n");
            }

            //Print out how many times a generation has been swept.

            Console.WriteLine("\nGen 0 has been swept {0} times\n", GC.CollectionCount(0));

            Console.WriteLine("Gen 2 has been swept {0} times.\n", GC.CollectionCount(2));


            Console.WriteLine("Estimated bytes on heap:{0}\n", GC.GetTotalMemory(false));

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
