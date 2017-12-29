using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp67
{
    class Program
    {
        static void Main(string[] args)
        {
            DeclareImplicitVars();
            Console.ReadLine();
        }

        static void DeclareImplicitVars()
        {
            //Implicitly typed local variables.
            var myInt = 0;
            var myBool = true;
            var myString = "Time,marches on...";

            //print out the underlying type.
            Console.WriteLine("myInt is a :{0}\n", myInt.GetType().Name);
            Console.WriteLine("myBool is a :{0}\n", myBool.GetType().Name);
            Console.WriteLine("myString is a :{0}\n", myString.GetType().Name);

        }

    }
}
