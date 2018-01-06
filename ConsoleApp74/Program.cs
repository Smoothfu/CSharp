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
            //Dispose() is called automatically when the using scope exists.
            using (MyResourceWrapper mrw = new MyResourceWrapper())
            {
                //use mrw object.
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

        //Assume you have imported the System.IO namespace...
        static void DisposeFileStream()
        {
            FileStream fs = new FileStream("mytext.txt", FileMode.OpenOrCreate);
             
            //Confusing,to say the least!
            //These method calls do the same thing.
            fs.Close();
            fs.Dispose();
        }
    }
}
