using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLibrary;
using System.Configuration;
using System.Reflection;

namespace ConsoleApp80
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(SuperCar);
            Console.WriteLine("Assembly: {0}\n", t.Assembly);
            Console.WriteLine("BaseType: {0}\n", t.BaseType);
            Console.WriteLine("MemberType: {0}\n", t.MemberType);
            Console.WriteLine("Module: {0}\n", t.Module);
            Console.WriteLine("NameSpace: {0}\n", t.Namespace);
            Console.WriteLine("ReflectedType:{0}\n", t.ReflectedType);
            Console.WriteLine("ToString():{0}\n", t.ToString());
            Console.WriteLine("Name: {0}\n",t.Name);
            Console.WriteLine("FullName: {0}\n",t.FullName);
            Console.WriteLine("GUID: \n",t.GUID);             
            Console.ReadLine();
        }
    }
}
