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
            Console.WriteLine("Allocated memory: {0}\n", GC.GetTotalMemory(false));
            Console.WriteLine("*****Fun with Finalizers*****\n");
            Console.WriteLine("Hit the return key to shut down this app!\n");
            Console.WriteLine("and force the GC to invoke Finalize()\n");
            Console.WriteLine("for finalizable objects created in this AppDomain.\n");
             
            MyResourceWrapper rw = new MyResourceWrapper();

            Console.WriteLine("Allocated memory: {0}\n", GC.GetTotalMemory(false));

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

    //override System.Object.Finalize() via finalizer syntax.
    class MyResourceWrapper
    {
        public MyResourceWrapper()
        {
            List<Object> objList = new List<object>();
            for(int i=0;i<1000;i++)
            {
                object obj = new object();
                objList.Add(obj);
            }
        }
        ~MyResourceWrapper()
        {
            //Clean up unmanaged resources here.

            //Beep when destoryed testing purposes only!
            Console.Beep();
        }
    }
}
