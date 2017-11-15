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
            MemberInfo mi = typeof(MyClass);

            object[] attributes = mi.GetCustomAttributes(true);

            for(int i=0;i<attributes.Length;i++)
            {
                Console.WriteLine(((ConsoleApp10.HelpAttribute)attributes[i]).Url);
            }
             
            Console.ReadLine();
        }
    }
}
