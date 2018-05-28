using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ConsoleApp186
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {       

        public string DoWork(int value)
        {
            int squareValue = value * value;
            return string.Format("The {0} of square value is {1}", value, squareValue);
        }

        public string Add(int x,int y)
        {
            return string.Format("{0}+{1}={2}", x, y, x + y);
        }
    }
}
