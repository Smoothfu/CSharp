using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleApp10
{

   [AttributeUsage(AttributeTargets.All)]
   public class HelpAttribute : Attribute
    {
        public readonly string Url;
        private string topic;
        public string Topic
        {
            get
            {
                return topic;
            }
            set
            {
                topic = value;
            }
        }

        public HelpAttribute(string url)
        {
            this.Url = url;
        }
    }

    [HelpAttribute("Information on the class Myclass")]
    class MyClass
    {

    }
    class Program
    {         
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(20, 100);
            rect.Display();

            Type type = typeof(Rectangle);

            //iterating through the attributes of the Rectangle class
            foreach(object att in type.GetCustomAttributes(false))
            {
                DebugInfoAttribute dbi = (DebugInfoAttribute)att;
                if(dbi!=null)
                {
                    Console.WriteLine("Bug No: {0}",dbi.BugNo);
                    Console.WriteLine("Developer: {0}", dbi.Developer);
                    Console.WriteLine("Last Reviewed:{0}", dbi.LastReview);
                    Console.WriteLine("Remarks: {0}", dbi.message);
                }
            }
            Console.ReadLine();
        }
    }
}
