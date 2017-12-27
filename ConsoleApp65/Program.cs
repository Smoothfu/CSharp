using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace ConsoleApp65
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with Anonymous Types*****\n");

            //Make an anonymous type representing a car.
            var myCar = new { Color="BlacK",Make="Mercedes Benz",CurrentSpeed=55};

            //Reflect over what the compiler generated.
            ReflectOverAnonymousType(myCar);    
           
            Console.ReadLine();
        }

        static void BuildAnonType(string make,string color,int currSp)
        {
            //Build anon type using incoming args.
            var car = new { Make = make, Color = color, Speed = currSp };

            //Note you can now use this type to get the property data!
            Console.WriteLine("You have a {0} {1} going {2} KPH\n", car.Color, car.Make, car.Speed);

            //Anon types have custom implementations of each virtual method of System.Object.
            Console.WriteLine("ToString()=={0}\n", car.ToString());
        }

        static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine("obj is an instance of :{0}\n", obj.GetType().Name);
            Console.WriteLine("Base class of {0} is {1}\n", obj.GetType().Name, obj.GetType().BaseType);
            Console.WriteLine("obj.ToString()=={0}\n", obj.ToString());
            Console.WriteLine("obj.GetHashCode()=={0}\n", obj.GetHashCode());
            Console.WriteLine("\n\n\n\n");
        }
    }

    static class MyExtensions
    {
        //This method allows any object to display the assembly it is defined in 
        public static void DisplayDefiningAssembly(this object obj)
        {
            Console.WriteLine("{0} lives here:=>{1}\n\n", obj.GetType().Name,
                Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }

        //This method allows any integer to reverse its digits.
        //For example,56 would return 65.
        public static int ReverseDigits(this int i)
        {
            //Translate int into a string, and then get all the characters.
            char[] digits = i.ToString().ToCharArray();

            //Now reverse items in the array.
            Array.Reverse(digits);

            //put back into string.
            string newDigits = new string(digits);

            //Finally,return the modified string back as an int.
            return int.Parse(newDigits);
        }
    }

    static class AnnoyingExtensions
    {
        public static void PrintDataAndBeep(this System.Collections.IEnumerable iterator)
        {
            foreach(var item in iterator)
            {
                Console.WriteLine(item+"\n");
                Console.Beep();
            }
        }
    }
}
