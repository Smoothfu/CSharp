using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ToUpperService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ToUpperService.svc or ToUpperService.svc.cs at the Solution Explorer and start debugging.
    public class ToUpperService : IToUpperService
    {       
        public string StringToUpper(string str)
        {
            return str.ToUpper();
        }
    }
}
