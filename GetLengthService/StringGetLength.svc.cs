using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GetLengthService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StringGetLength" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StringGetLength.svc or StringGetLength.svc.cs at the Solution Explorer and start debugging.
    public class StringGetLength : IStringGetLength
    {   
        public int GetStringLengthResult(string str)
        {
            return str.Length;
        }
    }
}
