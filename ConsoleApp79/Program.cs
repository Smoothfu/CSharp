using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp79
{     
    //一个自定义特性bugfix被赋给类及其成员
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Constructor|AttributeTargets.Field|AttributeTargets.Method|AttributeTargets.Property,AllowMultiple =true)]
    public class DebugInfo : System.Attribute
    {
        private int bugNo;
        private string developer;
        private string lastReview;
        public string message;

        public DebugInfo(int bg,string dev,string d)
        {
            this.bugNo = bg;
            this.developer = dev;
            this.lastReview = d;
        }

        public int BugNo
        {
            get
            {
                return bugNo;
            }
        }

        public string Developer
        {
            get
            {
                return developer;
            }
        }

        public string LastReview
        {
            get
            {
                return lastReview;
            }
        }

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

    [DebugInfo(45,"Zara Ali","12/8/2012",Message ="Return type mismatch")]
    [DebugInfo(49,"Nuha Ali","10/10/2012",Message ="Unused variable")]

    class Rectangle
    {
        //成员变量
        protected double length;
        protected double width;
        public Rectangle(double l,double w)
        {
            length = l;
            width = w;
        }
        
        [DebugInfo(55,"Zara Ali","19/10/2012",Message="Return type mismatch")]

        public double GetArea()
        {
            return length * width;
        }
        public void Display()
        {
            Console.WriteLine("Length:{0}", length);
            Console.WriteLine("Width:{0}", width);
            Console.WriteLine("Area: {0}",GetArea());
        
        }
    }
    class Program
    {   
        
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(20, 20);
            rect.Display();
            Console.ReadLine();
        }
    }
}
 