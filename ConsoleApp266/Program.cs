using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp266
{
    class MyGenericClass<T>
    {
        private T genericMemberVariable;
        public MyGenericClass(T value)
        {
            genericMemberVariable = value;
        }

        public T generateMethod(T genericParameter)
        {
            Console.WriteLine("Parameter type:{0},value:{1}\n", typeof(T).ToString(), genericParameter);
            Console.WriteLine("Return type:{0},value:{1}\n", typeof(T).ToString(), genericMemberVariable);
            return genericMemberVariable;
        }

        public T genericProperty { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyGenericClass<string> stringGenericClass = new MyGenericClass<string>("Hello Generics");
            stringGenericClass.genericProperty = "This is a generic property example";
            stringGenericClass.generateMethod("Generic Paramter");
            Console.ReadLine();

        }
    }
}
