using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace ConsoleApp337
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            string finalResult=client.Add(10, 20);
            Console.WriteLine(finalResult);
            Console.ReadLine();
        }

        static void ParamArrayAttributeExample()
        {
            Temperature temp = new Temperature(100);
            string[] formats = { "C", "G", "F", "K" };

            //call display method with a string empty.
            Console.WriteLine("Calling Display with a string array: ");
            temp.Display(formats);

            Console.WriteLine();

            //Call Display method with individual string arguments.
            Console.WriteLine("Calling Display with individual arguments:");
            temp.Display("C", "F", "K", "G");
            Console.WriteLine();

            //Call parameter Display method.
            Console.WriteLine("Calling Display with an implicit parameter array:");
            temp.Display();
        }
        static void TestOverload()
        {
            Add(0);
            Add(1, 2);
            Add(1, 2, 3);
        }
        static void Add(params int[]arr)
        {
            Console.WriteLine("params int[]arr");
        }
        static void Add(int x,int y)
        {
            Console.WriteLine("X&Y");
        }
    }

    public abstract class AbstractClass
    {
        public virtual void VirtualMethod()
        {
            Console.WriteLine("Virtual method in abstract class");
        }
    }

    public class ConcreteClass:AbstractClass
    {

    }

    public class Temperature
    {
        private decimal temp;
        public Temperature(decimal temperature)
        {
            this.temp = temperature;
        }

        public override string ToString()
        {
            return ToString("C");
        }

        public string ToString(string format)
        {
            if(string.IsNullOrEmpty(format))
            {
                format = "G";
            }

            switch (format.ToUpper())
            {
                case "G":
                case "C":
                    return temp.ToString("N") + " ℃";
                case "F":
                    return (9 * temp / 5 + 32).ToString("N") + " ℉";
                case "K":
                    return (temp + 273.15m).ToString("N") + " °F";
                default:
                    throw new FormatException(string.Format("The '{0}' format specifier is not supported"));
            }
        }

        public void Display(params string[] formats)
        {
            if(formats.Length==0)
            {
                Console.WriteLine(this.ToString("G"));
            }
            else
            {
                foreach(string format in formats)
                {
                    try
                    {
                        Console.WriteLine(this.ToString(format));
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
