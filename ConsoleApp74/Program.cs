using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp74
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with Dispose*****\n");

            //Use a comma-delimited list to declare multiple objects to dispose.
            using (MyResourceWrapper rw1 = new MyResourceWrapper(), rw2 = new MyResourceWrapper())
            {

            }
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


    //A sophiscated resource wrapper.
    public class MyResourceWrapper : IDisposable
    {
        //The garbage collector will call this method if the object user forgets to call Dispose().
        ~MyResourceWrapper()
        {
            //Clean up any internal unmangaed resources.
            //Do not call Dispose() on any managed objects.
        }

        //The object will call this method to clean up resources ASAP.
        public void Dispose()
        {
            //Clean up unmanaged resources here.
            //Call Dispose() on other contained disposable objects.
            //No need to finalize if user called Dispose().
            //so suppress finalization.
            GC.SuppressFinalize(this);
        }
    }
}
