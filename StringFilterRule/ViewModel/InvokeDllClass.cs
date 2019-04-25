using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilterFunctionDll;

namespace StringFilterRule.ViewModel
{
    static class InvokeDllClass
    {
        public static FilterAction GetFilterActionInstance()
        {
            FilterAction filterActionInstance = new FilterAction();
            return filterActionInstance;
        }
    }
}
