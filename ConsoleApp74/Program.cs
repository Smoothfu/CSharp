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
            Console.WriteLine("*****Fun with Dispose*****\n");

            //Cretae a disposable object and call Dispose()
            //to free any internal resources
            MyResourceWrapper rw = new MyResourceWrapper();
            rw.Dispose();
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
    //Implementing IDisposable.
    class MyResourceWrapper:IDisposable
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


        //The object user should call this method when they finish with the object.
        public void Dispose()
        {
            //Clean up unmanaged resources...
            //Dispose other contained disposable objects...
            //Just for a test.
            Console.WriteLine("*****In Dispose!*****\n");
        }
    }
}
