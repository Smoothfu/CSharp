using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp80
{
   //一个自定义特性BugFix被赋给类及其成员
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

    [DebugInfo(45,"Zara Ali","12/8/2012",message ="Return type mismatch")]
    [DebugInfo(49,"Nuha Ali","10/10/2012",message ="Unused variable")]
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

        [DebugInfo(55,"Zara Ali","19/10/2012",Message ="Return type mismatch")]

        public double GetArea()
        {
            return length * width;
        }

        [DebugInfo(56,"Zara Ali","19/10/2012")]
        public void Display()
        {
            Console.WriteLine("Length:{0}", length);
            Console.WriteLine("Width:{0}", width);
            Console.WriteLine("Area :{0}", GetArea());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(4.5, 7.5);
            rect.Display();

            Type type = typeof(Rectangle);
            //遍历Rectangle类的特性
            foreach(object attributes in type.GetCustomAttributes(false))
            {
                DebugInfo di = (DebugInfo)attributes;
                if(null!=di)
                {
                    Console.WriteLine("Bug no:{0}", di.BugNo);
                    Console.WriteLine("Developer:{0}", di.Developer);
                    Console.WriteLine("Last Reviewed:{0}", di.LastReview);
                    Console.WriteLine("Remarks:{0}", di.message);
                }
            }

            //遍历方法特性
            foreach(MethodInfo mi in type.GetMethods())
            {
                foreach(Attribute at in mi.GetCustomAttributes(true))
                {
                    DebugInfo di = (DebugInfo)at;
                    if (null != di)
                    {
                        Console.WriteLine("Bug no:{0},for Method:{1}", di.BugNo, mi.Name);
                        Console.WriteLine("Developer: {0}", di.Developer);
                        Console.WriteLine("Last Reviewed:{0}", di.LastReview);
                        Console.WriteLine("Remarks:{0}", di.Message);
                    }
                }
            }
           
            Console.ReadLine();
        }
    }
}
