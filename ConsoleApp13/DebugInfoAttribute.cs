using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Constructor|AttributeTargets.Field
        |AttributeTargets.Method|AttributeTargets.Property,AllowMultiple =true)]
    public class DebugInfoAttribute:Attribute
    {
        public string name;

        public string id;
        public DebugInfoAttribute(string name,string id)
        {
            this.name = name;
            this.id = id;

        }
    }
}
