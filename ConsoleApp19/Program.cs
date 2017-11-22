using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    class Program
    {
        static void Main(string[] args)
        {

            Type type = typeof(MathClass); 
            MathClass.ListMethods(type);
            Console.ReadLine();
        }
    }

    public class MathClass
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Z = 1000;

        public MathClass()
        {

        }

        public MathClass(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Add(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}", x, y, x + y);
        }

        public void Subtract(int x,int y)
        {
            Console.WriteLine("{0}-{1}={2}", x, y, x - y);
        }

        public static void ListVariousStatus(Type type)
        {
            Console.WriteLine("*****Various Statistics*****");
            Console.WriteLine("Is type abstract? {0}", type.IsAbstract);
            Console.WriteLine("Is type sealed?{0}", type.IsSealed);
            Console.WriteLine("Is type generic?{0}", type.IsGenericTypeDefinition);
            Console.WriteLine("Is type a class type?{0}", type.IsClass);
        }

        public static void ListMethods(Type type)
        {
            Console.WriteLine("*****Methods*****");
            MethodInfo[] mis = type.GetMethods();

            foreach(MethodInfo mi in mis)
            {
                //Get return type.
                string retVal = mi.ReturnType.FullName;

                string paramInfo = "(";

                //Get params.
                foreach(ParameterInfo pi in  mi.GetParameters())
                {
                    paramInfo += string.Format("{0} {1}", pi.ParameterType, pi.Name);
                }

                paramInfo += ")";

                //Now display the basic method sig.
                Console.WriteLine("->{0} {1} {2}", retVal, mi.Name, paramInfo);
            }
           
        }
    }
}
