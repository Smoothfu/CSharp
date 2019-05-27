using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text; 

namespace MathService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MathServiceWCF" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MathServiceWCF.svc or MathServiceWCF.svc.cs at the Solution Explorer and start debugging.
    public class MathServiceWCF : IMathServiceWCF
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
    }
}
