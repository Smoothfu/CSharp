using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp12
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct,AllowMultiple =true)]
    public class AuthorAttribute:Attribute
    {
        public string name;
        public double version;
        public AuthorAttribute(string name)
        {
            this.name = name;
            version = 1.0;
        }
    }
}
