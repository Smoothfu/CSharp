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

            //Create the event publishers and subscriber
            Circle c1 = new Circle(54);
            Rectangle r1 = new Rectangle(12, 9);
            ShapeConatiner sc = new ShapeConatiner();

            //Add the shapes to the container
            sc.AddShape(c1);
            sc.AddShape(r1);

            //Cause some events to be raised.
            c1.Update(57);
            r1.Update(7, 7);

            //Keep the console window open in debug mode.
          
            
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

    //Special EventArgs class to hold info about shapes.
    public class ShapeEventArgs:EventArgs
    {
        private double newArea;
        public double NewArea
        {
            get
            {
                return newArea;
            }
        }
        public ShapeEventArgs(double d)
        {
            newArea = d;
        }
    }

    //Base class event publisher.
    public abstract class Shape
    {
        protected double area;
        public double Area
        {
            get
            {
                return area;
            }
            set
            {
                area = value;
            }
        }

        //The event.Note that by using the generic EventHandler<T> event we do not need to declare a separate delegate type.
        public event EventHandler<ShapeEventArgs> ShapeChanged;

        public abstract void Draw();

        //The event-invoking method that derived classes can override
        protected virtual void OnShapeChanged(ShapeEventArgs e)
        {
            //Make a temporary copy of the event to avoid possiblity a race condition
            //if the last subscriber unsubscribes immediately after the null check and before
            //the event is raised.
            EventHandler<ShapeEventArgs> handler = ShapeChanged;

            if(handler!=null)
            {
                handler(this, e);
            }
        }
    }

    public class Circle : Shape
    {
        private double radius;
        public Circle(double d)
        {
            radius = d;
            area = 3.14 * radius * radius;
        }

        public void Update(double d)
        {
            radius = d;
            area = 3.14 * radius * radius;
            OnShapeChanged(new ShapeEventArgs(area));
        }

        protected override void OnShapeChanged(ShapeEventArgs e)
        {
            //Do any circle-specific processing here.
            //call the base class event invoation method.
            base.OnShapeChanged(e);
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing a circle!");
        }
    }

    public class Rectangle:Shape
    {
        private double length;
        private double width;
        public Rectangle(double length,double width)
        {
            this.length = length;
            this.width = width;
            area = length * width;
        }

        public void Update(double length,double width)
        {
            this.length = length;
            this.width = width;
            area = width * length;

            OnShapeChanged(new ShapeEventArgs(area));
        }

        protected override void OnShapeChanged(ShapeEventArgs e)
        {
            //Do any rectangle-specific processing here.
            //Call the base class event invocation method.
            base.OnShapeChanged(e);
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing a rectangle!");
        }
    }

    //Represents the surface on which the shapes are drawn subscribes to shape events so that it knows
    //when to redraw a shape.
    public class ShapeConatiner
    {
        List<Shape> _list;
        public ShapeConatiner()
        {
            _list = new List<Shape>();
        }

        public void AddShape(Shape s)
        {
            _list.Add(s);

            //Subscribe to the base class event.
            s.ShapeChanged += S_ShapeChanged;
        }

        //other methods to draw,resize,etc.
        private void S_ShapeChanged(object sender, ShapeEventArgs e)
        {
            Shape s = sender as Shape;
            if (s != null)
            {
                //Diagnostic messgae for demonstration purposes.
                Console.WriteLine("Received event.Shape area is now {0}\n", e.NewArea);

                //Redraw the shape here.
                s.Draw();
            }
        }
    }
}
