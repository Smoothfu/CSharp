using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(MathClass);
            MethodInfo[] mis = type.GetMethods();
            foreach(MethodInfo mi in mis)
            {
                Console.WriteLine("HashCode: "+mi.GetHashCode());
                Console.WriteLine("Parameters: "+mi.GetParameters());
                Console.WriteLine("Type:"+mi.GetType());
                Console.WriteLine("MemberType: "+mi.MemberType);
                Console.WriteLine("MetadataToken:"+mi.MetadataToken);
                Console.WriteLine("Module:"+mi.Module);
                Console.WriteLine("Name:"+mi.Name);
                Console.WriteLine("ReflectedType:"+mi.ReflectedType+"\n\n");
            }

            Console.ReadLine();

        }
    }

    public class MathClass
    {
        public void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}", x, y, x + y);
        }

        public void SubtractMethod(int x,int y)
        {
            Console.WriteLine("{0}-{1}={2}", x, y, x - y);
        }

        public void MultiplyMethod(int x,int y)
        {
            Console.WriteLine("{0}*{1}={2}", x, y, x * y);
        }
    }
}
