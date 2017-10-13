using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace ConsoleApp69
{

    public class TestClass
    {
        private string _value;
        public TestClass(string value)
        {
            _value = value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Type type = Type.GetType("ConsoleApp69.TestClass");
            object[] constructParams = new object[] { "Hello" };
            TestClass obj = (TestClass)Activator.CreateInstance(type, constructParams);            
        }
    }
}
