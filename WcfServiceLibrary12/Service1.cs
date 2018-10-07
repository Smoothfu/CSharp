using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary12
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MathService : IMathService
    {
        public string AddMethod(int x, int y)
        {
            return string.Format("{0}+{1}={2}\n", x, y, x + y);
        }

        public void Dispose()
        {
            
        }
    }
}
