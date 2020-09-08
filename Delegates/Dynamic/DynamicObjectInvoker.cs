using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Dynamic
{
    public class DynamicObjectInvoker:DynamicObject
    {
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            Console.WriteLine(binder.Name + " method was called");
            result = null;
            return true;
        }
    }
}
