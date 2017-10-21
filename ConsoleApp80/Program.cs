using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp80
{
    [AttributeUsage(AttributeTargets.All)]
    public class HelpAttribute:System.Attribute
    {
        public readonly string Url;

        private string topic;
        //topic 是一个命名(named)参数
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

        //url是一个定位参数
        public HelpAttribute(string url)
        {
            this.Url = url;
        }
    }

    [HelpAttribute("Information on the class MyClass")]
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
                Console.WriteLine(attributes[i]);
            }
            Console.ReadLine();
        }
    }
}
