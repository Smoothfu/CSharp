using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace ConsoleApp69
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = Type.GetType("System.Data.DataTable,System.Data,Version=1.0.3300.0,  Culture=neutral,  PublicKeyToken=b77a5c561934e089");
            DataTable dt = (DataTable)Activator.CreateInstance(type);
        }
    }
}
