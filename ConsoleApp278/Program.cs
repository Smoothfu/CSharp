using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ConsoleApp278
{
    public delegate void MathDel(int x, int y);
    
    class Program
    {
        public event MathDel MathEvent;
        static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            Subscriber sub1 = new Subscriber("sub1", pub);
            Subscriber sub2 = new Subscriber("sub2", pub);

            //Call the method that raises the event.
            pub.DoSomething();

            //Keep the console window open.
            Console.WriteLine("Press enter to close this window.");
            
            Console.ReadLine();
        }

        private static void Obj_MathEvent1(int x, int y)
        {
            throw new NotImplementedException();
        }

        private void Obj_MathEvent(int x, int y)
        {
             if(x>100000)
            {
               
            }
        }

        public  void OnMath(int x,int y)
        {
            if(MathEvent!=null)
            {
                MathEvent(x, y);
            }
        }
        public void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }

        public void SubMethod(int x,int y)
        {
            Console.WriteLine("{0}-{1}={2}\n", x, y, x - y);
        }

        public void Multiply(int x,int y)
        {
            Console.WriteLine("{0}*{1}={2}\n", x, y, x * y);
        }

        public void Divide(int x,int y)
        {
            Console.WriteLine("{0}/{1}={2}\n", x, y, x / y);
        }
    }

    public abstract class Animal
    {
        public abstract void Eat();
        public virtual void Run()
        {
            Console.WriteLine("The live animal can run!");
        }
    }

    public class Person:Animal
    {
        public override void Eat()
        {
            Console.WriteLine("The human being eat cooked food!");
        }

        public override void Run()
        {
            Console.WriteLine("Floomberg should run 10000 m+ everyday!");
        }
    }

    //Define a class to hold custom event info.
    public class CustomEventArgs:EventArgs
    {
        public CustomEventArgs(string str)
        {
            message = str;
        }

        private string message;
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
    }

    //class that publishes an event.
    class Publisher
    {
        //Declare the event using EventHandler<T>
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;

        public void DoSomething()
        {
            //Write some code that does something useful here then raise the event.you can also raise an
            //event before you execute a block of code.
            OnRaiseCustomEvent(new CustomEventArgs("Did something!"));
        }
        
        //Wrap event invocations inse a protected virtual method to allow 
        //derived classes to override the event invocation behavior
        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            //Make a temporary copy of the event to avoid possibility of a race condition if the 
            //last subscribes immediately after the null check and before the event is raised.
            EventHandler<CustomEventArgs> handler = RaiseCustomEvent;

            //Event will be null if there are no subscribers.
            if (handler != null)
            {
                //Format the string to send inside the customeventargs parameter 
                e.Message += string.Format("at {0}", DateTime.Now.ToString());
            }

            //Use the () operator to raise the event.
            handler(this, e);
        }        
    }

    //class that subscribes to an event.
    class Subscriber
    {
        private string id;
        public Subscriber(string ID,Publisher pub)
        {
            id = ID;

            //Subscribe to the event using C# 2.0 syntax.
            pub.RaiseCustomEvent += HandleCustomEvent;
        }

        //Define what actions to take when the event is raised.
        private void HandleCustomEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine(id + " received this message:{0}\n", e.Message);
        }
    }
}
